[![Donate](https://img.shields.io/badge/-%E2%99%A5%20Donate-%23ff69b4)](https://hmlendea.go.ro/fund.html) [![Latest Release](https://img.shields.io/github/v/release/hmlendea/api-scanner-logger)](https://github.com/hmlendea/api-scanner-logger/releases/latest) [![Build Status](https://github.com/hmlendea/api-scanner-logger/actions/workflows/dotnet.yml/badge.svg)](https://github.com/hmlendea/api-scanner-logger/actions/workflows/dotnet.yml)

# api-scanner-logger

A minimal ASP.NET Core service that records incoming HTTP requests and immediately rejects them.

This project is useful as a decoy endpoint for scanner traffic, allowing you to capture request metadata (including headers) without exposing real API behavior.

## What it does

- Logs every incoming request through `NuciLog`
- Captures:
	- Client IP address
	- HTTP method
	- Request path
	- Query string
	- Request headers
- Serializes headers in this format:

	`Key1:Val1;Key2:Val2;`

- Returns `403 Forbidden` for every request

## Tech stack

- .NET (`net10.0`)
- ASP.NET Core
- [NuciLog](https://www.nuget.org/packages/NuciLog)
- [NuciAPI.Middleware](https://www.nuget.org/packages/NuciAPI.Middleware)

## Requirements

- .NET SDK

Check installed version:

```bash
dotnet --version
```

## Getting started

1. Clone the repository
2. Restore dependencies
3. Run the service

```bash
dotnet restore
dotnet run
```

By default, ASP.NET Core URLs depend on your local launch/profile setup. You can set an explicit URL if needed:

```bash
ASPNETCORE_URLS=http://0.0.0.0:5000 dotnet run
```

## Build and test

```bash
dotnet build
dotnet test
```

## Logging behavior

Each request is logged under operation name `HttpRequest` with the following keys:

- `IpAddress`
- `Method`
- `Path`
- `QueryString`
- `Headers`

Example headers value:

```text
Host:example.com;User-Agent:curl/8.7.1;Accept:*/*;
```

## Configuration

Logging is configured via `appsettings.json` under:

```json
{
	"nuciLoggerSettings": {
		"logFilePath": "logfile.log",
		"isFileOutputEnabled": true
	}
}
```

Current default output file:

- `logfile.log`

## Project structure

- `Program.cs` - Host bootstrap
- `Startup.cs` - Service registration and middleware pipeline
- `Middleware/RequestLoggingMiddleware.cs` - Request capture and `403` response
- `Logging/MyOperation.cs` - Log operation names
- `Logging/MyLogInfoKey.cs` - Log field keys
- `ServiceCollectionExtensions.cs` - DI and logging settings wiring

## Security notes

- This service intentionally denies all requests.
- Logged headers can contain sensitive data (for example authorization tokens). Consider redacting sensitive values before using logs in shared systems.

## Development

### Prerequisites

- .NET SDK compatible with the target framework

### Build

```bash
dotnet build
```

### Run

```bash
dotnet run
```

### Test

There is currently no test project in this repository.

If you add one later, run:

```bash
dotnet test
```

## Contributing

Contributions are welcome.

When contributing:

- keep the project cross-platform
- preserve the existing public API unless a breaking change is intentional
- keep changes focused and consistent with the current coding style
- update documentation when behavior changes
- include tests for new behavior when a test project is available

## License

Licensed under the GNU General Public License v3.0 or later.
See [LICENSE](./LICENSE) for details.
