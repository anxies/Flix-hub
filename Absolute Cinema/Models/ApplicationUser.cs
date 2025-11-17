using Microsoft.AspNetCore.Identity;

namespace Absolute_Cinema.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int MyProperty { get; set; }
    }
}
