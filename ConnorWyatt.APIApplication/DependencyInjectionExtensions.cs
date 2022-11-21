using ConnorWyatt.Keys;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ConnorWyatt.APIApplication;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
  {
    const string issuer = "https://localhost:5001/";

    var tokenValidationParameters = new TokenValidationParameters
    {
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = AuthKeys.SigningKey,
      ValidateIssuer = false,
      ValidIssuer = issuer,
      ValidateAudience = false, // Should this be validated?
      ValidateLifetime = true,
      TokenDecryptionKey = AuthKeys.EncryptionKey,
      ClockSkew = TimeSpan.Zero,
      AuthenticationType = JwtBearerDefaults.AuthenticationScheme,
    };

    services.AddAuthentication(
        options =>
        {
          options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

        })
      .AddJwtBearer(
        options =>
        {
          options.Authority = issuer;
          options.TokenValidationParameters = tokenValidationParameters;
        });

    return services;
  }
}
