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
             // SearchRquest -> SearchParamPresenter 
             int? CategoryId,
             int? SizeId,
             int? VendorId
             )
        {// формируем список компаний для передачи в представление
            //List<CategoryModel> categoryModels = _context.Categories
            //    .Select(c => new CategoryModel { Id = c.Id, Name = c.Name })
            //    .ToList();
            //// добавляем на первое место
            //categoryModels.Insert(0, new CategoryModel { Id = 0, Name = "Все" });
            var query = _context.Products.AsQueryable();
            //IndexViewModel ivm = new IndexViewModel { Categories = categoryModels, Products = _context.Products.ToList() };

            //// если передан id компании, фильтруем список
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
