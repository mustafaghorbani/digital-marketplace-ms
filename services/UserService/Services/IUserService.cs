using UserService.Models.DTOs;

namespace UserService.Services;

public interface IUserService
{
    Task<AuthResponse> RegisterAsync(RegisterRequest request);
    Task<AuthResponse> LoginAsync(LoginRequest request);
    Task<UserDto> GetUserByIdAsync(Guid userId);
    Task<UserDto> UpdateUserAsync(Guid userId, UpdateUserRequest request);
    Task<bool> AssignRoleAsync(Guid userId, string roleName);
    Task<bool> RemoveRoleAsync(Guid userId, string roleName);
}

