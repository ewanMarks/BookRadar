# BookRadar - Prueba Técnica

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
