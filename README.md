
# BookRadar - Prueba Técnica Juan Hernández

Se realiza prueba técnica en .NET 8, la cual consulta libros por busqueda de autor consumiendo un endpoint publico, este muestra los resultados en una tabla, además registra el historial en SQL Server en este caso de manera local. Este proyecto fue realizado siguiendo una estructura Hexagonal, aplicando conceptos CQRS, y las bases de MVC.

## Tecnologías utilizadas
* ASP.NET Core MVC + Razor
* EF Core (SQL Server)
* MediatR (CQRS con handlers “primary constructor”)
* Mapster (configs por capa, *MappingConfig)
* Bootstrap 5 y SweetAlert2

## Estructura del proyecto
* BookRadar.Domain
* BookRadar.Application
* BookRadar.Infrastructure
* BookRadar.Web

## Requisitos
* .NET SDK 8.0
* SQL Server (LocalDB)
* Conexión a internet para Open Library

## Paso a Paso ejecución
## 1. Clonar repositorio
Se debe clonar este repositorio para ejecutar el proyecto de manera local.

## 2. Configurar cadena de Conexión
Para este ejercicio se utilizó una base de datos local en SQL Server por lo que la cadena de conexión propuesta es:

{
  "ConnectionStrings": {
    "Default": "Server=(localdb)\\MSSQLLocalDB;Database=BookRadarDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}


## 3. Migraciones
Se realiza migración siguiendo los conceptos de codefirst

dotnet tool install --global dotnet-ef --source https://api.nuget.org/v3/index.json

dotnet ef database update -p src/BookRadar.Infrastructure -s src/BookRadar.Web

## 4. Ejecutar procedimiento almacenado en base de datos
Una vez realizada la migración es necesario ingresar a SQL Serve a la base de datos de BookRadarDb.Dev y ejecutar el siguiente procedimiento almacenado: "sp_InsertSearchHistory.sql" ubicado en la carpeta script del proyecto.

## 5. Ejecutar
Para ejecutar el proyecto, se debe configurar como proyecto de arranque a "BookRadar.Web"

* Comando utiles
Si se realizan modificaciones en los modelos en el proyecto, es recomendable seguir los siguientes comandos para las migraciones y la actualización

dotnet ef migrations add <Name> -p src/BookRadar.Infrastructure -s src/BookRadar.Web -o Persistence/Migrations

dotnet ef database update -p src/BookRadar.Infrastructure -s src/BookRadar.Web


## Decisiones técnicas
* Arquitectura Hexagonal
Para el proyecto se decidió utilizar una arquitectura hexagonal, valorando la fuerte independencia de los componenetes, así como el buen manejo de la lógica entre capas. A esto, sumado la integración de CQRS que permite el correcto uso de commands y queries agregando robustes y escalabilidad al proyecto.

* Mapster
Se utilizó el nuget de Mapster para evitar hacer mapeos manuales, en su lugar se realizaron MappingConfigs generales para la realización de los mapeos por capas.

* Bootstrap y SweetAlert2
Se utilizó Bootstrap para el maquetado y para dar una estetica visual mas agradable, se utilizó el color azul, usual en las bibliotecas digitales como Amazón, además se representaron con iconos las acciones de los botones para que la interacción sea más rápida por parte del usuario. Se hizo uso de tablas y un botón de volver para una interacción más fluida de la plataforma.

## Mejoras pendientes
* Registro de logs
* Paginaciones
* Diferentes filtros (Nombre libro, año, nombre editorial)
* Cliente (Experiencia personalizada)
