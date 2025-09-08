namespace LinkShortener.BusinessLogic.Services;

internal class ShortUrlService(IShortUrlRepository shortUrlRepository) : BaseService<ShortUrl>(shortUrlRepository), IShortUrlService
{
    private readonly IShortUrlRepository _shortUrlRepository = shortUrlRepository;
    public virtual async Task<string> IncrementCounterAsync(int id)
    {
        return await _shortUrlRepository.IncrementCounterAsync(id);
    }

    public virtual async Task InsertNewUrlAsync(string newUrl)
    {
        await _shortUrlRepository.InsertNewUrlAsync(newUrl);
    }

    public virtual async Task UpdateOnlyUrlAsync(int id, string url)
    {
        await _shortUrlRepository.UpdateOnlyUrlAsync(id, url);
    }

    public override async Task ValidateAsync(ShortUrl entity)
    {
        if (string.IsNullOrEmpty(entity.Url))
        {
            throw new ValidationException("The field 'Url' of ShortUrl is not allowed to be empty!");
        }

        if (!(await Task.Run(() => Regex.IsMatch(entity.Url, "[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b([-a-zA-Z0-9()@:%_\\+.~#?&//=]*)"))))
        {
            throw new ValidationException("This 'Url' has wrong format!");
        }
    }
}
