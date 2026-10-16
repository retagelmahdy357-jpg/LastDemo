using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LastDemo.Data;
using LastDemo.DTO;
using LastDemo.Model;
using LastDemo.Repo.IRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LastDemo.Repo
{
    public class AuthRepo : IAuth
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthRepo(AppDbContext context, IConfiguration configuration)
        {
             _context = context;
            _configuration = configuration;
        }
        public async Task<string> Login(AppUserDto userDto)
        {
            var eu=await _context.AppUsers.Where(x=>x.Email==userDto.Email).FirstOrDefaultAsync();
            if (eu == null)
            {
                return null;
            }
            if (eu.Password == userDto.Password)
            {
                return GenerateToken(eu.Email, eu.Role);
            }
            else
            {
                return null;
            }

        }
        private string GenerateToken(string email,string role)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Email, email)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var Card=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

         var tokenn=   new JwtSecurityToken(

                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["JWT:ExpireDate"])),
              signingCredentials: Card

                );
            var stringtoken=new JwtSecurityTokenHandler().WriteToken(tokenn);
            return stringtoken;
        }

        public async Task<bool> Rigester(AppUser user)
        {
            var nu= await _context.AppUsers.AnyAsync(x=>x.Email==user.Email);
            if (nu)
            {
                return false;
            }
            await _context.AppUsers.AddAsync(user);
            return true;
        }
    }
}
