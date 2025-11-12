# Digital Marketplace + Live Streaming Platform

A comprehensive microservices-based platform for selling digital products with real-time live streaming capabilities.

## 🏗️ Architecture

- **Backend**: .NET Core 8.0 (12 microservices)
- **Frontend**: React.js 18+ with TypeScript
- **Database**: PostgreSQL (per service) + Redis + Elasticsearch
- **Message Broker**: Apache Kafka
- **API Gateway**: YARP
- **Real-Time**: SignalR
- **Communication**: REST (external), gRPC (internal), Kafka (events)

## 📁 Project Structure

This project uses a **monorepo** approach with a single solution file.

```
digital-marketplace-microservices/
├── DigitalMarketplace.sln          # Main solution
├── services/                       # 12 microservices
├── shared/                        # Shared libraries
├── frontend/                       # React.js app
└── infrastructure/                 # Docker, K8s, scripts
```

See `Documentation/PROJECT-STRUCTURE.md` for detailed structure.

## 🚀 Quick Start

### Prerequisites
- .NET 8.0 SDK
- Node.js 18+
- Docker Desktop
- Visual Studio 2022 or VS Code

### Setup
```bash
# Clone repository
git clone <repository-url>
cd digital-marketplace-microservices

# Build solution
dotnet build DigitalMarketplace.sln

# Start infrastructure (PostgreSQL, Redis, Kafka)
docker-compose up -d

# Run services
dotnet run --project services/UserService/UserService.csproj
```

## 📚 Documentation

All documentation is located in the `Documentation/` folder:

- [ROADMAP.md](Documentation/ROADMAP.md) - Complete implementation roadmap (18 weeks)
- [PROJECT-STRUCTURE.md](Documentation/PROJECT-STRUCTURE.md) - Project structure details
- [SOLUTION-STRUCTURE-GUIDE.md](Documentation/SOLUTION-STRUCTURE-GUIDE.md) - Monorepo vs Polyrepo guide
- [DATABASE-SELECTION.md](Documentation/DATABASE-SELECTION.md) - Database recommendations
- [API-GATEWAY-COMPARISON.md](Documentation/API-GATEWAY-COMPARISON.md) - YARP vs Ocelot
- [GRPC-GUIDE.md](Documentation/GRPC-GUIDE.md) - gRPC implementation guide
- [TECHNOLOGY-STACK.md](Documentation/TECHNOLOGY-STACK.md) - Technology stack details
- [TODO.md](Documentation/TODO.md) - Quick reference checklist

## 🎯 Microservices

1. **API Gateway** - YARP (routing, authentication)
2. **User Service** - Authentication, profiles
3. **Product Service** - Digital products catalog
4. **Order Service** - Order processing
5. **Payment Service** - Payment processing
6. **Streaming Service** - Live streaming (SignalR)
7. **Chat Service** - Real-time chat (SignalR)
8. **Media Service** - Video/image management
9. **Notification Service** - Notifications
10. **Analytics Service** - Analytics & metrics
11. **Search Service** - Search (Elasticsearch)
12. **Subscription Service** - Subscription management

## 🎓 Design Patterns

- API Gateway Pattern
- Service Discovery
- Database per Service
- Event-Driven Architecture
- Saga Pattern
- CQRS
- Circuit Breaker
- Outbox Pattern
- WebSocket Pattern (SignalR)
- And 10+ more patterns

## 📅 Development Status

- ✅ Project structure setup
- ⏳ Phase 1: Foundation & Setup (in progress)
- ⏳ Phase 2-13: See ROADMAP.md

## 🛠️ Technology Stack

### Backend
- .NET Core 8.0
- ASP.NET Core Web API
- Entity Framework Core
- SignalR
- YARP (API Gateway)
- Polly (Resilience)
- Kafka (Events)

### Frontend
- React 18+
- TypeScript
- Redux Toolkit / Zustand
- Axios
- @microsoft/signalr

### Infrastructure
- PostgreSQL
- Redis
- Elasticsearch
- Kafka
- Docker
- Kubernetes

## 📖 Learning Path

This project is designed for learning microservices architecture with:
- 20+ design patterns
- Real-world scenarios
- Step-by-step implementation
- Comprehensive documentation

## 🤝 Contributing

This is a learning project. Follow the roadmap in `Documentation/ROADMAP.md` for implementation.

## 📝 License

Educational project for learning microservices architecture.

---

**Status**: 🚧 In Development
**Timeline**: 18 weeks (see [Documentation/ROADMAP.md](Documentation/ROADMAP.md))

