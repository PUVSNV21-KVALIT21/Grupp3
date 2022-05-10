using Hakims_Livs.Data;
using Hakims_Livs.Models;
using Hakims_Livs.Pages;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Hakims_Livs.Services
{
    public interface ICart
    {
        public Task AddProductToShoppingCart(Product product);
    }
    public class Cart : ICart
    {
        private readonly ApplicationDbContext _context;
        private Customer currentCustomer { get; set; }
        private readonly UserManager<Customer> UserManager;
        private readonly IUser _user;
        public Cart(ApplicationDbContext context, IUser user)
        {
            _context = context;
            _user = user;
        }
        public async Task AddProductToShoppingCart(Product product)
        {
            currentCustomer = await _user.GetCurrentUserAsync();;
            ShoppingCart shoppingcart = new ShoppingCart();
            shoppingcart.ProductId = product.ID;
            shoppingcart.UserId = currentCustomer.Id;

            await _context.ShoppingCarts.AddAsync(shoppingcart);
            await _context.SaveChangesAsync();
        }
    }
}
