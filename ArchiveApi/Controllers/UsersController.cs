using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArchiveCore.DTO;
using ArchiveSecurity.Contracts;
using ArchiveSecurity.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArchiveApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IUsers _users;

        public UsersController(IUsers users)
        {
            _users = users;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var result = await _users.GetUserById(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UserForUpdateDto userForUpdateDto)
        {
            if (id != userForUpdateDto.Id)
                return BadRequest("User ID missmatch");

            var userFound = await _users.GetUserById(id);
            if (userFound == null)
                return NotFound($"User with the Id = {id} was not found");

            var result = await _users.UpdateUser(userForUpdateDto);
            if (result.Succeeded)
                return Ok();

            return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Data");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var userToDelete = await _users.GetUserById(id);
            if (userToDelete == null)
                return NotFound($"User with the Id = {id} was not found");

            var result = await _users.DeleteUser(userToDelete);
            if (result.Succeeded)
                return Ok(userToDelete);

            return StatusCode(StatusCodes.Status500InternalServerError, "Error Deleting Data");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Search(string username, string email)
        {
            try
            {
                var result = await _users.Search(username, email);
                if (result.Any())
                    return Ok(result);
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retriving Data");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _users.GetUsers();
            if (result.Any())
                return Ok(result);
            return NotFound();
        }
    }
}
