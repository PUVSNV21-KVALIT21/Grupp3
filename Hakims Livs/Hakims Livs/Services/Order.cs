using Hakims_Livs.Data;
using Hakims_Livs.Models;
using Hakims_Livs.Pages;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Hakims_Livs.Services
{
    public interface IOrder
    {
        public Task CreateOrder();
        public Task UpdateOrder(int id);
    }
    public class OrderService : IOrder
    {
        private readonly ApplicationDbContext _context;
        private readonly IUser _user;
        private readonly ICart _cart;
        public Customer currentCustomer { get; set; }
        public List<Product> products { get; set; }
        public OrderService(ApplicationDbContext context, IUser user, ICart cart)
        {
            _context = context;
            _user = user;
            _cart = cart;
        }

        public async Task CreateOrder()
        {
            products = new List<Product>();
            currentCustomer = await _user.GetCurrentUserAsync();
            if (currentCustomer != null)
            {
                var shoppingList = _context.ShoppingCarts.Where(x => x.UserId == currentCustomer.Id).Select(x => x.Product).ToList();
                foreach (var product in shoppingList)
                {
                    products.Add(product);
                }
                Order order = new Order();
                order.UserId = currentCustomer.Id;
                order.User = currentCustomer;
                order.IsDone = false;
                order.Products = products;
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();

                await _cart.ClearCart();
            }
        }
        public async Task UpdateOrder(int id)
        {
            var order = _context.Orders.Where(x => x.Id == id).FirstOrDefault();
            order.IsDone = true;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            
        }
    }
}
