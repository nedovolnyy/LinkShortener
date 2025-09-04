namespace LinkShortener.DataAccess.Repositories;

internal class ShortUrlRepository : BaseRepository<ShortUrl>, IShortUrlRepository
{
    private readonly DbSet<ShortUrl> _dbSet;
    public ShortUrlRepository(IDatabaseContext databaseContext)
        : base(databaseContext)
    {
        _dbSet = databaseContext.ShortUrls;
    }

    public DbSet<ShortUrl> DbSet => _dbSet;
}
