# Proyecto: UserManagerApp

## 📌 Descripción

Este proyecto es parte de una **prueba de conocimientos** en desarrollo de software con arquitectura en capas utilizando .NET. Se desarrolló un sistema completo para la **gestión de usuarios**, que incluye creación, edición, eliminación, consulta y búsqueda en tiempo real.

---

## 🏗 Arquitectura por Capas

### 🔹 Capa de Presentación – `UserManagerApp.Web`
- Vistas Razor para formularios de ingreso y gestión.
- SweetAlert2 para validaciones interactivas y notificaciones.

### 🔹 Capa de Negocio / API REST – `UserManagerApp`
- Controladores RESTful con operaciones CRUD.
- Comunicación con capa de datos usando servicios.

### 🔹 Capa de Datos – `UserManagerApp.Data`
- Acceso a base de datos mediante Dapper.
- Uso de stored procedures (SP), vistas y scripts SQL.

---

## 🧑‍💻 Funcionalidades

### Página de Registro de Usuario
- 📄 Campo: Nombre
- 📅 Campo: Fecha de nacimiento
- 🚻 Campo: Género (DropDownList dinámico)

### Página de Consulta / Gestión
- 📋 Grilla con usuarios registrados
- ✏️ Editar en línea
- 🗑️ Eliminar con confirmación
- 🔍 Búsqueda en tiempo real por nombre

---

## 🗃️ Base de Datos

El sistema utiliza SQL Server como motor de base de datos.  
Se requiere ejecutar previamente los scripts de:

- Creación de tablas
- Procedimientos almacenados (SP)
- Vistas
- Datos de prueba

Toda esta información se encuentra disponible en el siguiente repositorio:

🔗 [Repositorio de base de datos - UserManagerApp_DB](https://github.com/halcondorado123/UserManagerApp_DB)

En dicho repositorio encontrarás más detalles sobre la estructura, configuraciones y secuencia de ejecución de los scripts necesarios.

---

## 🚀 Cómo ejecutar el proyecto

### 1️⃣ Configurar proyectos de inicio en Visual Studio

- Haz clic derecho sobre la solución `UserManagerApp`
- Selecciona **"Configurar proyectos de inicio..."**
- Marca la opción: `Varios proyectos de inicio`
- Establece **Acción: Inicio** para:
  - `UserManagerApp` (API)
  - `UserManagerApp.Web` (Frontend Razor)
- Haz clic en **Aceptar**

📷 Imágenes de referencia:

![Paso 1 - Clic derecho a solución](./assets/configurar-proyectos.png)  
![Paso 2 - Varios proyectos de inicio](./assets/proyectos-inicio.png)

---

## ✅ Validaciones Implementadas

- 🧠 Validación de edad con JavaScript (entre 2 y 95 años)
- ✅ Validación de formularios con `ModelState` en servidor
- 🚨 Alertas interactivas con SweetAlert2

---

## 🧠 Tecnologías utilizadas

- ASP.NET Core 6+
- Razor Pages
- ASP.NET Web API
- Dapper
- SQL Server
- Bootstrap 5
- JavaScript y jQuery
- SweetAlert2

---

## 🧑 Desarrollador

**Jhonattan Halcón Casallas Felipe**

- 📧 [falconfelipedeveloper@gmail.com](mailto:falconfelipedeveloper@gmail.com)
- 🔗 [linkedin.com/in/jhonattanhalconcasallasfelipe](https://www.linkedin.com/in/jhonattanhalconcasallasfelipe/)
- 💻 [github.com/halcondorado123](https://github.com/halcondorado123)

---

## 📜 Licencia

Este proyecto fue desarrollado como parte de una **prueba de conocimientos técnicos**. Su propósito es educativo y demostrativo.
