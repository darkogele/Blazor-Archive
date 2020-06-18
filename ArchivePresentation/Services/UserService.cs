using ArchiveCore.DTO;
using ArchivePresentation.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Text.Json;

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

        public async Task<UserForDetailedDto> GetUser(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<UserForDetailedDto>($"api/Users/{id}");
        }

        public async Task<HttpResponseMessage> LoginAsync(UserForLoginDto user)
        {
           // var response2 = await _httpClient.PostAsJsonAsync("api/Auth/login", user);
           // var s = JsonSerializer.Serialize(response2.Content);
           // var content = response2.Content.ReadFromJsonAsync<UserForDetailedDto>();
           //// var content2 = await response2.Content.ReadAsStringAsync();
           // response2.EnsureSuccessStatusCode();
            var response = await _httpClient.PostAsJsonAsync("api/Auth/login", user);
            // var returnResult = new UserForDetailedDto();
            //returnResult = responce.
            return response;
        }

        public async Task<HttpResponseMessage> RegisterUserAsync(UserForRegisterDto user)
        {
            // var json = JsonSerializer.Serialize(user);
            var response = await _httpClient.PostAsJsonAsync("api/Auth/register", user);

            return response;
        }
    }
}
