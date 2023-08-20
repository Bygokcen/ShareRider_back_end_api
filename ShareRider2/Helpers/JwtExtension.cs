namespace ShareRider2.Helpers;

public static class JwtExtension
{
    public static void AddApplicationError(this HttpResponse response, string errorMessage)
    {
        response.Headers.Add("Application Error", errorMessage);
        response.Headers.Add("Access-Control-Allow-Origin", "*");
        response.Headers.Add("Access-Control-Expose-Header", "Application-Error");
    }
}