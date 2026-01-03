# User Service

User authentication and profile management microservice.

## Features

- ✅ **Database Schema** - User, Role, UserRole tables (EF Core + PostgreSQL)
- ✅ **User Registration** - Register new users with email/password
- ✅ **JWT Authentication** - Login and token generation
- ✅ **User Profile CRUD** - Get and update user profiles
- ✅ **Role-Based Access Control (RBAC)** - Admin, User, Seller roles
- ✅ **Health Checks** - `/health`, `/health/ready`, `/health/live`
- ✅ **Swagger/OpenAPI** - Full API documentation with JWT support
- ✅ **Structured Logging** - Serilog
- ✅ **Global Error Handling** - Comprehensive error handling
- ✅ **CORS Configuration** - Ready for frontend integration

## Prerequisites

1. **PostgreSQL** must be running (from docker-compose):
   ```bash
   docker-compose up -d postgres-user-service
   ```

2. **Database** will be created automatically on first run

## Running the Service

```bash
# From project root
dotnet run --project services/UserService/UserService.csproj

# Or from service directory
cd services/UserService
dotnet run
```

## API Endpoints

### Authentication (Public)
- `POST /api/auth/register` - Register new user
- `POST /api/auth/login` - Login and get JWT token

### User Management (Authenticated)
- `GET /api/users/me` - Get current user profile
- `PUT /api/users/me` - Update current user profile

### Admin Only
- `GET /api/users/{id}` - Get user by ID
- `POST /api/users/{id}/roles/{roleName}` - Assign role to user
- `DELETE /api/users/{id}/roles/{roleName}` - Remove role from user

### Health & Info
- `GET /` - Service information
- `GET /health` - Health check
- `GET /swagger` - API documentation

## Default Roles

- **Admin** - Full access, can manage users and roles
- **User** - Regular user (default role for new registrations)
- **Seller** - User who can sell products

## Example Usage

### 1. Register a User
```bash
curl -X POST http://localhost:5001/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "email": "user@example.com",
    "password": "Password123!",
    "firstName": "John",
    "lastName": "Doe"
  }'
```

### 2. Login
```bash
curl -X POST http://localhost:5001/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "email": "user@example.com",
    "password": "Password123!"
  }'
```

Response:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "refreshToken": "...",
  "expiresAt": "2024-01-01T12:00:00Z",
  "user": {
    "id": "...",
    "email": "user@example.com",
    "firstName": "John",
    "lastName": "Doe",
    "roles": ["User"]
  }
}
```

### 3. Get Current User (Authenticated)
```bash
curl -X GET http://localhost:5001/api/users/me \
  -H "Authorization: Bearer YOUR_JWT_TOKEN"
```

### 4. Update Profile (Authenticated)
```bash
curl -X PUT http://localhost:5001/api/users/me \
  -H "Authorization: Bearer YOUR_JWT_TOKEN" \
  -H "Content-Type: application/json" \
  -d '{
    "firstName": "Jane",
    "lastName": "Smith"
  }'
```

### 5. Assign Role (Admin Only)
```bash
curl -X POST http://localhost:5001/api/users/{userId}/roles/Seller \
  -H "Authorization: Bearer ADMIN_JWT_TOKEN"
```

## Configuration

### Connection String
```json
"ConnectionStrings": {
  "UserServiceDb": "Host=localhost;Port=5432;Database=user_service;Username=postgres;Password=postgres"
}
```

### JWT Settings
```json
"JwtSettings": {
  "SecretKey": "YourSuperSecretKeyThatShouldBeAtLeast32CharactersLongForProduction!",
  "Issuer": "UserService",
  "Audience": "UserService",
  "ExpiryMinutes": "60"
}
```

**⚠️ Important**: Change the `SecretKey` in production!

## Port

- HTTP: `http://localhost:5001`
- HTTPS: `https://localhost:7001`

## Database Schema

- **Users** - User accounts with email, password hash, profile info
- **Roles** - Available roles (Admin, User, Seller)
- **UserRoles** - Many-to-many relationship between users and roles

## Security Features

- ✅ Password hashing with BCrypt
- ✅ JWT token-based authentication
- ✅ Role-based authorization
- ✅ Secure password requirements (min 6 characters)
- ✅ Email validation

## Testing with Swagger

1. Start the service
2. Open http://localhost:5001/swagger
3. Click "Authorize" button
4. Enter: `Bearer YOUR_JWT_TOKEN`
5. Test all endpoints directly from Swagger UI

