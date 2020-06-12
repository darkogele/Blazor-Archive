using ArchiveCore.DTO;
using ArchiveData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArchiveSecurity.Contracts
{
    public interface IAuthentication
    {
        Task<UserForDetailedDto> Register(UserForRegisterDto userForRegisterDto);
        Task<User> Login(UserForLoginDto userForLoginDto);
        Task<string> GenerateJwtToken(User user);
    }
}
