using AutoMapper;
using HrApp.Server.Data;
using HrApp.Server.Data.DtoModels;
using HrApp.Server.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HrApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AuthController(AppDbContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }

        /// <summary>
        /// Регистрация пользователя.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserAccountDto user)
        {
            // Добавление простейшей логики валидации пароля и проверки существования пользователя
            if (await _context.UserAccounts.AnyAsync(u => u.Login == user.Login))
            {
                return BadRequest($"Пользователь под логином \"{user.Login}\" уже зарегистрирован в системе.");
            }

            var dbUser = _mapper.Map<UserAccount>(user);
            // TODO: захешировать пароли.
            await _context.UserAccounts.AddAsync(dbUser);
            await _context.SaveChangesAsync();

            return Ok(dbUser.Id);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserAccountDto user)
        {
            var dbUser = await _context.UserAccounts
                .SingleOrDefaultAsync(u => u.Login == user.Login && u.Password == user.Password);

            if (dbUser == null)
                return Unauthorized();

            // Генерация токена
            var tokenHandler = new JwtSecurityTokenHandler();
            string keyJwtConfig = _config.GetSection("Jwt").GetValue<string>("Key") 
                ?? throw new Exception("Добавьте секцию Jwt в файл appsettings.json");

            var key = Encoding.UTF8.GetBytes(keyJwtConfig);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, dbUser.Id.ToString()),
                    new Claim(ClaimTypes.Name, dbUser.Login)
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { Token = tokenHandler.WriteToken(token) });
        }
    }
}
