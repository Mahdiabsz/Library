
using Microsoft.AspNetCore.Identity;

namespace Library.DomainClasses.Auth
{
    public class MyUser : IdentityUser
    {
        public string Name { get; set; }
        public string Family { get; set; }
    }
}
