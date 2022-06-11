
using Microsoft.AspNetCore.Identity;

namespace Library.DomainClasses.Auth
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Family { get; set; }
    }
}
