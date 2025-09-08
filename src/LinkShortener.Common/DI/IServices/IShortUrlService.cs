namespace LinkShortener.Common.DI.IServices;

public interface IShortUrlService : IService<ShortUrl>
{
    Task InsertNewUrlAsync(string newUrl);
    Task UpdateOnlyUrlAsync(int id, string url);
    Task<string> IncrementCounterAsync(int id);
    Task ValidateAsync(ShortUrl entity);
}
