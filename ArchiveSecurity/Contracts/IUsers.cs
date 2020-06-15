using ArchiveCore.DTO;
using ArchiveData.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveSecurity.Contracts
{
    public interface IUsers
    {
        Task<IEnumerable<User>> GetUserss();
        Task<User> GetUserById(Guid id);
        Task<IdentityResult> UpdateUser(UserForUpdateDto userForUpdateDto);
        Task<IdentityResult> DeleteUser(User user);
        Task<IEnumerable<User>> Search(string username, string email);
    }
}
