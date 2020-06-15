using ArchiveCore.DTO;
using ArchiveSecurity.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace ArchiveApi.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthentication _authentication;

        public AuthController(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var result = await _authentication.Register(userForRegisterDto);
            if (result.Username.Equals("DUPLICATE"))
            {
                ModelState.AddModelError("username", "An account with username already exists");
                return BadRequest(ModelState);
            }
              
            if (result.Email.Equals("DUPLICATE"))
            {
                ModelState.AddModelError("email", "An account with this email already exists");
                return BadRequest(ModelState);
            }
               

            if (result != null)
                return Ok("Log in with your new account ");

            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var result = await _authentication.Login(userForLoginDto);
            if (result != null)
            {
                return Ok(new { token = await _authentication.GenerateJwtToken(result) });
            };

            return Unauthorized();
        }
    }
}
