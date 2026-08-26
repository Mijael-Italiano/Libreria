# 📚 Sistema de Gestión para Librería

Sistema de gestión comercial desarrollado en **C# y .NET 8** como Trabajo Final de la carrera **Analista Programador** en la Universidad Abierta Interamericana (UAI).

La aplicación centraliza la administración de una librería mediante módulos de **ventas y facturación, inventario, clientes, productos, usuarios, roles y permisos, auditoría, reportes y dashboards**, integrando distintos procesos de negocio dentro de una única solución.

El proyecto fue desarrollado con una **arquitectura multicapa**, separando presentación, lógica de negocio, persistencia, entidades y servicios específicos.

---

## ⚙️ Funcionalidades principales

### 🛒 Ventas y facturación

- Registro y administración de ventas.
- Selección de clientes y productos.
- Manejo de múltiples ítems por operación.
- Utilización de distintos medios de pago.
- Actualización del stock asociada a las operaciones.
- Modificación y anulación de ventas.
- Restitución de stock ante anulaciones.
- Generación de comprobantes de venta en formato PDF.

### 📦 Productos e inventario

- Administración de productos.
- Gestión de categorías, marcas y colores.
- Control y actualización de stock.
- Validaciones relacionadas con disponibilidad de productos.
- Integración del inventario con el proceso de ventas.

### 👥 Clientes

- Alta y administración de clientes.
- Asociación de clientes con operaciones comerciales.
- Consulta de información utilizada por los módulos de ventas y reportes.

### 🔐 Usuarios, roles y permisos

- Autenticación de usuarios.
- Administración de usuarios y roles.
- Asignación de permisos.
- Control de acceso a funcionalidades según permisos.
- Manejo de sesión del usuario.
- Bloqueo de usuarios luego de múltiples intentos fallidos de autenticación.

### 📊 Dashboards y reportes

El sistema incluye dashboards orientados al análisis de la actividad comercial, permitiendo consultar información en diferentes períodos.

Entre los indicadores disponibles se encuentran:

- Ventas diarias.
- Ventas semanales.
- Ventas mensuales.
- Ventas anuales.
- Facturación.
- Cantidad de operaciones.
- Productos vendidos.
- Información por cliente.
- Información por categoría.
- Información por marca.
- Distribución de ventas según distintos criterios.

### 📝 Auditoría

El sistema incorpora una bitácora para registrar eventos relevantes y facilitar la trazabilidad de las operaciones realizadas por los usuarios.

### 💾 Backup y restauración

- Generación de backups de los datos del sistema.
- Restauración de información desde backups existentes.
- Backups de demostración incluidos en el repositorio para permitir probar esta funcionalidad.

---

## 🏗️ Arquitectura

La solución está organizada en múltiples proyectos con responsabilidades diferenciadas:

```text
Libreria.sln
│
├── Libreria.UI
├── Libreria.Business
├── Libreria.Data
├── Libreria.Entity
├── Libreria.Seguridad
├── Libreria.Sesion
├── Libreria.AuditoriaData
└── Libreria.Documentos
```

### Responsabilidades principales

| Proyecto | Responsabilidad |
| --- | --- |
| **Libreria.UI** | Interfaz gráfica y comunicación con el usuario |
| **Libreria.Business** | Reglas y lógica de negocio |
| **Libreria.Data** | Acceso y persistencia de datos |
| **Libreria.Entity** | Entidades y modelos utilizados por el sistema |
| **Libreria.Seguridad** | Funcionalidades relacionadas con usuarios y seguridad |
| **Libreria.Sesion** | Administración de la sesión del usuario |
| **Libreria.AuditoriaData** | Persistencia y gestión de la auditoría |
| **Libreria.Documentos** | Generación y administración de documentos |

Esta separación permite mantener diferenciadas las responsabilidades de presentación, negocio, persistencia y servicios específicos.

---

## 🧩 Modelo funcional

El sistema representa diferentes procesos relacionados entre sí dentro de la operación de una librería:

```text
Usuarios
   │
   ├── Roles
   │    └── Permisos
   │
   ▼
Gestión del sistema
   │
   ├── Clientes
   ├── Productos
   │    ├── Categorías
   │    ├── Marcas
   │    └── Colores
   │
   ├── Inventario
   │
   └── Ventas
        ├── Ítems
        ├── Medios de pago
        ├── Actualización de stock
        └── Comprobante PDF
              │
              ▼
       Reportes y dashboards
```

---

## 💻 Tecnologías utilizadas

- **C#**
- **.NET 8**
- **Windows Forms**
- **Programación Orientada a Objetos**
- **LINQ**
- **LINQ to XML**
- **XML**
- **QuestPDF**
- **Windows Forms DataVisualization**
- **Git**
- **GitHub**

---

## 💾 Persistencia

La aplicación utiliza persistencia local mediante archivos **XML**, manipulados desde C# utilizando **LINQ to XML**.

La lógica de persistencia se encuentra separada de la interfaz y de la lógica de negocio mediante el proyecto `Libreria.Data`, manteniendo diferenciadas las responsabilidades de cada capa.

El sistema incluye datos ficticios de demostración para facilitar la ejecución y exploración de sus funcionalidades.

---

## 📄 Generación de comprobantes

Las ventas pueden generar comprobantes en formato **PDF**, permitiendo representar documentalmente la información correspondiente a cada operación.

El repositorio incluye algunos comprobantes generados por la aplicación como ejemplos del resultado producido por el sistema.

---

## 🚀 Ejecución del proyecto

### Requisitos

- Windows
- .NET 8 SDK
- Visual Studio 2022 o posterior

### Instalación

1. Clonar el repositorio:

```bash
git clone https://github.com/Mijael-Italiano/Libreria.git
```

2. Abrir la solución:

```text
Libreria.sln
```

3. Verificar que `Libreria.UI` se encuentre configurado como proyecto de inicio.

4. Compilar y ejecutar la solución desde Visual Studio.

---

## 🔑 Credenciales de demostración

Para acceder al sistema con permisos de administrador:

```text
Usuario: Admin
Contraseña: 1234
```

Estas credenciales corresponden exclusivamente al entorno de demostración incluido en el proyecto.

Todos los clientes, productos, ventas y demás datos incluidos en el repositorio son **ficticios** y fueron creados únicamente con fines académicos y de demostración.

---

## 💾 Datos y backups de demostración

El repositorio incluye datos ficticios que permiten utilizar el sistema sin necesidad de cargar manualmente información desde cero.

También se incluyen backups de ejemplo para permitir probar las funcionalidades de **backup y restauración** implementadas en la aplicación.

---

## 📖 Documentación

El proyecto cuenta con documentación académica complementaria que describe su análisis y diseño, incluyendo:

- Objetivos del sistema.
- Alcance funcional.
- Actores.
- Casos de uso.
- Precondiciones y postcondiciones.
- Flujos principales.
- Flujos alternativos.
- Reglas y comportamiento esperado de las distintas funcionalidades.

La documentación completa se encuentra disponible en la carpeta:

```text
/Docs
```

---

## 🎓 Contexto académico

Este sistema fue desarrollado como **Trabajo Final de la carrera Analista Programador de la Universidad Abierta Interamericana (UAI)**.

El objetivo del proyecto fue integrar los conocimientos adquiridos durante la carrera mediante el análisis, diseño e implementación de un sistema que representara procesos y reglas de negocio dentro de un dominio concreto.

El desarrollo involucró tanto el **modelado funcional del sistema** como su implementación técnica, incluyendo arquitectura multicapa, programación orientada a objetos, persistencia de datos, reglas de negocio, gestión de usuarios y permisos, generación de documentos, auditoría y visualización de información.

---

## 👤 Autor

**Bruno Mijael Italiano**

Analista Programador — Universidad Abierta Interamericana
