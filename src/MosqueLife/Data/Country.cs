using System.ComponentModel.DataAnnotations;

namespace MosqueLife.Data
{
    public class Country
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(2)]
        [MaxLength(2)]
        public string Alpha2Code { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        public string Alpha3Code { get; set; } = string.Empty;
    }
}
