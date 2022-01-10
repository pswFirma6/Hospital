using AutoMapper;
using Hospital_library.MedicalRecords.Service.Interfaces;
using HospitalAPI.DTO;
using HospitalAPI.Validation;
using HospitalLibrary.MedicalRecords.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly LoginValidation _loginValidation;
        private readonly IMapper _mapper;
        private readonly ILoginService _loginService;

        public LoginController(LoginValidation loginValidation, IMapper mapper, IConfiguration config, ILoginService loginService)
        {
            _config = config;
            _loginValidation = loginValidation;
            _mapper = mapper;
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {

            if (!_loginValidation.IsValid(loginDTO))
            {
                return BadRequest();
            }

            var mapper = _mapper.Map<User>(loginDTO);
            var user = _loginService.AuthenticateUser(mapper);

            if (user != null)
            {
                var tokenString = _loginService.GenerateJSONWebToken(user, _config);
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }


    }
}
