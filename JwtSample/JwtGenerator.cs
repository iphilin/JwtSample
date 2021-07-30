using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JwtSample
{
    public class JwtGenerator
    {
        public string Generate(string secret, DateTime iat, DateTime expire, string username)
        {
            var decodedKey = Convert.FromBase64String(secret);
            var signingKey = new SymmetricSecurityKey(decodedKey);
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            var claims = new Dictionary<string, object>
            {
                {"wmver", 2},
                {"wmidfmt", "ascii"},
                {"wmidtyp", 1},
                {"wmkeyver", 1},
                {"wmidlen", 512},
                {"wmid", Convert.ToBase64String(Encoding.ASCII.GetBytes(username))},
                {"wmopid", 32},
            };
            var payload = 
                new JwtPayload(
                    null,
                    null,
                    null,
                    claims,
                    null,
                    expire, 
                    iat);
            
            var jwt = new JwtSecurityToken(header, payload);
            
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}