using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Users;
using WebApi.Models.ReadStatus;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            CreateMap<ReadStatus, ReadStatusModel>();
            CreateMap<CreateModel, ReadStatus>();
        }
    }
}