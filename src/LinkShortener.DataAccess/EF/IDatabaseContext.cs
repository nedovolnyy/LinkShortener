namespace LinkShortener.DataAccess.EF;
public interface IDatabaseContext
{
    string? ConnectionString { get; }
    DbContext Instance { get; }
    DbSet<ShortUrl> ShortUrls { get; set; }
}