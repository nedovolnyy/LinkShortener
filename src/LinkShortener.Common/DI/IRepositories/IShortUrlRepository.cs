namespace LinkShortener.Common.DI.IRepositories;

public interface IShortUrlRepository : IRepository<ShortUrl>
{
    Task InsertNewUrlAsync(string newUrl);
    Task UpdateOnlyUrlAsync(int id, string url);
    Task<string> IncrementCounterAsync(int id);
}
