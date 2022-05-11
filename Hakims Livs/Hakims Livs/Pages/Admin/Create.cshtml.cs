using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hakims_Livs.Models;
using Hakims_Livs.Data;
using Hakims_Livs.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Hakims_Livs.Pages.Admin
{
    public class CreateModel : PageModel
    {
        public List<Category> categories { get; set; }
        private readonly ApplicationDbContext _context;
        private readonly IAdmin _admin;
        public List<SelectListItem> categoryList { get; set; }
        [FromQuery]
        public Category category { get; set; }
        public CreateModel(ApplicationDbContext context, IAdmin admin)
        {
            _context = context;
            _admin = admin;
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
            Product newProduct = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                CategoryName = selectedCategory,
                ProductCode = product.ProductCode,
                Description = product.Description,
                Image = product.Image,
            };

            await _admin.CreateProduct(newProduct);

            return Page();
        }
    }
}
