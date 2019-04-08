using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISample.Model
{
    public class Product
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        public int Count { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
