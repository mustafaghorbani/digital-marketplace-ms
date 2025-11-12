# Project Structure

## Monorepo Structure

This project uses a **monorepo** approach with a single solution file containing all microservices.

```
digital-marketplace-microservices/
├── DigitalMarketplace.sln          # Main solution file
│
├── services/                       # All microservices
│   ├── ApiGateway/                 # API Gateway (YARP)
│   ├── UserService/                # User authentication & profiles
│   ├── ProductService/             # Product catalog
│   ├── OrderService/               # Order processing
│   ├── PaymentService/             # Payment processing
│   ├── StreamingService/           # Live streaming (SignalR)
│   ├── ChatService/                # Real-time chat (SignalR)
│   ├── MediaService/               # Media file management
│   ├── NotificationService/        # Notifications
│   ├── AnalyticsService/           # Analytics & metrics
│   ├── SearchService/              # Search (Elasticsearch)
│   └── SubscriptionService/        # Subscription management
│
├── shared/                         # Shared libraries
│   ├── Common/                     # Common utilities, extensions
│   ├── Events/                     # Event contracts (Kafka events)
│   └── Contracts/                   # Service contracts, DTOs
│
├── frontend/                       # React.js frontend
│   └── react-app/                  # React application
│
├── infrastructure/                 # Infrastructure as code
│   ├── docker/                     # Dockerfiles
│   ├── kubernetes/                # Kubernetes manifests
│   └── scripts/                    # Deployment scripts
│
├── tests/                          # Test projects
│   ├── UserService.Tests/
│   ├── ProductService.Tests/
│   └── Integration.Tests/
│
├── docker-compose.yml              # Local development
├── .gitignore
└── README.md
```

## Solution Structure

### Main Solution: `DigitalMarketplace.sln`

Contains all service projects and shared libraries:

```
Solution 'DigitalMarketplace'
├── Services
│   ├── ApiGateway
│   ├── UserService
│   ├── ProductService
│   ├── OrderService
│   ├── PaymentService
│   ├── StreamingService
│   ├── ChatService
│   ├── MediaService
│   ├── NotificationService
│   ├── AnalyticsService
│   ├── SearchService
│   └── SubscriptionService
│
└── Shared Libraries
    ├── Common
    ├── Events
    └── Contracts
```

## Project References

### Services Reference Shared Libraries
- ✅ Each service can reference `Common`, `Events`, `Contracts`
- ✅ Services should NOT reference each other directly
- ✅ Communication via HTTP/gRPC/Events

### Example:
```xml
<!-- UserService.csproj -->
<ItemGroup>
  <ProjectReference Include="..\..\shared\Common\Common.csproj" />
  <ProjectReference Include="..\..\shared\Events\Events.csproj" />
  <ProjectReference Include="..\..\shared\Contracts\Contracts.csproj" />
</ItemGroup>
```

## Development Workflow

### Opening the Project
1. Open `DigitalMarketplace.sln` in Visual Studio or VS Code
2. All services and shared libraries are available
3. Set multiple startup projects for local development

### Building
```bash
# Build entire solution
dotnet build DigitalMarketplace.sln

# Build specific service
dotnet build services/UserService/UserService.csproj
```

### Running Services
```bash
# Run specific service
dotnet run --project services/UserService/UserService.csproj

# Or use Docker Compose
docker-compose up
```

## Next Steps

1. ✅ Solution file created
2. ⏳ Create service projects (Phase 1, Task 1.4)
3. ⏳ Create shared libraries (Phase 1, Task 1.1)
4. ⏳ Set up Docker Compose (Phase 1, Task 1.2)
5. ⏳ Configure databases (Phase 1, Task 1.3)

See `ROADMAP.md` for detailed implementation steps.

