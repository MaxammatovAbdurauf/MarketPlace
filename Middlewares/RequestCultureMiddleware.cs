using System.Globalization;

namespace MarketPlays.Middlewares;

public class RequestCultureMiddleware
{
    private readonly RequestDelegate next;
    public RequestCultureMiddleware (RequestDelegate _next)
    {
        next = _next;
    }

    public async Task Invoke (HttpContext context)
    {
        if (context.Request.Query.ContainsKey ("lan"))
        {
            var culture = new CultureInfo("");
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }
        else if (context.Request.Headers.ContainsKey("lan"))
        {
            var culture = new CultureInfo("");
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }   
        await next(context);
    }
}