namespace LinkShortener.DataAccess.Repositories;

internal class ShortUrlRepository(IDatabaseContext databaseContext) : BaseRepository<ShortUrl>(databaseContext), IShortUrlRepository
{
    private readonly IDatabaseContext _databaseContext = databaseContext;
    private readonly DbSet<ShortUrl> _dbSet = databaseContext.ShortUrls;

    public DbSet<ShortUrl> DbSet => _dbSet;

    public virtual async Task<string> IncrementCounterAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is not null)
        {
            entity.Counter++;
            _databaseContext.Instance.Entry(entity).State = EntityState.Modified;
            await _databaseContext.Instance.SaveChangesAsync();
        }

        return (await Task.FromResult(entity!.Url))!;
    }

    public virtual async Task InsertNewUrlAsync(string newUrl)
    {
        var paramNewUrl = new MySqlParameter("@NewUrl", newUrl);
        await _databaseContext.Instance.Database.ExecuteSqlRawAsync("CALL spInsertNewUrl(@NewUrl)", paramNewUrl);
    }

    public virtual async Task UpdateOnlyUrlAsync(int id, string url)
    {
        var paramId = new MySqlParameter("@Id", id);
        var paramUrl = new MySqlParameter("@Url", url);
        await _databaseContext.Instance.Database.ExecuteSqlRawAsync("CALL spUpdateOnlyUrl(@Id, @Url)", paramId, paramUrl);
    }
}
