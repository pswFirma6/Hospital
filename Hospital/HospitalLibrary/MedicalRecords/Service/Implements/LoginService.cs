using Hospital_library.MedicalRecords.Service.Interfaces;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using IdentityModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hospital_library.MedicalRecords.Service.Implements
{
    public class LoginService : ILoginService
    {
        private readonly RepositoryFactory _hospitalRepositoryFactory;
        

        public LoginService(RepositoryFactory hospitalRepositoryFactory)
        {
            _hospitalRepositoryFactory = hospitalRepositoryFactory;
        }

        public string GenerateJSONWebToken(User userInfo, IConfiguration _config)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("role" , userInfo.UserType.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public User AuthenticateUser(User userInfo)
        {

            if (userInfo.UserType.Equals(UserType.patient))
            {

                User user = _hospitalRepositoryFactory.GetPatientRepository().GetByLoginCredentials(userInfo.Username, userInfo.Password, userInfo.UserType);
                if(user == null)
                {
                    return null;
                }
                else if (user.Activated && !((Patient)user).Blocked) 
                {
                    return user;
                }
                else
                {
                    return null;
                }            

            } else if (userInfo.UserType.Equals(UserType.manager))
            {
                return _hospitalRepositoryFactory.GetManagerRepository().GetByLoginCredentials(userInfo.Username, userInfo.Password, userInfo.UserType);
            }

            return null;
        }

    }
}
