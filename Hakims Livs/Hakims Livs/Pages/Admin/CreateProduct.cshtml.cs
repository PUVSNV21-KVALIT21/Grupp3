using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hakims_Livs.Models;
using Hakims_Livs.Data;
using Hakims_Livs.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Components;

namespace Hakims_Livs.Pages.Admin
{
    public class CreateProductModel : PageModel
    {
        public List<Category> categories { get; set; }
        private readonly ApplicationDbContext _context;
        private readonly IAdmin _admin;
        public List<SelectListItem> categoryList { get; set; }
        [FromQuery]
        public Category category { get; set; }
        public NavigationManager _navigationManager;
        public CreateProductModel(ApplicationDbContext context, IAdmin admin, NavigationManager navigationManager)
        {
            _context = context;
            _admin = admin;
            _navigationManager = navigationManager;
        }
        public async Task OnGetAsync()
        {
            categories = _context.Categories.ToList();

            categoryList = await _context.Categories.AsNoTracking()
                .Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Name
                })
                .ToListAsync();
        }
        [BindProperty]
        public Product product { get; set; }
 
        public async Task<IActionResult> OnPostAsync(Product product, Category category)
        {
            var selectedCategory = await _context.Categories.FindAsync(category.ID);
            Product product1 = new Product()
            {
                Name = product.Name,
                CategoryName = selectedCategory,
                ProductCode = product.ProductCode,
                Description = product.Description,
                Image = product.Image,
                Price = product.Price,
            };
            try
            {
                if (product1.Price != 0)
                {
                await _admin.CreateProduct(product1);
                await OnGetAsync();
                return Page();
                }         
                await OnGetAsync();
                return Page();             
            }
            catch (Exception)
            {
                await OnGetAsync();
                return Page();
            }
        }
    }
}
