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
    public class CreateCategoryModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IAdmin _admin;
        public Category category { get; set; }
        public CreateCategoryModel(ApplicationDbContext context, IAdmin admin)
        {
            _context = context;
            _admin = admin;
        }
        public async Task<IActionResult> OnPostAsync(Category category)
        {
            try
            {
                var name = category.Name;
                await _admin.CreateCategory(name);
                return Page();
            }
            catch (Exception)
            {

                return Page();
            }

        }
    }
}
