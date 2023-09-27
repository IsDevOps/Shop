using Shop.Services.AuthAPI.DTO;

namespace Shop.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegisterRequestDTO requestDTO);
        Task<LoginResponseDTO> Login(LoginRequestDTO requestDTO);
    }
}
