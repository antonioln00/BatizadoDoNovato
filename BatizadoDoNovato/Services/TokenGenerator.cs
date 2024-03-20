using System.IdentityModel.Tokens.Jwt;
using System.Text;
using BatizadoDoNovato.Constants;
using Microsoft.IdentityModel.Tokens;

namespace BatizadoDoNovato.Services;
public class TokenGenerator
{
    public string Generate()
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstants.Secret)),
                SecurityAlgorithms.HmacSha256Signature
            ),
            Expires = DateTime.Now.AddDays(1)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
