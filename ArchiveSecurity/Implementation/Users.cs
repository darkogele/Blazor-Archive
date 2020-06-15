using ArchiveCore.DTO;
using ArchiveData.Models;
using ArchiveData.Repository;
using ArchiveSecurity.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchiveSecurity.Implementation
{
    public class Users : IUsers
    {
        private readonly ArchiveContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public Users(ArchiveContext context, IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IdentityResult> DeleteUser(User user)
        {
           return await _userManager.DeleteAsync(user);
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _context.Users.FindAsync(id);  //Where(x => x.Id == id).FirstOrDefaultAsync(); 
        }

        public async Task<IEnumerable<User>> GetUserss()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> Search(string username, string email)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(username))
                query = query.Where(u => u.UserName.Contains(username));

            if (!string.IsNullOrEmpty(email))
                query = query.Where(u => u.Email.Contains(email));

            return await query.ToListAsync();
        }

        public async Task<IdentityResult> UpdateUser(UserForUpdateDto userForUpdateDto)
        {
            var userForUpdate = _mapper.Map<User>(userForUpdateDto);
            return await _userManager.UpdateAsync(userForUpdate);
        }
    }
}
