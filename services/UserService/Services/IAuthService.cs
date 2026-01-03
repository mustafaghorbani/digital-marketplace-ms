using UserService.Models;

namespace UserService.Services;

public interface IAuthService
{
    string GenerateJwtToken(User user, List<string> roles);
    string GenerateRefreshToken();
    bool VerifyPassword(string password, string passwordHash);
    string HashPassword(string password);
}

