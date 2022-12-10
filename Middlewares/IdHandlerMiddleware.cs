namespace MarketPlays.Middlewares;

public class IdHandlerMiddleware
{

    private readonly RequestDelegate next;
    public IdHandlerMiddleware(RequestDelegate _next)
    {
        next = _next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Query.ContainsKey("productId"))
        {
            var productId = context.Request.Query["productId"];
        }
        await next(context);
    }
}

public static class IdHandlerMiddlewareExtension
{
    public static IApplicationBuilder UseIdHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}