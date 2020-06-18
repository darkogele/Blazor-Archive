using ArchiveCore.DTO;
using ArchiveData.Models;
using ArchiveSecurity.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveSecurity.Implementation
{
    public class Authentication : IAuthentication
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;

        private readonly IConfiguration _config;
        public Authentication(IConfiguration config, UserManager<User> userManager, IMapper mapper,
            SignInManager<User> signInManager)
        {
            _config = config;
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;

        }


        public async Task<UserForDetailedDto> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _userManager.FindByNameAsync(userForLoginDto.Username);
            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, userForLoginDto.Password, false);

                if (result.Succeeded)
                {
                    user.LastActive = DateTime.Now;
                    await _userManager.UpdateAsync(user);
                    var token = await GenerateJwtToken(user);
                    var userToReturn = _mapper.Map<UserForDetailedDto>(user);
                    userToReturn.Token = token;
                    
                    return userToReturn;
                }
            }

            return null;
        }

        public async Task<UserForDetailedDto> Register(UserForRegisterDto userForRegisterDto)
        {
            var userToCreate = _mapper.Map<User>(userForRegisterDto);

            var duplicateName = await _userManager.FindByNameAsync(userForRegisterDto.Username);

            var duplicateEmail = await _userManager.FindByEmailAsync(userForRegisterDto.Email);

            if (duplicateName != null)
                return new UserForDetailedDto { Username = "DUPLICATE" };

            if (duplicateEmail != null)
                return new UserForDetailedDto { Username = "", Email = "DUPLICATE" };

            var result = await _userManager.CreateAsync(userToCreate, userForRegisterDto.Password);

            var userToReturn = _mapper.Map<UserForDetailedDto>(userToCreate);

            if (result.Succeeded)
                return userToReturn;

            return null;
        }

        public async Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds,
                Issuer = _config.GetSection("AppSettings:Issuer").Value
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
