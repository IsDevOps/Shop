using Shop.Services.AppUser.Model;

namespace Shop.Services.AuthAPI.Service.IService
{
    public interface IJwtokenGenerator
    {
        string GenerateToken(AppUserModel appUserModel);

    }
}
