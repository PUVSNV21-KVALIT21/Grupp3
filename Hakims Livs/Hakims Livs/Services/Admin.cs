using Hakims_Livs.Data;
using Hakims_Livs.Models;

namespace Hakims_Livs.Services
{
    public interface IAdmin
    {
        public Task CreateProduct(Product product);
        public Task CreateCategory(string name);
        public Task DeleteProduct(Product product);
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
        public async Task CreateProduct(Product product)
        {
            Product newProduct = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                CategoryName = product.CategoryName,
                ProductCode = product.ProductCode,
                Description = product.Description,
                Image = product.Image,
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProduct(Product product)
        {
            var productToDelete = _context.Products.Where(x => x.ID == product.ID).FirstOrDefault();
            _context.Products.Remove(productToDelete);
            await _context.SaveChangesAsync();
        }
    }

}
