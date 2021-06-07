using Crud.DTOS.Entity;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Crud.ApplicationCore.Helpers.Security
{
    public static class CripAlgoritmo
    {

        public static string Criptografar(string password)
        {
            byte[] messageBytes = Convert.FromBase64String(password);
            SHA256 shHash = SHA256.Create();
            return Convert.ToBase64String(shHash.ComputeHash(messageBytes));
        }

        public static string GenerationJwToken(Usuario user)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.Name, user.Nome + " " + user.Sobrenome)
            };

            foreach (var role in user.UserRole)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII
                                .GetBytes("SuperSecretKeyssssssssssssssssssssssssssssss"));


            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
