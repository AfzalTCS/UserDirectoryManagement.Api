An ASP.NET Core 8 Web API project for managing users in a directory. This application demonstrates a layered architecture (API → Service → Repository → Database) with support for JWT authentication, Swagger documentation, and Docker deployment.

User CRUD operations (Add, View, Update, Delete)

JWT Authentication for secure endpoints

Swagger UI integration for API testing

Layered architecture (Controller → Service → Repository → Database)

Entity Framework Core for database access

**Tech Stack**

ASP.NET Core 8 Web API

C#

Entity Framework Core

SQL Server

Swagger (Swashbuckle)

JWT Authentication

**Project Structure **
UserDirectory.Api/        → API Layer (Controllers, Swagger)
UserDirectory.Service/    → Business Logic Layer
UserDirectory.Repository/ → Data Access Layer
UserDirectory.Domain/     → Entities & Models
UserDirectory.Tests/      → Unit Tests (MSTest + Moq)
