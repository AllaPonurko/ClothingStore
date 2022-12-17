using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStore.Models
{
    public class Like
    {
        [Required]
        public int Id
        {
            get; set;
        }
        public int Count { get; set; }
        
    }
}
