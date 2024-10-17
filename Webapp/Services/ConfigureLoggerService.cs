namespace Webapp.Services;

public class ConfigureLoggerService
{
    public static void ConfigureLogger(IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }
}