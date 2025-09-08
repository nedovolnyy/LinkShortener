namespace LinkShortener.WebUI.Models;

public class ShortUrlModel
{
    public ShortUrlModel()
    {
    }

    public ShortUrlModel(string url)
        : this(default, url, string.Empty, DateTimeOffset.Now, default)
    {
        Url = url;
    }

    public ShortUrlModel(int id,
                      string url,
                      string tinyUrl,
                      DateTimeOffset date,
                      int counter)
    {
        Id = id;
        Url = url;
        TinyUrl = tinyUrl;
        Date = date;
        Counter = counter;
    }

    [Required]
    [JsonRequired]
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Required]
    [StringLength(65535, MinimumLength = 3, ErrorMessage = "Length is very small")]
    [Url]
    [Display(Name = "Url")]
    public string? Url { get; set; }

    [Required]
    [Display(Name = "TinyUrl")]
    public string? TinyUrl { get; set; }

    [Required]
    [JsonRequired]
    [Display(Name = "Date")]
    public DateTimeOffset Date { get; set; }

    [Required]
    [JsonRequired]
    [Display(Name = "Counter")]
    public int Counter { get; set; }
}
