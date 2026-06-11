# Notas de desarrollo

## Contexto general

Proyecto WinForms .NET 8 para una libreria, organizado en capas:

- `Libreria.UI`
- `Libreria.Business`
- `Libreria.Data`
- `Libreria.Entity`
- `Libreria.Seguridad`

Se elimino la capa Mapper porque no se va a usar. Tambien se borro el proyecto/carpeta duplicado `Seguridad`; la capa valida es `Libreria.Seguridad`.

## Seguridad

`Libreria.Seguridad` esta agregado a la solucion.

Clase principal:

- `Libreria.Seguridad/Encriptacion.cs`

Tiene:

- `EncriptarPassword(string pPassword)`
- `DesencriptarPassword(this string pPPasswordEncriptado)`

La implementacion usa Base64 sobre `Encoding.Unicode`. Se dejo con `throw ex;` porque se pidio conservar ese estilo.

## Entidades

Composite de seguridad:

- `Componente`
- `Rol`
- `Permiso`

`Componente` es abstracta. Por eso se borro `ComponenteBusiness` y `ComponenteData`.

`Usuario.Roles` fue cambiado de `List<string>` a `List<Rol>`.

Los roles del usuario no entran por constructor: la lista siempre se inicializa vacia y se asigna despues.

En constructores de entidades se prefiere usar `this.`.

## Base de datos XML

Los XML fuente viven en:

```text
Libreria.Data/BaseDeDatos
```

Archivos actuales:

- `Permisos.xml`
- `Roles.xml`
- `RutaBaseDeDatos.cs`

Los XML se copian al output al compilar mediante `Libreria.Data.csproj`.

`RutaBaseDeDatos.BuscarRuta(string nombreArchivo)` arma rutas portables usando:

```csharp
Path.Combine(
    AppDomain.CurrentDomain.BaseDirectory,
    "BaseDeDatos",
    nombreArchivo
);
```

La app lee desde el `bin` del proyecto ejecutable, no desde la carpeta fuente.

## Permisos

Los permisos son permisos amplios de pantalla/modulo, no acciones CRUD individuales.

`Permisos.xml`:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<Permisos>
  <Permiso Id="1">
    <Nombre>Inicio</Nombre>
  </Permiso>
  <Permiso Id="2">
    <Nombre>ABM usuarios</Nombre>
  </Permiso>
  <Permiso Id="3">
    <Nombre>Gestion de roles y permisos</Nombre>
  </Permiso>
</Permisos>
```

`Id` se usa como atributo. `Nombre` queda como nodo.

`PermisoData.ConsultarPermisos()` usa LINQ to XML con sintaxis:

```csharp
from permiso in documento.Root.Elements("Permiso")
select new Permiso(...)
```

Se eligio la version simple, confiando en que el XML tiene la estructura correcta.

`PermisoBusiness.ConsultarPermisos()` delega en `PermisoData`.

## Roles

`Roles.xml` arranca vacio:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<Roles>
</Roles>
```

Estructura esperada al agregar roles:

```xml
<Rol Id="1">
  <Nombre>Administrador</Nombre>
</Rol>
```

Mas adelante, si se asignan permisos a roles, se puede extender:

```xml
<Rol Id="1">
  <Nombre>Administrador</Nombre>
  <Permisos>
    <Permiso Id="1" />
    <Permiso Id="2" />
  </Permisos>
</Rol>
```

`RolData` ya tiene:

- `ConsultarRoles()`
- `AltaRol(Rol rol)`
- `ObtenerProximoId()`

`RolBusiness` ya tiene:

- `AltaRol(string nombre)`
- `ConsultarRoles()`
- `Validar(string nombre)`
- `Validar(string nombre, int idRolActual)`

Se eligio sobrecargar `Validar` para poder reutilizarla en modificacion. En alta se valida contra todos los roles. En modificacion se permite conservar el mismo nombre si corresponde al mismo `Id`.

## FormRolesPermisos

`FormRolesPermisos` carga permisos disponibles al iniciar.

Usa:

- `PermisoBusiness`
- `tvPermisos`

Cada permiso se agrega como `TreeNode`:

- `Text`: `permiso.Nombre`
- `Tag`: objeto `Permiso` completo

Esto permite mostrar solo el nombre y recuperar despues el objeto real desde `SelectedNode.Tag`.

`Libreria.UI` referencia a `Libreria.Business`.

## Decisiones de estilo

- Se prefiere hablar antes de implementar cambios grandes.
- Se prefiere mantener el estilo academico del profesor cuando no perjudique el diseño.
- Para LINQ XML se acepta la sintaxis `from ... in ... select`.
- Se prefiere `this.` en constructores.
- Se evita agregar Mapper.
- Data accede a XML. Business valida y coordina. UI solo invoca Business.

## Advertencias conocidas

Puede haber warnings nullable si se usa la version simple de LINQ XML accediendo directo a:

- `documento.Root`
- `Attribute("Id").Value`
- `Element("Nombre").Value`

Se acepto por ahora porque los XML son controlados por el proyecto.
