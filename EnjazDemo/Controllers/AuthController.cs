using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EnjazDemo.Forms;
using EnjazDemo.Models;
using Cipher = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EnjazDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly private EnjazDemoContext context;
        
        public AuthController(EnjazDemoContext context)
        {
            this.context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> login([FromBody]LoginForm login)
        {
            if (!ModelState.IsValid)
            {
               return BadRequest();
            }

            var user = context.UserModels.FirstOrDefault(x => x.username == login.username);
            if(user == null)
            {
               return BadRequest();
            }

            if (Cipher.Verify(login.password,user.password))
                BadRequest();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Guid.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName,user.username),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()), 
            };

            var token = new JwtSecurityToken
            (
                claims: claims,
                expires: DateTime.UtcNow.AddDays(3),
                notBefore: DateTime.UtcNow,
                audience: "Audience",
                issuer: "Issuer",
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("wwBI_HtXqI3UgQHQ_rDRnSQRxFL1SR8fbQoS-Hsau1")),
                    SecurityAlgorithms.HmacSha256)
            );

            return Ok (new { token = new JwtSecurityTokenHandler().WriteToken(token) });

        }

    }
}