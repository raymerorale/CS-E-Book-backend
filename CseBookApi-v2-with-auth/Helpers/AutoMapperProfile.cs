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
            CreateMap<RegisterUserModel, User>();
            CreateMap<UpdateUserModel, User>();
            CreateMap<ReadStatus, ReadStatusModel>();
            CreateMap<CreateReadStatusModel, ReadStatus>();
            CreateMap<UpdateReadStatusModel, ReadStatus>();

        }
    }
}