# Docker Compose Quick Reference

## Starting Infrastructure

```bash
# Start all infrastructure services
docker-compose up -d

# View running containers
docker-compose ps

# View logs
docker-compose logs -f

# View logs for specific service
docker-compose logs -f kafka
```

## Stopping Infrastructure

```bash
# Stop all services
docker-compose down

# Stop and remove volumes (⚠️ deletes all data)
docker-compose down -v
```

## Service Ports

### Databases (PostgreSQL)
- User Service: `localhost:5432`
- Product Service: `localhost:5433`
- Order Service: `localhost:5434`
- Payment Service: `localhost:5435`
- Streaming Service: `localhost:5436`
- Chat Service: `localhost:5437`
- Media Service: `localhost:5438`
- Notification Service: `localhost:5439`
- Analytics Service (TimescaleDB): `localhost:5440`
- Search Service: `localhost:5441`
- Subscription Service: `localhost:5442`

### Other Services
- Redis: `localhost:6379`
- Kafka: `localhost:9092`
- Zookeeper: `localhost:2181`
- Consul: `localhost:8500`
- Elasticsearch: `localhost:9200`
- Jaeger UI: `http://localhost:16686`
- Prometheus: `http://localhost:9090`
- Grafana: `http://localhost:3000` (admin/admin)

## Connection Strings

### PostgreSQL Example
```
Host=localhost;Port=5432;Database=user_service;Username=postgres;Password=postgres
```

### Redis Example
```
localhost:6379
```

### Kafka Example
```
localhost:9092
```

## Health Checks

All services include health checks. Check service health:

```bash
docker-compose ps
```

## Troubleshooting

### Reset Everything
```bash
docker-compose down -v
docker-compose up -d
```

### View Service Logs
```bash
docker-compose logs [service-name]
```

### Access Database
```bash
# Connect to User Service database
docker exec -it postgres-user-service psql -U postgres -d user_service
```

