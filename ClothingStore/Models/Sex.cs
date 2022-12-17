using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStore.Models
{
    public class Sex
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
    }
}
