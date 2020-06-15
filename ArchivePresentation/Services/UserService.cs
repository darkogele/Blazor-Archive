using ArchiveCore.DTO;
using ArchivePresentation.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace ArchivePresentation.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            //_httpClient.BaseAddress = new Url
        }

        public async Task<IEnumerable<UserForDetailedDto>> GetUsers()
        {
            return await _httpClient.GetFromJsonAsync<UserForDetailedDto[]>("api/Users");
        }

        public Task<UserForDetailedDto> LoginAsync(UserForLoginDto user)
        {
            throw new NotImplementedException();
        }

        public Task<UserForDetailedDto> RegisterUserAsync(UserForRegisterDto user)
        {
            throw new NotImplementedException();
        }
    }
}
