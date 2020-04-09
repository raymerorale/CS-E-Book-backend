using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IUserChapterService
    {
        IEnumerable<UserChapter> GetAll();
        UserChapter GetById(int id);
        IEnumerable<UserChapter> GetByUserId(int userId);
        UserChapter Create(UserChapter userChapter);
        void Update(UserChapter userChapter);
        UserChapter UpdateByUserIdAndChapterId(UserChapter userChapter);
        void DeleteAll();
        void Delete(int id);
    }

    public class UserChapterService : IUserChapterService
    {
        private DataContext _context;

        public UserChapterService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<UserChapter> GetAll()
        {
            return _context.UserChapter;
        }

        public UserChapter GetById(int id)
        {
            return _context.UserChapter.Find(id);
        }

        public IEnumerable<UserChapter> GetByUserId(int userId)
        {
            return _context.UserChapter.Where(x => x.UserId == userId);
        }

        public UserChapter Create(UserChapter userChapter)
        {
            userChapter.Status = "ENABLED";    

            ValidateUserChapterParams(userChapter);

            if (_context.UserChapter.Any(x => x.ChapterId == userChapter.ChapterId && x.UserId == userChapter.UserId && x.Status == userChapter.Status))
                throw new AppException("User Chapter data already exists.");

            _context.UserChapter.Add(userChapter);
            _context.SaveChanges();

            return userChapter;
        }

        public void Update(UserChapter userChapterParam)
        {
            var userChapter = _context.UserChapter.Find(userChapterParam.Id);

            if (userChapter == null)
                throw new AppException("User Chapter not found");

            ValidateUserChapterParams(userChapterParam);    

            _context.UserChapter.Update(userChapter);
            _context.SaveChanges();
        }

        public UserChapter UpdateByUserIdAndChapterId(UserChapter userChapterParam)
        {
            var userChapter = _context.UserChapter.FirstOrDefault(x => x.UserId == userChapterParam.UserId && x.ChapterId == userChapterParam.ChapterId);

            if (userChapter == null)
                throw new AppException("User Chapter not found");

            ValidateUserChapterParams(userChapterParam); 
            userChapter.Status = userChapterParam.Status;

            _context.UserChapter.Update(userChapter);
            _context.SaveChanges();

            return userChapter;
        }
        public void Delete(int id)
        {
            var userChapter = _context.UserChapter.Find(id);
            if (userChapter != null)
            {
                _context.UserChapter.Remove(userChapter);
                _context.SaveChanges();
            }
        }
        public void DeleteAll()
        {
            _context.UserChapter.RemoveRange(_context.UserChapter);
            _context.SaveChanges();
        }

        // private helper methods
        private static void ValidateUserChapterParams(UserChapter userChapter) {
            if (userChapter.ChapterId == 0)
                throw new AppException("chapterId is required.");

            if (userChapter.UserId == 0)
                throw new AppException("userId is required.");

            if (string.IsNullOrWhiteSpace(userChapter.Status))
                throw new AppException("status is required.");

            string[] validStatusArray = { "ENABLED", "DISABLED", "IN PROGRESS" };
            if (!validStatusArray.Contains(userChapter.Status.ToUpper()))
                throw new AppException("status must be in ['ENABLED', 'DISABLED', 'IN PROGRESS' ]");
        }
    }
}