using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Users;
using WebApi.Models.Chapter;
using WebApi.Models.UserChapter;
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

            // Chapter
            CreateMap<Chapter, ChapterModel>();
            CreateMap<CreateChapterModel, Chapter>();
            CreateMap<UpdateChapterModel, Chapter>();

            // User Chapter
            CreateMap<UserChapter, UserChapterModel>();
            CreateMap<CreateUserChapterModel, UserChapter>();
            CreateMap<UpdateUserChapterModel, UserChapter>();

            // User Answer
            CreateMap<Answer, AnswerModel>();
            CreateMap<CreateAnswerModel, Answer>();
            CreateMap<UpdateAnswerModel, Answer>();
        }
    }
}