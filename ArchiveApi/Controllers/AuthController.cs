using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ArchiveCore.DTO;
using ArchiveData.Models;
using ArchiveSecurity.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
