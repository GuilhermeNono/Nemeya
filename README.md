# Identity Provider (Idp)

## Overview
Identity Provider (Idp) is a .NET 8-based ASP.NET Core application that manages identity, authentication, and access control using JWT. It is designed with Domain-Driven Design (DDD) principles and supports containerized deployment with Docker.

---

## Features
- JWT-based authentication and authorization
- Modular structure using Domain-Driven Design
- SQL Server integration for data persistence
- Dockerized setup for easy deployment

---

## Getting Started

### Prerequisites
- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/)
- [SQL Server](https://www.microsoft.com/sql-server)

### Run with Docker
1. Build and run the application:
```shell script
docker-compose up --build
```

2. Access the application on:
   - Port `7254` for API
   - Port `1433` for SQL Server

---

## Technologies
- **Framework**: ASP.NET Core 8.0
- **Database**: SQL Server
- **Containerization**: Docker
- **Authentication**: JWT

---

## Project Structure
- **Idp.Api**: API layer to expose endpoints.
- **Idp.Application**: Business logic and commands/queries.
- **Idp.Domain**: Core domain logic and entities.
- **Idp.Infrastructure**: Persistence and database scripts.

---

## License
This project is licensed under the [MIT License](LICENSE).
