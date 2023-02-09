namespace CA.Infrastructure.Authentication;

public class JwtSettings
{
    public const string SectionName = "Authentication";
    public string SecretKey { get; init; } = null!;
    public int ExpiryMinutes { get; init; }
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
}