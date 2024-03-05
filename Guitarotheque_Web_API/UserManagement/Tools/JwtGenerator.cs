
using Guitarotheque_Web_API.UserManagement.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_DemoBlazor.Tools
{
    public class JwtGenerator
    {
        public static string secretKey = "Est-ce qu'on peut s'en servir pour donner de l'élan à un pigeon ?";

        public string GenerateToken(User u)
        {
            //Signing Key
            //Microsoft.IdentityModel.Tokens
            SymmetricSecurityKey securityKey = 
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            //Payload
            Claim[] myClaims = new Claim[]
            {
                new Claim(ClaimTypes.GivenName, u.Nickname),
                new Claim(ClaimTypes.Role, u.IsAdmin ? "Admin" : "User")
            };
            //System.IdentityModel.Tokens.JWT
            JwtSecurityToken jwt = new JwtSecurityToken(
                claims : myClaims,
                signingCredentials: credentials,
                expires : DateTime.Now.AddDays(1),
                audience : "monapp.com", //le domaine qui consomme le token
                issuer : "monapi.com" //le domaine qui génère le token
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(jwt);
        }
    }
}
