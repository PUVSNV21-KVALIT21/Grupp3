using Hakims_Livs.Data;
using Hakims_Livs.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hakims_Livs.Services
{
    public interface IUser
    {
        public Task<Customer> GetCurrentUserAsync();
        void GetUserFromName(string name);
    }

    public class User : IUser
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private System.Security.Claims.ClaimsPrincipal user { get; set; }
        private Customer currentCustomer { get; set; }
        private string username;
        private readonly UserManager<Customer> UserManager;
        private readonly ApplicationDbContext _context;
        public User(AuthenticationStateProvider authenticationStateProvider, ApplicationDbContext context)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _context = context;
        }
        public async Task<Customer> GetCurrentUserAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var username = user.Identity.Name;
            GetUserFromName(username);
            return currentCustomer;
        }
        public void GetUserFromName(string name)
        {
            currentCustomer = _context.Customers.Where(x => x.UserName == name).FirstOrDefault();
        }
    }

}
