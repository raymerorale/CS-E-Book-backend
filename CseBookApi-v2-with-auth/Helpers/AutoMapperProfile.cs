using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Users;
using WebApi.Models.ReadStatus;
using WebApi.Models.Answer;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User
            CreateMap<User, UserModel>();
            CreateMap<RegisterUserModel, User>();
            CreateMap<UpdateUserModel, User>();

            // Read Status
            CreateMap<ReadStatus, ReadStatusModel>();
            CreateMap<CreateReadStatusModel, ReadStatus>();
            CreateMap<UpdateReadStatusModel, ReadStatus>();

            // User Answer
            CreateMap<Answer, AnswerModel>();
            CreateMap<CreateAnswerModel, Answer>();
            CreateMap<UpdateAnswerModel, Answer>();
        }
    }
}