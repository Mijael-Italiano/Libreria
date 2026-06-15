# Contexto de trabajo - Roles y permisos

## Estado general

La solucion `Libreria` esta organizada en capas:

- `Libreria.UI`
- `Libreria.Business`
- `Libreria.Data`
- `Libreria.Entity`
- `Libreria.Seguridad`

La pantalla principal trabajada fue `FormRolesPermisos`.

## Persistencia XML

En `RutaBaseDeDatos` se crean los XML iniciales:

- `Usuarios.xml`
- `Roles.xml`
- `Permisos.xml`
- `RolesPermisos.xml`
- `UsuariosRoles.xml`

Datos iniciales importantes:

- Usuario `Admin` con `Id=1`.
- Rol `Admin` con `Id=1`.
- Permisos iniciales:
  - `1`: Inicio
  - `2`: ABM usuarios
  - `3`: Gestion de roles y permisos
- El rol Admin tiene los tres permisos.
- El usuario Admin tiene el rol Admin.

## Relaciones

### Rol-Permiso

Clase Data:

- `Libreria.Data/DataComposite/RolPermisoData.cs`

Metodos:

- `ConsultarIdsPermisosPorRol(int idRol)`
- `AsociarRolPermiso(int idRol, int idPermiso)`
- `DesasociarRolPermiso(int idRol, int idPermiso)`

Clase Business:

- `Libreria.Business/BusinessComposite/RolPermisoBusiness.cs`

Metodos principales:

- `AsociarRolPermiso(int idRol, int idPermiso)`
- `DesasociarRolPermiso(int idRol, int idPermiso)`
- `ConsultarPermisosPorRol(int idRol)`

### Usuario-Rol

Clase Data:

- `Libreria.Data/DataComposite/UsuarioRolData.cs`

Metodos:

- `ConsultarIdsRolesPorUsuario(int idUsuario)`
- `ConsultarIdsUsuariosPorRol(int idRol)`
- `AsociarUsuarioRol(int idUsuario, int idRol)`
- `DesasociarUsuarioRol(int idUsuario, int idRol)`

Clase Business:

- `Libreria.Business/BusinessComposite/UsuarioRolBusiness.cs`

Metodos principales:

- `AsociarUsuarioRol(int idUsuario, int idRol)`
- `DesasociarUsuarioRol(int idUsuario, int idRol)`
- `ConsultarRolesPorUsuario(int idUsuario)`
- `ConsultarIdsUsuariosPorRol(int idRol)`

## Decision de arquitectura importante

Se detecto un `StackOverflowException` por dependencia circular cuando `RolBusiness` instanciaba:

- `RolPermisoBusiness`
- `UsuarioRolBusiness`

El ciclo era:

```text
RolBusiness -> RolPermisoBusiness -> RolBusiness -> ...
RolBusiness -> UsuarioRolBusiness -> RolBusiness -> ...
```

Decision tomada:

- `RolBusiness` no debe depender de `RolPermisoBusiness` ni de `UsuarioRolBusiness`.
- La coordinacion compleja de eliminar rol se hace desde `FormRolesPermisos`, porque el Form ya tiene acceso a los tres Business necesarios.

Flujo actual para eliminar rol desde UI:

1. Obtener rol seleccionado.
2. Consultar usuarios asociados al rol con `UsuarioRolBusiness`.
3. Desasociar cada usuario del rol.
4. Consultar permisos asociados al rol con `RolPermisoBusiness`.
5. Desasociar cada permiso del rol.
6. Eliminar el rol con `RolBusiness.EliminarRol`.
7. Refrescar TreeViews y limpiar campos.

Esto evita relaciones huerfanas y evita romper capas con dependencias circulares.

## FormRolesPermisos

Funcionalidades implementadas:

- `tvUsuarios` muestra solo usuarios activos.
- Al seleccionar usuario:
  - se llenan los datos del groupBox de usuario seleccionado.
  - se carga `tvRolesPermisosUsuario` como arbol:

```text
Usuario
  Rol
    Permiso
```

- Al seleccionar rol:
  - se llenan `txtIdRol` y `txtNombreRol`.
  - se carga `tvPermisosPorRol` como arbol:

```text
Rol
  Permiso
```

- Al seleccionar permiso:
  - se llenan `txtIdPermiso` y `txtNombrePermiso`.

- Botones implementados:
  - Alta rol
  - Modificar rol
  - Eliminar rol
  - Asignar rol a usuario
  - Quitar rol a usuario
  - Asignar permiso a rol
  - Quitar permiso a rol

## UI de roles

Se separo visualmente:

- GroupBox general `Rol`
- GroupBox `Rol seleccionado`
  - `txtIdRol`
  - `txtNombreRol`
  - botones `Modificar` y `Eliminar`
- GroupBox `Agregar Rol`
  - `txtNombreAltaRol`
  - boton `Alta`

Detalle:

- `txtNombreRol` queda editable para poder modificar el nombre del rol seleccionado.
- Al seleccionar un rol, `txtNombreRol` se completa con el nombre actual.

## Refrescos importantes

Cuando se asigna o quita un permiso a un rol:

- se refresca `tvPermisosPorRol`
- tambien se refresca `tvRolesPermisosUsuario` si hay un usuario seleccionado

Cuando se asigna o quita un rol a un usuario:

- se refresca `tvRolesPermisosUsuario`

Cuando se modifica un rol:

- se refresca `tvRoles`
- se refresca `tvPermisosPorRol`
- se refresca `tvRolesPermisosUsuario` si hay usuario seleccionado

Cuando se elimina un rol:

- se desasocian primero usuarios y permisos
- se elimina el rol
- se limpian campos de rol
- se refrescan los TreeViews relevantes

## Pendientes posibles

- Revisar si se quiere impedir eliminar el rol `Admin`.
- Implementar eliminar/modificar usuarios en `FormUsuarios`, si corresponde.
- Revisar warnings CA2200 por `throw ex` en clases existentes.
- Evaluar si conviene mostrar mensajes mas especificos cuando se intenta asignar duplicados.
- Revisar si `Program.cs` debe iniciar en login/menu en lugar de `FormRolesPermisos`.

## Ultima verificacion

La solucion compilo correctamente con:

```powershell
dotnet build .\Libreria\Libreria.sln
```

Resultado mas reciente:

- `0` errores
- `0` advertencias

