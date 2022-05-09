using Microsoft.AspNetCore.Identity;

namespace Hakims_Livs.Models
{
    public class ShoppingCart
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
        public Customer User {get;set;}
    }
}
