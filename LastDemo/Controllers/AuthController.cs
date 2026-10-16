using LastDemo.DTO;
using LastDemo.Model;
using LastDemo.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(AppUserDto appUserDto)
        {

            var us=await _unitOfWork.auth .Login(appUserDto);
            if (us == null)
            {
                return Unauthorized();
            }
            return Ok(us);
        }

        [HttpPost("Rigester")]
        public async Task<IActionResult> Rigester(RigesterDto appUserDto)
        {
            if (appUserDto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            var newuser = new AppUser
            {
                Name = appUserDto.Name,
                Email = appUserDto.Email,
                Password = appUserDto.Password,
                Role = appUserDto.Role,
            };
           var resut= await _unitOfWork.auth .Rigester(newuser);
            if (resut) {
                await _unitOfWork.Save();
                return Ok("Rigester Succsesfully");
            }
            else
            {
                return BadRequest("Email Allredy Exsit");
            }
        }

    }
}
   