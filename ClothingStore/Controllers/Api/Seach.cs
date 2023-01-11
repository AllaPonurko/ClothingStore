using ClothingStore.Data;
using ClothingStore.Data.Migrations;
using ClothingStore.Models;
using ClothingStore.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStore.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class Seach : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Seach(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetSearch(
             
             int? CategoryId,
             int? SizeId,
             int? VendorId
             )
        {
            var query = _context.Products.AsQueryable();
            
            if (CategoryId != null)
                query = query.Where(p => p.Category.Id == CategoryId);

            // Service (SearchparamPresenter) -- Repository(SearchParamPresenter)

            if (SizeId != null)
            {
                query = query.Where(p => p.Size.Id == SizeId);
            }
            if (VendorId != null)
            {
                query = query.Where(p => p.Vendor.Id == VendorId);
            }
            // Все другие фильтры продолжаем тут
          return await query.ToListAsync();
 
        }
    }
}
