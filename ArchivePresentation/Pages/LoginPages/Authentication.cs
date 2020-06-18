using ArchiveCore.DTO;
using ArchivePresentation.Services.Contract;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;


namespace ArchivePresentation.Pages.LoginPages
{
    public class Authentication : ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }

        protected UserForRegisterDto UserForRegister = new UserForRegisterDto();

        protected UserForLoginDto UserForLogin = new UserForLoginDto();
        
        protected UserForDetailedDto UserForDetailed = new UserForDetailedDto();

        protected string Responce { get; set; } = string.Empty;


        protected async Task<string> RegisterUser(UserForRegisterDto userForRegisterDto)
        {
            var result = await UserService.RegisterUserAsync(userForRegisterDto);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // return content = result.Content.ToString();
                var content = await result.Content.ReadFromJsonAsync<Object>();
                return "OK";
            }
            else
            {
                var content = await result.Content.ReadFromJsonAsync<Object>();
                return result.StatusCode.ToString();
            }
        }

        protected async Task<string> LoginUser(UserForLoginDto userForLoginDto)
        {
            var result = await UserService.LoginAsync(userForLoginDto);
            var s = result.EnsureSuccessStatusCode();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    var content = result.Content.ReadFromJsonAsync<UserForDetailedDto>();

                    await LocalStorageService.SetItemAsync("User", await content);

                    UserForDetailed = (await content);

                    return UserForDetailed.Username;
                    var something = System.Text.Json.JsonSerializer.Serialize(content);
                    return something;
                }
                catch (Exception ex)
                {
                    return ex.Message;

                }

                return "OK";
            }
            else
            {
                return result.StatusCode.ToString();
            }


        }


        protected async Task HandleSubmitRegister(EditContext editContext)
        {
            bool isValid = editContext.Validate();
            // var responce = "";
            if (isValid)
            {

                Responce = await RegisterUser(UserForRegister);
            }
            else
            {
                // ...
            }
            //return responce;
        }

        protected async Task HandleSubmitLogin(EditContext editContext)
        {
            bool isValid = editContext.Validate();

            if (isValid)
            {
                Responce = await LoginUser(UserForLogin);
            }
            else
            {
                // ...
            }

        }
    }
}
