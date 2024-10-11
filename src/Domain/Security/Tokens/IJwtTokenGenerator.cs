namespace Domain.Security.Tokens;

public interface IJwtTokenGenerator
{
    string GenerateToken(
        Guid id,
        string firstName,
        string lastName,
        string email,
        List<string> permissions,
        List<string> roles);
}