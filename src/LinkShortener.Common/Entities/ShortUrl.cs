namespace LinkShortener.Common.Entities;

[Table("ShortUrl")]
public class ShortUrl : BaseEntity
{
    public ShortUrl()
    {
    }

    public ShortUrl(string url)
        : this(default, url, string.Empty, DateTimeOffset.Now, default)
    {
    }

    public ShortUrl(int id, string url, string tinyUrl, DateTimeOffset date, int counter)
    {
        Id = id;
        Url = url;
        TinyUrl = tinyUrl;
        Date = date;
        Counter = counter;
    }

    [Required]
    [MaxLength(65535)]
    public string? Url { get; set; }
    [Required]
    public string? TinyUrl { get; set; }
    [Required]
    public DateTimeOffset Date { get; set; }
    [Required]
    public int Counter { get; set; }
}
