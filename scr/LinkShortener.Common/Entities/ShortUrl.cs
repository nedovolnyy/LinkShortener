namespace LinkShortener.Common.Entities;

[Table("ShortUrl")]
public class ShortUrl : BaseEntity
{
    public ShortUrl()
    {
    }

    public ShortUrl(string url, string tinyUrl, DateTime date, int counter)
        : this(default, url, tinyUrl, date, counter)
    {
    }

    public ShortUrl(int id, string url, string tinyUrl, DateTime date, int counter)
    {
        Id = id;
        Url = url;
        TinyUrl = tinyUrl;
        Date = date;
        Counter = counter;
    }

    [Required]
    public Guid GUId { get; set; }

    [Required]
    [MaxLength(65535)]
    public string? Url { get; set; }
    [Required]
    public string? TinyUrl { get; set; }
    [Required]
    public DateTime Date { get; }
    [Required]
    public int Counter { get; set; }
}
