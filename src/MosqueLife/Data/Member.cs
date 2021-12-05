using System.ComponentModel.DataAnnotations;

namespace MosqueLife.Data
{
    public class Member
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;


    }

    public class Address
    {
        public Guid Id { get; set; }

        [MinLength(3)]
        [MaxLength(200)]
        [Required]
        public string StreetLine1 { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? StreetLine2 { get; set; }

        [Required]
        public string HouseNumber { get; set; } = string.Empty;

        [Range(1000, 999999)]
        public int ZipCode { get; set; }

        [MinLength(3)]
        [Required]
        public string City { get; set; } = string.Empty;

        [MinLength(3)]
        [Required]
        public string State { get; set; } = string.Empty;

        [MinLength(3)]
        [Required]
        public string Country { get; set; } = string.Empty;

    }
}
