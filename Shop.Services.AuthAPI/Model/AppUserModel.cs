using Microsoft.AspNetCore.Identity;
using Shop.Services.AuthAPI.Database;

namespace Shop.Services.AppUser.Model
{
    public class AppUserModel: IdentityUser
    {
        public string? Name { get; set; }
    }
}
