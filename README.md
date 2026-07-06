# Asset Checkout System

An internal company asset checkout portal built with **Angular**, **.NET 8 Web API**, and **SQL Server**.

Employees can request company-owned equipment, asset managers can approve requests and assign assets, and admins can manage users and permissions.

## Live Demo

| | |
|---|---|
| **Frontend** | https://assetcheckoutportal.vercel.app/ |
| **API (Swagger)** | https://assetcheckoutapi.up.railway.app/swagger |

**Seeded Accounts**

| Email | Role |
|---|---|
| admin@test.com | Admin |
| manager@test.com | Asset Manager |
| employee@test.com | Employee |

## Tech Stack

- **Frontend** — Angular
- **Backend** — .NET 8 Web API
- **Database** — SQL Server (Entity Framework Core, code-first migrations)
- **Auth** — JWT access tokens + HTTP-only refresh token cookies

## Getting Started

### Prerequisites
- Node.js & Angular CLI
- .NET 8 SDK
- SQL Server

### Backend

1. Set the required environment variables (see below)
2. Run migrations: `dotnet ef database update`
3. Start the API: `dotnet run`

### Frontend

1. Set `BackendURL` in your environment config
2. `npm install`
3. `ng serve`

## Environment Variables

### Required

| Variable | Description | Example |
|---|---|---|
| `JwtKey` | JWT signing secret | `SuperSecretDevelopmentKey1234567890` |
| `FrontendURL` | Allowed CORS origin | `https://localhost:4200` |
| `BackendURL` | API base URL used by the client | `https://localhost:7035/api` |

### Optional

| Variable | Description | Default |
|---|---|---|
| `AccessTokenExpirationMinutes` | Access token lifetime | `15` |
| `RefreshTokenExpirationDays` | Refresh token lifetime | `7` |
