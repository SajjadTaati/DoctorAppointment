using DoctorAppointment.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Infrastructure.Persistence.Services
{
    // Infrastructure/Services/JwtService.cs
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        // پیاده‌سازی متد مطابق با اینترفیس
        public string GenerateUserToken(int userId, string phone)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Secret"]!));

            // چطور role رو از phone بگیری؟ یا باید phone رو claim کنی یا role رو در constructor یا جای دیگه ست کنی
            // فرض کنیم می‌خوایم phone رو claim کنیم چون role نداریم
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()), // userId رو به string تبدیل کن
            new Claim("phone", phone) // یا اگر claim مربوط به phone داری
            // new Claim(ClaimTypes.Role, GetRoleForUser(userId)) // اگر متدی داری که role رو بر اساس userId بده
        };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // اگر خواستی AdminToken رو هم اضافه کنی
        // public string GenerateAdminToken(int adminId, string username)
        // {
        //     // ...
        //     return "admin_token_here";
        // }
    }

}
