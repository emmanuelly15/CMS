using CommonModels.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Authentication
{
    public class JwtAuthenticationManager
    {
        public const string JWT_SECURITY_KEY = "JpOiYtrrEweTbnmJG7&43vNjbx";
        private const int JWT_TOKEN_VALIDATY_MINS = 20;

        private AdminAccountService _adminAccountService;

        public JwtAuthenticationManager(AdminAccountService adminAccountService)
        {
            _adminAccountService = adminAccountService;
        }

        public AdminSession? GenerateJwtToken(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                return null;

            /*Validating the Admin Credentials */
            var adminAccount = _adminAccountService.GetAdminAccountByUserName(userName);
            if (adminAccount == null || adminAccount.AdminPassword != password)
                return null;

            /* Generating JWT Token */
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDATY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, adminAccount.UserName),
                new Claim(ClaimTypes.Role, adminAccount.Role)
            });
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            /* Returning the AdminSession object */
            var adminSession = new AdminSession
            {
                UserName = adminAccount.UserName,
                Role = adminAccount.Role,
                Token = token,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };
            return adminSession;

        }
    }
}
