using Serilog;
using TelegramSink;

namespace MarketPlays.Extensions;

public static class AddSerilog
{
    public static void _AddSerilogWithConfig (this WebApplicationBuilder app)
    {
        var logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("logging")
         // .WriteTo.TeleSink()
            .CreateLogger();

        app.Logging.AddSerilog(logger);
    }
}