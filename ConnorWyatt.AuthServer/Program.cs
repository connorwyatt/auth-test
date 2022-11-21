using ConnorWyatt.AuthServer;
using ConnorWyatt.Keys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DbContext>(
  options =>
  {
    options.UseInMemoryDatabase(nameof(DbContext));

    options.UseOpenIddict();
  });

builder.Services.AddOpenIddict()
  .AddCore(
    options =>
    {
      options.UseEntityFrameworkCore()
        .UseDbContext<DbContext>();
    })
  .AddServer(
    options =>
    {
      options
        .AllowClientCredentialsFlow();

      options
        .SetTokenEndpointUris("/connect/token");

      options
        .AddSigningKey(AuthKeys.SigningKey)
        .AddDevelopmentSigningCertificate();

      options
        .AddEncryptionKey(AuthKeys.EncryptionKey)
        .AddDevelopmentEncryptionCertificate();

      options.RegisterScopes("api");

      options
        .UseAspNetCore()
        .EnableTokenEndpointPassthrough();
    });

builder.Services.AddHostedService<TestData>();

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
