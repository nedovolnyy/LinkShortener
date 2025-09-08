namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceProviderExtensions
{
    public static void AddRepositories(this IServiceCollection services, string connectionString)
    {
        services.AddEntityFrameworkMySql()
            .AddDbContext<IDatabaseContext, DatabaseContext>(
            options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(12, 0, 2))));

        services.AddTransient<IShortUrlRepository, ShortUrlRepository>();
    }
}