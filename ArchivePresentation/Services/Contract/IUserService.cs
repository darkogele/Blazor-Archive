using ArchiveCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchivePresentation.Services.Contract
{
    public interface IUserService
    {
        public Task<UserForDetailedDto> LoginAsync(UserForLoginDto user);
        public Task<UserForDetailedDto> RegisterUserAsync(UserForRegisterDto user);
        public Task<IEnumerable<UserForDetailedDto>> GetUsers();
    }
}
