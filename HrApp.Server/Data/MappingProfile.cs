using AutoMapper;
using HrApp.Server.Data.DtoModels;
using HrApp.Server.Data.Models;

namespace HrApp.Server.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<UserAccount, UserAccountDto>();
        }
    }
}
