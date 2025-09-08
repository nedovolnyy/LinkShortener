namespace LinkShortener.DataAccess.EF;
public partial class DatabaseContext : DbContext, IDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
    : base(options) => ConnectionString = Database.GetConnectionString();

    public string? ConnectionString { get; private set; }
    public DbContext Instance => this;
    public virtual DbSet<ShortUrl> ShortUrls { get; set; } = null!;
}
