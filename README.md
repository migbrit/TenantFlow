# TenantFlow

![.NET](https://img.shields.io/badge/.NET-8-blue?style=for-the-badge&logo=dotnet&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-13-blue?style=for-the-badge&logo=postgresql&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

TenantFlow is a backend platform for managing contracts between businesses and their clients, built as a multi-tenant SaaS system. Each tenant operates in full data isolation, with its own users, clients, and contracts.

The project focuses on real-world backend concerns: tenant-scoped data access, role-based authorization, contract lifecycle management, and a clean, maintainable architecture designed to scale.

---

## Why This Project

Most contract management tools are either too generic or tightly coupled to a single business. TenantFlow explores what it takes to build a backend that serves multiple independent businesses on shared infrastructure — safely and reliably.

Key engineering decisions:
- **Tenant isolation via `TenantId` scoping** — no cross-tenant data leakage by design
- **Clean Architecture** — domain logic stays independent of frameworks and infrastructure
- **EF Core + Dapper hybrid** — EF Core for writes and migrations, Dapper for optimized read queries
- **Role-based access per tenant** — users have roles scoped to their tenant, not globally

---

## Core Features

- Multi-tenant architecture with strict data isolation
- Contract lifecycle management (draft → active → expired)
- Role-based authorization per tenant (Admin, Member)
- JWT authentication
- FluentValidation for input validation
- Swagger for API exploration

---

## Tech Stack

- C# / .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- Dapper
- PostgreSQL
- FluentValidation
- Swagger / Scalar

---

## Project Structure
```text
TenantFlow.sln
├── TenantFlow.Api             # HTTP layer: controllers, middleware, DI setup
├── TenantFlow.Application     # Use cases, DTOs, interfaces
├── TenantFlow.Domain          # Entities, value objects, domain exceptions
└── TenantFlow.Infrastructure  # EF Core, repositories, database migrations
```

---

## Getting Started

1. Clone the repo:
```bash
git clone https://github.com/migbrit/TenantFlow.git
cd TenantFlow/TenantFlow.Api
```

2. Configure your connection string in `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=TenantFlowDb;Username=postgres;Password=YourPassword"
}
```

3. Run migrations:
```bash
dotnet ef database update -p ../TenantFlow.Infrastructure -s .
```

4. Run the API:
```bash
dotnet run
```

5. Open Swagger at `https://localhost:{PORT}/swagger`

---
