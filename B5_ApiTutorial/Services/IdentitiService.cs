using B5_ApiTutorial.ConfigOptions;
using B5_ApiTutorial.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace B5_ApiTutorial.Services
{
    public class IdentitiService : IIdentitiService
    {
        //private readonly UserManager<IdentityUser> _UserManager;
        private readonly JwtSettings _jwtsetting;
        public IdentitiService(/*UserManager<IdentityUser> UserManager,*/ JwtSettings jwtsetting)
        {
            //_UserManager = UserManager;
            _jwtsetting = jwtsetting;
        }
        public async Task<AuThenticationResult> AuThenticationResultAsync(string email, string pass)
        {
            //var exuser = await _UserManager.FindByEmailAsync(email);
            if (email == null)
            {
                return new AuThenticationResult
                {
                    Error = new[] { "Dia chi Email Ton tai" }
                };
            }

            var newUser = new IdentityUser
            {
                Email = email,
                UserName = email
            };
            //var create = await _UserManager.CreateAsync(newUser, pass);
            var a = true;
            if (/*!create.Succeeded*/ !a)
            {
                return new AuThenticationResult
                {
                    Error = /*create.Errors.Select(x => x.Description)*/ new[] { "Dia chi  Ton tai" }
                };
            }

            var tokenhan = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtsetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                    new Claim("id", newUser.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenhan.CreateToken(tokenDescriptor);

            return new AuThenticationResult
            {
                success = true,
                token = tokenhan.WriteToken(token)
            };
        }
    }
}
