namespace Microsoft.Extensions.DependencyInjection;
public static class ServiceProviderExtensions
{
    public static void AddBLLServices(this IServiceCollection services)
    {
        services.AddTransient<IShortUrlService, ShortUrlService>();
    }
}