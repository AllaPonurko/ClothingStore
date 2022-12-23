using ClothingStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStore.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }

    }
}
