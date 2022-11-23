namespace ConnorWyatt.SPAApplication;

public static class HttpRequestExtensions
{
  public static bool IsApiRequest(this HttpRequest httpRequest)
  {
    return httpRequest.Path.StartsWithSegments("/api");
  }
}
