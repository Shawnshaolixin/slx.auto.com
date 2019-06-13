using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Service;
using WebApplication2.Model;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        static string KEY = "5801F620-BEF3-4035-A218-016F4C146573";
        [HttpGet("get11")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        UserService _store;
        public IdentityController(UserService store)
        {
            _store = store;
        }
        [HttpGet]
        [Route("authenticate")]
        public IActionResult Authenticate()
        {
            var user = _store.FindUser("", "");
            if (user == null) return Unauthorized();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(KEY);
            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddDays(7);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(JwtClaimTypes.Audience,"api"),
            new Claim(JwtClaimTypes.Issuer,"http://localhost:5200"),
            new Claim(JwtClaimTypes.Id, user.Id.ToString()),
            new Claim(JwtClaimTypes.Name, user.Name),
            new Claim(JwtClaimTypes.Email, user.Email),
            new Claim(JwtClaimTypes.PhoneNumber, user.PhoneNumber)
                }),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new
            {
                access_token = tokenString,
                token_type = "Bearer",
                profile = new
                {
                    sid = user.Id,
                    name = user.Name,
                    auth_time = new DateTimeOffset(authTime).ToUnixTimeSeconds(),
                    expires_at = new DateTimeOffset(expiresAt).ToUnixTimeSeconds()
                }
            });
        }
    }
}