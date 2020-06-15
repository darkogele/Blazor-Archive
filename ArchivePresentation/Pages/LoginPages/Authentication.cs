using ArchiveCore.DTO;
using ArchivePresentation.Services.Contract;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchivePresentation.Pages.LoginPages
{
    public class Authentication : ComponentBase
    {
        [Inject]
        public IUserService userService { get; set; }

        public IEnumerable<UserForDetailedDto> Users { get; set; }

        protected UserForRegisterDto User = new UserForRegisterDto();

        protected override async Task OnInitializedAsync()
        {
            Users = (await userService.GetUsers()).ToList();
        }

        protected void RegisterUser(UserForRegisterDto userForRegisterDto)
        {


        }
    }
}
