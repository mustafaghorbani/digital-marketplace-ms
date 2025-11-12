# 🛠️ Technology Stack Summary

## Backend: .NET Core

### Core Framework
- **.NET 8.0** (or .NET 7.0) - Latest LTS version
- **ASP.NET Core Web API** - REST API framework
- **C#** - Programming language

### Key Libraries
- **Entity Framework Core** - ORM for database access
- **SignalR** - Real-time WebSocket communication
- **Ocelot / YARP** - API Gateway
- **Polly** - Resilience patterns (Circuit Breaker, Retry, Timeout, Bulkhead)
- **Serilog** - Structured logging
- **AutoMapper** - Object-to-object mapping
- **FluentValidation** - Input validation
- **MediatR** - Mediator pattern (optional)
- **MassTransit** - Distributed application framework (Saga, messaging)
- **Confluent.Kafka** - Kafka client for .NET
- **ASP.NET Core Identity** - Authentication and authorization
- **JWT Bearer** - Token-based authentication

### Testing
- **xUnit** - Unit testing framework
- **Moq** - Mocking framework
- **FluentAssertions** - Assertion library
- **Testcontainers** - Integration testing with containers

---

## Frontend: React.js

### Core Framework
- **React 18+** - UI library
- **TypeScript** - Type safety

### Key Libraries
- **React Router** - Client-side routing
- **Redux Toolkit / Zustand** - State management
- **Axios** - HTTP client
- **@microsoft/signalr** - SignalR client for React
- **Material-UI / Ant Design / TailwindCSS** - UI framework
- **React Query / SWR** - Data fetching and caching (optional)
- **Formik / React Hook Form** - Form management

### Testing
- **Jest** - Testing framework
- **React Testing Library** - Component testing

---

## Infrastructure

### Databases
- **PostgreSQL** - Primary database (one per service)
- **Redis** - Caching, sessions, real-time data
- **Elasticsearch** - Search and analytics

### Message Broker
- **Apache Kafka** - Event streaming
- **Confluent.Kafka** - .NET Kafka client

### Service Discovery
- **Consul** - Service discovery and configuration
- **Kubernetes Service Discovery** - Native K8s service discovery

### Monitoring & Observability
- **Prometheus** - Metrics collection
- **Grafana** - Metrics visualization
- **Jaeger** - Distributed tracing
- **Serilog** - Structured logging
- **Seq** - Log aggregation (optional)

### Containerization
- **Docker** - Containerization
- **Docker Compose** - Development orchestration
- **Kubernetes** - Production orchestration

---

## Architecture Patterns

### Communication
- **REST APIs** - Synchronous communication (Frontend → Backend, External APIs)
- **gRPC** - ⭐ **Recommended** for internal service-to-service communication (high performance)
- **SignalR** - Real-time WebSocket communication
- **Kafka** - Asynchronous event-driven communication

### API Gateway
- **YARP** (Yet Another Reverse Proxy) - ⭐ **RECOMMENDED** - Microsoft's reverse proxy with native WebSocket support
- **Ocelot** - Alternative .NET Core API Gateway (mature but limited WebSocket support)

### Resilience
- **Polly** - All resilience patterns (Circuit Breaker, Retry, Timeout, Bulkhead)

### Distributed Transactions
- **MassTransit** - Saga pattern implementation
- **Orchestration-based Saga** - Using MassTransit

---

## Development Tools

### IDE
- **Visual Studio 2022** - Full-featured IDE for .NET
- **VS Code** - Lightweight editor with C# extension
- **Rider** - JetBrains IDE (alternative)

### API Testing
- **Postman** - API testing
- **Swagger UI** - Built-in API documentation
- **Thunder Client** - VS Code extension

### Database Tools
- **pgAdmin** - PostgreSQL administration
- **DBeaver** - Universal database tool
- **Azure Data Studio** - Cross-platform database tool

---

## Why This Stack?

### .NET Core Benefits
- ✅ High performance and scalability
- ✅ Strong typing with C#
- ✅ Excellent tooling and IDE support
- ✅ Built-in dependency injection
- ✅ Comprehensive standard library
- ✅ Strong ecosystem for microservices
- ✅ SignalR for real-time features
- ✅ Cross-platform (Windows, Linux, macOS)

### React.js Benefits
- ✅ Component-based architecture
- ✅ Large ecosystem and community
- ✅ TypeScript for type safety
- ✅ Excellent developer experience
- ✅ Great for building SPAs
- ✅ SignalR client available for React

### Combined Benefits
- ✅ Type safety on both frontend and backend
- ✅ Strong tooling support
- ✅ Modern development practices
- ✅ Production-ready frameworks
- ✅ Excellent real-time capabilities (SignalR)
- ✅ Scalable architecture

---

## Getting Started

1. Install **.NET 8.0 SDK**
2. Install **Node.js 18+** and **npm/yarn**
3. Install **Docker Desktop**
4. Install **Visual Studio 2022** or **VS Code**
5. Follow the roadmap in `ROADMAP.md`

---

**Last Updated**: Based on roadmap requirements
**Project**: Digital Marketplace + Live Streaming Platform

