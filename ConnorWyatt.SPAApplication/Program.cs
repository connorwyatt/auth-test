using ConnorWyatt.SPAApplication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using NodaTime;
using NodaTime.Serialization.SystemTextJson;

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment;

builder.Services.AddControllers()
  .AddJsonOptions(options => { options.JsonSerializerOptions.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb); });

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
  .AddCookie(
    options =>
    {
      options.ExpireTimeSpan = TimeSpan.FromSeconds(10);
      options.SlidingExpiration = false;

      options.Events.OnRedirectToLogin += redirectContext =>
      {
        if (redirectContext.Request.IsApiRequest())
        {
          redirectContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
        }

        return Task.CompletedTask;
      };
    });

builder.Services.AddSpaStaticFiles(configuration => { configuration.RootPath = "../app/build"; });

var app = builder.Build();

app.UseStaticFiles();

app.UseSpaStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.UseSpa(
  spa =>
  {
    spa.Options.SourcePath = "../app";

    if (environment.IsDevelopment())
    {
      spa.UseReactDevelopmentServer(npmScript: "start");
    }
  });

app.Run();
