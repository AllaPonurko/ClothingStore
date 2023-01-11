using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStore.Models
{
    public class Product

    {   [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public List<Color> colors { get; set; }
        public Color Color { get; set; }
        public int ColorId { get; set; }
        [Required]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public List<Size> sizes { get; set; }
        [Required]
        public Size Size { get; set; }
        public int SizeId { get; set; }
        public Sale Sale { get; set; }
        [Required]
        public Sex Sex { get; set; }
        public int SexId { get; set; }
        public List<Review> reviews { get; set; }
        public Like Like { get; set; }
        [Required]
        public Vendor Vendor { get; set; }
        [Required]
        public int VendorId { get; set; }
        public List<Status> statuses{ get; set; }
        public int Quantity { get; set; }
        public string Img { get; set; }
        [Required]
        public Textile Textile { get; set; }
        [Required]
        public int TextileId { get; set; }
    }
}
