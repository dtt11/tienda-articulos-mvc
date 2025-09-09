## 🛒 App Web ASP.NET Core MVC – Gestión de Artículos de Tienda
📌 Descripción

Este proyecto implementa una aplicación web para la gestión de artículos de una tienda, desarrollada con ASP.NET Core MVC 8.0, Entity Framework Core y SQL Server.

La aplicación permite a los usuarios realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar) sobre los productos, almacenando toda la información en una base de datos relacional.

🚀 Funcionalidades

Crear artículos con nombre, precio, categoría y cantidad en inventario.

Listar artículos en un catálogo con paginación y filtrado.

Editar artículos para actualizar su información.

Eliminar artículos con confirmación de seguridad.

Validación de datos en formularios mediante anotaciones (DataAnnotations).

Conexión con SQL Server usando Entity Framework Core.

Arquitectura MVC para separar presentación, lógica y acceso a datos.

⚙️ Requisitos de software

Visual Studio Community 2022

.NET 8.0

SQL Server (con seguridad integrada de Windows o credenciales definidas en appsettings.json)

Herramientas de migración de Entity Framework Core (dotnet ef)

🏗️ Arquitectura del sistema

El sistema sigue el patrón Modelo-Vista-Controlador (MVC):

Modelo (Model): Entidades y contexto de base de datos gestionados con EF Core.

Vista (View): Interfaz de usuario construida con Razor y Bootstrap.

Controlador (Controller): Lógica que conecta el modelo con la vista y gestiona las operaciones CRUD.

Base de Datos (SQL Server): Almacenamiento persistente de los artículos.

🗄️ Entidades principales

Articulo → Representa un producto en la tienda (Id, Nombre, Precio, Categoría, Cantidad).

ApplicationDbContext → Contexto de Entity Framework Core que administra la conexión y migraciones.

▶️ Ejecución del sistema

Configurar la base de datos

Revisar el archivo appsettings.json y ajustar la cadena de conexión a SQL Server.

Ejecutar las migraciones con:

dotnet ef database update


Ejecutar la aplicación

Abrir el proyecto en Visual Studio 2022.

Ejecutar con Ctrl + F5 o con el botón Iniciar.

La aplicación estará disponible en el navegador en https://localhost:xxxx.

Probar el CRUD de artículos

Crear un artículo nuevo.

Consultar el catálogo de artículos.

Editar los detalles de un producto.

Eliminar artículos del inventario.

🧑‍💻 Autor

Daniel Tapia Traña – Diplomado en Informática
