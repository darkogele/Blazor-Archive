using ArchiveCore.DTO;
using ArchiveData.Models;
using AutoMapper;

namespace ArchiveSecurity.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserForLoginDto, User>().ReverseMap();
            CreateMap<UserForRegisterDto, User>().ReverseMap();
            CreateMap<User, UserForDetailedDto>().ReverseMap();
        }
    }
}
