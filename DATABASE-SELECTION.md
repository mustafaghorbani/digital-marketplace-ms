# Database Selection Guide for Microservices

## Overview

Following the **Database per Service** pattern, each microservice should have its own database. This allows:
- ✅ Independent scaling
- ✅ Technology diversity (right tool for the job)
- ✅ Service independence
- ✅ Better performance optimization

---

## Database Recommendations by Service

### 1. **API Gateway** (YARP/Ocelot)
**Database**: ❌ **No Database Required**

**Reason**: API Gateway is stateless and only routes requests. No data persistence needed.

**Storage Needs**: Configuration only (appsettings.json or Consul)

---

### 2. **User Service**
**Database**: ✅ **PostgreSQL** (Relational)

**Why PostgreSQL:**
- ✅ ACID compliance for user data integrity
- ✅ Strong consistency for authentication
- ✅ Excellent support for relationships (users, roles, permissions)
- ✅ JSON support for flexible user profiles
- ✅ Full-text search capabilities
- ✅ Mature and reliable

**Schema Needs:**
- Users table (id, email, password_hash, created_at, etc.)
- Roles table
- UserRoles (many-to-many)
- UserProfiles (JSON column for flexible data)
- RefreshTokens

**Alternative**: SQL Server (if Windows-heavy environment)

---

### 3. **Product Service**
**Database**: ✅ **PostgreSQL** (Primary) + **Redis** (Cache)

**Why PostgreSQL:**
- ✅ Relational data (products, categories, tags)
- ✅ Complex queries (filtering, sorting, pagination)
- ✅ Full-text search (with pg_trgm extension)
- ✅ JSON support for flexible product metadata
- ✅ ACID for product updates

**Why Redis:**
- ✅ Cache frequently accessed products
- ✅ Cache product lists
- ✅ Reduce database load

**Schema Needs:**
- Products table
- Categories table
- ProductCategories (many-to-many)
- Tags table
- ProductTags (many-to-many)
- ProductMetadata (JSON column)

**Alternative**: MongoDB (if product structure is highly variable)

---

### 4. **Order Service**
**Database**: ✅ **PostgreSQL** (Relational)

**Why PostgreSQL:**
- ✅ ACID compliance (critical for orders)
- ✅ Transaction support for order creation
- ✅ Strong consistency
- ✅ Complex queries (order history, reporting)
- ✅ Foreign key constraints for data integrity

**Schema Needs:**
- Orders table (id, user_id, status, total, created_at)
- OrderItems table (order_id, product_id, quantity, price)
- OrderStatusHistory (audit trail)

**Alternative**: SQL Server (if enterprise requirements)

**Note**: This is transactional data - PostgreSQL is essential.

---

### 5. **Payment Service**
**Database**: ✅ **PostgreSQL** (Relational)

**Why PostgreSQL:**
- ✅ ACID compliance (CRITICAL for payments)
- ✅ Transaction support
- ✅ Strong consistency (no eventual consistency here!)
- ✅ Audit trail capabilities
- ✅ Financial data integrity

**Schema Needs:**
- Payments table (id, order_id, amount, status, transaction_id)
- PaymentMethods table
- Refunds table
- PaymentHistory (audit trail)
- TransactionLogs

**Alternative**: SQL Server (if compliance requirements)

**Note**: This is the most critical service - PostgreSQL is mandatory for financial data.

---

### 6. **Streaming Service**
**Database**: ✅ **PostgreSQL** (Metadata) + **Redis** (Real-time)

**Why PostgreSQL:**
- ✅ Stream metadata (title, description, status)
- ✅ Stream schedules
- ✅ Streamer information
- ✅ ACID for stream state changes

**Why Redis:**
- ✅ Real-time viewer count
- ✅ Active stream sessions
- ✅ Stream status (live/ended)
- ✅ Fast read/write for real-time data

**Schema Needs:**
- Streams table (id, title, streamer_id, status, started_at, ended_at)
- StreamSessions table
- StreamMetadata (JSON)

**Alternative**: MongoDB (if stream metadata is highly variable)

---

### 7. **Chat Service**
**Database**: ✅ **PostgreSQL** (Messages) + **Redis** (Real-time)

**Why PostgreSQL:**
- ✅ Message history persistence
- ✅ ACID for message delivery
- ✅ Complex queries (message search, history)
- ✅ Relationships (messages, users, streams)

**Why Redis:**
- ✅ Real-time message queue
- ✅ Active chat rooms
- ✅ User presence (online/offline)
- ✅ Rate limiting data

**Schema Needs:**
- Messages table (id, stream_id, user_id, content, created_at)
- ChatRooms table
- MessageReactions table

**Alternative**: MongoDB (if message structure varies significantly)

**Note**: Consider message archiving strategy for old messages.

---

### 8. **Media Service**
**Database**: ✅ **PostgreSQL** (Metadata) + **Object Storage** (Files)

**Why PostgreSQL:**
- ✅ Media metadata (file info, upload date, size)
- ✅ Relationships (media to products, streams)
- ✅ ACID for metadata updates

**Why Object Storage:**
- ✅ Store actual video/image files
- ✅ Scalable storage
- ✅ CDN integration

**Schema Needs:**
- MediaFiles table (id, filename, url, size, type, uploaded_at)
- MediaMetadata (JSON)
- MediaProcessingJobs table

**Object Storage Options:**
- AWS S3
- Azure Blob Storage
- MinIO (self-hosted)

**Alternative**: MongoDB (if metadata is highly variable)

---

### 9. **Notification Service**
**Database**: ✅ **PostgreSQL** (Notifications) + **Redis** (Queue)

**Why PostgreSQL:**
- ✅ Notification history
- ✅ User preferences
- ✅ Delivery status
- ✅ ACID for notification state

**Why Redis:**
- ✅ Notification queue (real-time delivery)
- ✅ Rate limiting
- ✅ Temporary notification storage

**Schema Needs:**
- Notifications table (id, user_id, type, content, status, created_at)
- NotificationPreferences table
- NotificationTemplates table

**Alternative**: MongoDB (if notification structure varies)

---

### 10. **Analytics Service**
**Database**: ✅ **PostgreSQL** (Aggregated) + **Time-Series DB** (Raw) + **Redis** (Real-time)

**Why PostgreSQL:**
- ✅ Aggregated analytics (daily, weekly, monthly)
- ✅ Reports and dashboards
- ✅ Complex queries

**Why Time-Series Database:**
- ✅ Raw event data (viewer counts, clicks, etc.)
- ✅ Time-based queries
- ✅ Efficient storage of time-series data

**Why Redis:**
- ✅ Real-time metrics
- ✅ Live dashboard data
- ✅ Fast aggregations

**Time-Series Options:**
- **TimescaleDB** (PostgreSQL extension) ⭐ Recommended
- InfluxDB
- Prometheus

**Schema Needs:**
- AnalyticsEvents table (TimescaleDB hypertable)
- AggregatedMetrics table
- Reports table

**Recommendation**: Use **TimescaleDB** (PostgreSQL extension) - best of both worlds!

---

### 11. **Search Service**
**Database**: ✅ **Elasticsearch** (Primary) + **PostgreSQL** (Sync)

**Why Elasticsearch:**
- ✅ Full-text search
- ✅ Faceted search
- ✅ Search suggestions
- ✅ Ranking and relevance
- ✅ Fast search performance

**Why PostgreSQL:**
- ✅ Sync data from other services
- ✅ Search index metadata
- ✅ Backup data source

**Schema Needs:**
- Elasticsearch indices:
  - `products` index
  - `users` index (optional)
  - `streams` index

**Alternative**: 
- Algolia (managed search service)
- Azure Cognitive Search

**Note**: Elasticsearch is specialized for search - perfect for this service.

---

### 12. **Subscription Service**
**Database**: ✅ **PostgreSQL** (Relational)

**Why PostgreSQL:**
- ✅ ACID compliance (subscription billing)
- ✅ Transaction support
- ✅ Complex relationships (users, products, subscriptions)
- ✅ Subscription history
- ✅ Billing cycles

**Schema Needs:**
- Subscriptions table (id, user_id, product_id, status, start_date, end_date)
- SubscriptionTiers table
- SubscriptionHistory table
- AccessPermissions table

**Alternative**: SQL Server (if enterprise requirements)

---

## Summary Table

| Service | Primary Database | Secondary/Cache | Special Requirements |
|---------|-----------------|-----------------|---------------------|
| API Gateway | ❌ None | - | Configuration only |
| User Service | ✅ PostgreSQL | Redis (sessions) | ACID, relationships |
| Product Service | ✅ PostgreSQL | Redis (cache) | Full-text search |
| Order Service | ✅ PostgreSQL | - | ACID, transactions |
| Payment Service | ✅ PostgreSQL | - | **ACID critical** |
| Streaming Service | ✅ PostgreSQL | Redis (real-time) | Real-time data |
| Chat Service | ✅ PostgreSQL | Redis (real-time) | Message history |
| Media Service | ✅ PostgreSQL | Object Storage | File metadata |
| Notification Service | ✅ PostgreSQL | Redis (queue) | Delivery queue |
| Analytics Service | ✅ TimescaleDB | Redis (real-time) | Time-series data |
| Search Service | ✅ Elasticsearch | PostgreSQL (sync) | Full-text search |
| Subscription Service | ✅ PostgreSQL | - | ACID, billing |

---

## Database Technology Stack

### Primary Databases

1. **PostgreSQL** (10 services)
   - Most services use PostgreSQL
   - Reliable, ACID-compliant
   - Excellent .NET support (Npgsql, EF Core)
   - JSON support for flexibility

2. **TimescaleDB** (1 service - Analytics)
   - PostgreSQL extension
   - Time-series optimization
   - Same tooling as PostgreSQL

3. **Elasticsearch** (1 service - Search)
   - Specialized for search
   - Full-text search capabilities
   - .NET client available (NEST)

### Supporting Technologies

4. **Redis** (7 services)
   - Caching
   - Real-time data
   - Session storage
   - Message queues
   - Rate limiting

5. **Object Storage** (1 service - Media)
   - AWS S3 / Azure Blob / MinIO
   - For large file storage

---

## Implementation Strategy

### Phase 1: Start Simple
- Use **PostgreSQL** for all services initially
- Add Redis for caching later
- Add Elasticsearch when search is needed

### Phase 2: Optimize
- Add TimescaleDB for Analytics
- Add Redis for real-time services
- Add Elasticsearch for Search

### Phase 3: Scale
- Add object storage for Media
- Optimize based on usage patterns

---

## .NET Core Database Libraries

### PostgreSQL
- **Npgsql** - ADO.NET provider
- **Entity Framework Core** - ORM
- **Dapper** - Micro ORM (optional)

### Redis
- **StackExchange.Redis** - Redis client
- **Microsoft.Extensions.Caching.StackExchangeRedis** - Caching

### Elasticsearch
- **NEST** - Elasticsearch .NET client
- **Elasticsearch.Net** - Low-level client

### TimescaleDB
- Same as PostgreSQL (it's an extension)
- Use EF Core or Npgsql

---

## Connection String Examples

### PostgreSQL
```json
{
  "ConnectionStrings": {
    "UserServiceDb": "Host=localhost;Port=5432;Database=user_service;Username=postgres;Password=password",
    "ProductServiceDb": "Host=localhost;Port=5433;Database=product_service;Username=postgres;Password=password"
  }
}
```

### Redis
```json
{
  "ConnectionStrings": {
    "Redis": "localhost:6379"
  }
}
```

### Elasticsearch
```json
{
  "Elasticsearch": {
    "Uri": "http://localhost:9200",
    "IndexName": "products"
  }
}
```

---

## Docker Compose Database Setup

```yaml
services:
  # PostgreSQL instances (one per service)
  postgres-user-service:
    image: postgres:15
    environment:
      POSTGRES_DB: user_service
      POSTGRES_USER: postgres
      POSTGRES_PASSWORD: password
    ports:
      - "5432:5432"
  
  postgres-product-service:
    image: postgres:15
    environment:
      POSTGRES_DB: product_service
      POSTGRES_USER: postgres
      POSTGRES_PASSWORD: password
    ports:
      - "5433:5432"
  
  # Redis
  redis:
    image: redis:7-alpine
    ports:
      - "6379:6379"
  
  # Elasticsearch
  elasticsearch:
    image: docker.elastic.co/elasticsearch/elasticsearch:8.11.0
    environment:
      - discovery.type=single-node
    ports:
      - "9200:9200"
  
  # TimescaleDB (PostgreSQL with extension)
  timescaledb:
    image: timescale/timescaledb:latest-pg15
    environment:
      POSTGRES_DB: analytics_service
      POSTGRES_USER: postgres
      POSTGRES_PASSWORD: password
    ports:
      - "5434:5432"
```

---

## Best Practices

1. ✅ **One Database per Service** - Never share databases
2. ✅ **Use Right Tool for Job** - Don't force one database for all
3. ✅ **Start Simple** - Begin with PostgreSQL, optimize later
4. ✅ **Cache Strategically** - Use Redis for hot data
5. ✅ **Monitor Performance** - Track query performance
6. ✅ **Backup Regularly** - Especially for critical services (Payment, Order)
7. ✅ **Use Connection Pooling** - Configure EF Core connection pooling
8. ✅ **Index Strategically** - Add indexes for frequent queries

---

## Migration Strategy

1. **Start**: All services use PostgreSQL
2. **Optimize**: Add Redis for caching
3. **Specialize**: Add Elasticsearch for search
4. **Scale**: Add TimescaleDB for analytics
5. **Final**: Each service has optimal database

---

**Last Updated**: 2024
**Recommendation**: Start with PostgreSQL for all, then optimize based on needs

