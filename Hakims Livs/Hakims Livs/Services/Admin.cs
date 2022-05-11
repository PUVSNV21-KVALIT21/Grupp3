using Hakims_Livs.Data;
using Hakims_Livs.Models;

namespace Hakims_Livs.Services
{
    public interface IAdmin
    {
        public Task CreateProduct(Product produc, Category category);
        public Task CreateCategory(string name);
    }
    public class Admin : IAdmin
    {
        private readonly ApplicationDbContext _context;

        public Admin(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateCategory(string name)
        {
            Category category = new Category()
            {
                Name = name
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
        public async Task CreateProduct(Product product, Category category)
        {
            Product newProduct = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                CategoryName = category,
                ProductCode = product.ProductCode,
                Description = product.Description,
                Image = product.Image,
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
        }
    }

}
