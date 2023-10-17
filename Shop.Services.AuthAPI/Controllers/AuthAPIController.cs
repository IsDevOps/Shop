using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Services.AppUser.Model;
using Shop.Services.AuthAPI.DTO;
using Shop.Services.AuthAPI.Service.IService;

namespace Shop.Services.AuthAPI.Controllers
{
    [Route("/api/auth")]
    [ApiController]
    public class AuthAPIController:ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDTO _response;
        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _response = new();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO model)
        {
            var errorMessage = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccessful = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            return Ok();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var logingRequest = await _authService.Login(model);
            if (logingRequest.User == null)
            {
                _response.IsSuccessful = false;
                _response.Message = "Username or Password incorrect";
                   return BadRequest(_response);
                    
            }
            _response.Result = logingRequest;
            return Ok(_response);
        }
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegisterRequestDTO model)
        {
            var assignRole = await _authService.AssignRole(model.Email.ToUpper(),model.Role);
            if (!assignRole)
            {
                _response.IsSuccessful = false;
                _response.Message = "Error Assigning role ";
                return BadRequest(_response);

            }
            _response.Result = assignRole;
            return Ok(_response);
        }
    }
}
