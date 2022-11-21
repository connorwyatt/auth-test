using Microsoft.EntityFrameworkCore;
using OpenIddict.Abstractions;

namespace ConnorWyatt.AuthServer;

public class TestData : IHostedService
{
  private readonly IServiceProvider _serviceProvider;

  public TestData(IServiceProvider serviceProvider)
  {
    _serviceProvider = serviceProvider;
  }

  public async Task StartAsync(CancellationToken cancellationToken)
  {
    using var scope = _serviceProvider.CreateScope();

    var context = scope.ServiceProvider.GetRequiredService<DbContext>();
    await context.Database.EnsureCreatedAsync(cancellationToken);

    var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();

    if (await manager.FindByClientIdAsync("postman", cancellationToken) is null)
    {
      await manager.CreateAsync(new OpenIddictApplicationDescriptor
      {
        ClientId = "abc",
        ClientSecret = "123",
        DisplayName = "ABC",
        Permissions =
        {
          OpenIddictConstants.Permissions.Endpoints.Token,
          OpenIddictConstants.Permissions.GrantTypes.ClientCredentials,

          OpenIddictConstants.Permissions.Prefixes.Scope + "api",
        },
      }, cancellationToken);
    }
  }

  public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
