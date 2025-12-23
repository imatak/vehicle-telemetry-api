# Vehicle Telemetry API
## A simple back-end system built with ASP.NET Core (.NET 8) that receives, stores, and retrieves vehicle telemetry data.
The project demonstrates clean architecture, async programming, DTO usage, EF Core integration, background processing, and basic unit testing.

## Technology Stack

.NET 8 (LTS) — ASP.NET Core Web API

Entity Framework Core 8 — In-Memory Database

xUnit — Unit Testing

Swagger / OpenAPI — API documentation

Angular (optional frontend) — Simple telemetry viewer

## Requirements

.NET SDK 8.0.x

Tested with: 8.0.416

(Optional Frontend)

Node.js (LTS)

Angular CLI (latest)

Verify .NET installation:

dotnet --version

## Solution Structure
```
vehicle-telemetry-api
│
├── VehicleTelemetryApi/            # ASP.NET Core Web API
│   ├── Controllers/
│   ├── Services/
│   ├── Data/
│   ├── Models/
│   ├── Background/
│   ├── DTOs/
│   ├── Program.cs
│   └── VehicleTelemetryApi.csproj
│
├── VehicleTelemetryApi.Tests/      # Unit tests (xUnit)
│   └── Services/
│       └── TelemetryServiceTests.cs
│
└── VehicleTelemetryApi.sln
```
## How to Run the API

From the solution root:
```
dotnet restore
dotnet run --project VehicleTelemetryApi
```

The API will start on:

https://localhost:5000


Swagger UI:

https://localhost:5000/swagger

## API Endpoints
### POST Telemetry Data

POST /api/v1/telemetry

### Example request body:
```
{
"deviceId": "11111111-1111-1111-1111-111111111111",
"timestamp": "2025-01-01T12:00:00Z",
"engineRPM": 2500,
"fuelLevelPercentage": 75,
"latitude": 45.815,
"longitude": 15.981
}
```

Response

- 201 Created on success

- 400 Bad Request on validation errors

## GET Latest Telemetry for Device

GET /api/v1/telemetry/{deviceId}/latest

Example:

GET /api/v1/telemetry/11111111-1111-1111-1111-111111111111/latest


Responses

- 200 OK — latest telemetry record

- 404 Not Found — no data for device

## Background Processing

A background service runs every minute and simulates sending the latest telemetry records to the cloud by logging messages:

- Sending data to Cloud for Device {DeviceId}


- This demonstrates usage of IHostedService.

## Running Unit Tests

From the solution root:
```
dotnet test
```

- Tests are implemented using xUnit

- EF Core In-Memory database is used for isolation

## Architectural Decisions

- Layered architecture (Controllers → Services → Data)

- DTOs are used to separate API contracts from domain models

- Async/await is used for all database operations

- Dependency Injection is used throughout the application

- EF Core In-Memory Database simplifies setup while maintaining realistic data access patterns

- Unit tests are placed in a separate project to keep production code clean

## Notes

- This project is intended as a technical assignment and focuses on code clarity, structure, and best practices.