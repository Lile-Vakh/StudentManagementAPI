# StudentManagementAPI

## What is this?
This is a simple ASP.NET Core Web API for managing students' information. I have used Entity Framework Core 
(Code First model), DTOs, AutoMapper, FluentValidation and Entity Framework Core (Code First).

## Technologies
- .NET 9 / ASP.NET Core
- Entity Framework Core
- AutoMapper
- FluentValidation
- SQL Server (using Docker container)
- Swagger

## Problem
This API allows clients to do basic CRUD operations for students:
- Add, read, update, delete students
- Validate data (required fields, age >= 16, unique email)
- Pagination and simple search
- Safe data transfer with DTOs (no sensitive fields now, but safer for future)
- Global error handling

## Endpoints
| Method | Endpoint               | Description            |
|--------|------------------------|------------------------|
| GET    | /api/students          | List of students       |
| GET    | /api/students/{id}     | Get one student        |
| POST   | /api/students          | Add new student        |
| PUT    | /api/students/{id}     | Update student         |
| DELETE | /api/students/{id}     | Delete student         |

### Query Parameters
- `search` - search by first or last name (`?search=Lile`)
- `pageNumber` - page number for pagination
- `pageSize` - page size for pagination
