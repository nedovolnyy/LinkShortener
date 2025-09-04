namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceProviderExtensions
{
    public static void AddRepositories(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<IDatabaseContext, DatabaseContext>(
            options => options.UseMySQL(connectionString)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        services.AddTransient<IShortUrlRepository, ShortUrlRepository>();
    }
}