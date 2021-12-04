using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosqueLife.Data
{
    public class Member
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }


    }

    public class Address
    {
        public Guid Id { get; set; }

        [MinLength(3)]
        [MaxLength(200)]
        [Required]
        public string StreetLine1 { get; set; }

        [MaxLength(200)]
        public string? StreetLine2 { get; set; }

        [Required]
        public string HouseNumber { get; set; }

        [Range(1000, 999999)]
        public int ZipCode { get; set; }

        [MinLength(3)]
        [Required]
        public string City { get; set; }


        public string State { get; set; }
        public string Country { get; set; }

    }
}
