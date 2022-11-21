using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment;

builder.Services.AddControllers();

builder.Services.AddSpaStaticFiles(configuration =>
{
  configuration.RootPath = "../app/build";
});

var app = builder.Build();

app.UseStaticFiles();

app.UseSpaStaticFiles();

app.UseRouting();

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
