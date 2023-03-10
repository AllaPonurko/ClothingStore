using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStore.Models
{
    public class Color
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Img { get; set; }
        public Color MyColor { get; set; }
    }
}
