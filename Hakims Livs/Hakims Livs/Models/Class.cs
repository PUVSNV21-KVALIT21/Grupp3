using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hakims_Livs.Models
{
    public class Customer : IdentityUser
    {
        //Ta bort nullbart när fälten är tillagda på registrering
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public DateTime? Created { get; set; }
        public int? Age { get; set; }
        [NotMapped]
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
    }
}
