namespace LinkShortener.Common.Entities;

public class BaseEntity
{
    [Key]
    [Required]
    public int Id { get; set; }
}
