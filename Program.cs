using SeuNamespace;
using System.Globalization;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .UseDefaultServiceProvider(options =>
                options.ValidateScopes = false) // Evita o erro relacionado à cultura
            .ConfigureServices(services =>
            {
                services.Configure<RequestLocalizationOptions>(options =>
                {
                    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("pt-BR");
                    options.SupportedCultures = new List<CultureInfo> { new CultureInfo("pt-BR") };
                    options.SupportedUICultures = new List<CultureInfo> { new CultureInfo("pt-BR") };
                });
            });
}
