using NLog;
using NLog.Web;
using Webapp.Services;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddControllersWithViews();
    ConfigureLoggerService.ConfigureLogger(builder.Services);

    var app = builder.Build();

    app.UseRouting();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    var logger = LogManager.GetCurrentClassLogger();
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}