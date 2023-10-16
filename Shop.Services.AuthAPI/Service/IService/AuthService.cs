using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Shop.Services.AppUser.Model;
using Shop.Services.AuthAPI.Database;
using Shop.Services.AuthAPI.DTO;

namespace Shop.Services.AuthAPI.Service.IService
{
    public class AuthService : IAuthService
    {
        private readonly DatabaseContext _db;
        private readonly UserManager<AppUserModel> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtokenGenerator _jwtokenGenerator;


        public AuthService(DatabaseContext db, UserManager<AppUserModel> userManager, RoleManager<IdentityRole> roleManager,IJwtokenGenerator jwtokenGenerator)
        {
            _db = db;
            _jwtokenGenerator = jwtokenGenerator;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO requestDTOs)
        {
            var user = _db.AppUserModel.FirstOrDefault(u => u.UserName.ToLower() == requestDTOs.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, requestDTOs.Password);
            if (user == null || isValid == false)
            {
                return new LoginResponseDTO() { User = null, Token = "" };

            }

            //Generate Token if user is found
            var token = _jwtokenGenerator.GenerateToken(user);

            UserDTO userDTO = new()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                Phone = user.PhoneNumber
            };
            LoginResponseDTO loginRequestDTO = new()
            {
                User = userDTO,
                Token = "",

            };
            return loginRequestDTO;
        }

        
        public async Task<string> Register(RegisterRequestDTO registerRequestDTO)
        {
            AppUserModel user = new()
            {

                UserName = registerRequestDTO.Email,
                Email = registerRequestDTO.Email,
                NormalizedEmail = registerRequestDTO.Email.ToLower(),
                Name = registerRequestDTO.Name,
                PhoneNumber = registerRequestDTO.PhoneNumber
            };
            try
            {
                var result = await _userManager.CreateAsync(user, registerRequestDTO.Password);
                if(result.Succeeded)
                {
                    var userToReturn = _db.AppUserModel.First(u=>u.UserName == registerRequestDTO.Email);

                    UserDTO userDtos = new()
                    {
                        Email = userToReturn.Email,
                        Name = userToReturn.Name,
                        Phone = userToReturn.PhoneNumber,
                        Id = userToReturn.Id
                    };

                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }catch(Exception ex)
            {
                return "Error Encounted";
            }
        }
    }
}
