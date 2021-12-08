using System.ComponentModel.DataAnnotations;

namespace MosqueLife.Server.Data;

public class State
{
    public Guid Id { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(5)]
    public string? Code { get; set; }

    public Guid CountryId { get; set; }

    public Country Country { get; set; }

}
