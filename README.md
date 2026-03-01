# TenantFlow 👋

![.NET](https://img.shields.io/badge/.NET-8-blue?style=for-the-badge&logo=dotnet&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-13-blue?style=for-the-badge&logo=postgresql&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

**Multi-tenant SaaS platform backend** built with .NET Core, demonstrating clean architecture, EF Core, and subscription management.

---

## Features

- Multi-tenant architecture with `TenantId` isolation
- Clean architecture (Domain, Application, Infrastructure, API)
- Entity Framework Core for persistence
- Dapper for optimized queries
- Subscription management per tenant
- Basic authentication and role-based authorization

---

## Tech Stack

- C# / .NET 8
- Entity Framework Core
- Dapper
- PostgreSQL
- ASP.NET Core Web API
- Swagger for API documentation
- FluentValidation 

---

## Getting Started

1. Clone the repo:
```bash
git clone https://github.com/migbrit/TenantFlow.git
```

2. Navigate to the API project:
```bash
cd TenantFlow/TenantFlow.Api
```

3. Configure your connection string in appsettings.json:
```bash
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=TenantFlowDb;Username=postgres;Password=YourPassword"
}
```

4. Run the initial migration to create the database:
```bash
dotnet ef database update -p ../TenantFlow.Infrastructure -s .
```

5. Run the API:
```bash
dotnet run
```

6. Open Swagger at https://localhost:{PORT}/swagger to explore endpoints.

## Project Structure

```text
TenantFlow.sln
├── TenantFlow.Api            # ASP.NET Core Web API
├── TenantFlow.Application    # Application layer: services, use-cases
├── TenantFlow.Domain         # Domain layer: entities, value objects, interfaces
└── TenantFlow.Infrastructure # EF Core DbContext, repositories
```

## Contributing

Contributions are welcome! Open issues or submit PRs.
Please follow clean architecture principles when extending functionality.



## Notes

This project is designed as a demonstration of clean architecture and multi-tenant SaaS patterns.
It’s a solid starting point for learning, building more complex SaaS systems, or showcasing your backend skills in a professional portfolio.
