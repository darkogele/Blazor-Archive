using ArchiveCore.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArchivePresentation.Services.Contract
{
    public interface IUserService
    {
        Task<HttpResponseMessage> LoginAsync(UserForLoginDto user);
        Task<HttpResponseMessage> RegisterUserAsync(UserForRegisterDto user);
        Task<IEnumerable<UserForDetailedDto>> GetUsers();
        Task<UserForDetailedDto> GetUser(Guid id);
    }
}
