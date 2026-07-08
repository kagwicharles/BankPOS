using Microsoft.AspNetCore.Identity;

namespace BankPOS.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string OtherNames { get; set; } = null!;
        public string StaffEmail { get; set; } = null!;
    }
}