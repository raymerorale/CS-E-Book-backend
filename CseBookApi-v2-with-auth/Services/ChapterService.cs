using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IChapterService
    {
        IEnumerable<Chapter> GetAll();
        Chapter GetById(int id);
        Chapter Create(Chapter chapter);
        void Update(Chapter chapter);
        void Delete(int id);
        void DeleteAll();
    }

    public class ChapterService : IChapterService
    {
        private DataContext _context;

        public ChapterService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Chapter> GetAll()
        {
            return _context.Chapter;
        }
        public Chapter GetById(int id)
        {
            return _context.Chapter.Find(id);
        }
        public Chapter Create(Chapter chapter)
        {
            ValidateChapterParams(chapter);

            _context.Chapter.Add(chapter);
            _context.SaveChanges();

            return chapter;
        }
        public void Update(Chapter chapterParam)
        {
            var chapter = _context.Chapter.Find(chapterParam.Id);

            if (chapter == null)
                throw new AppException("Chapter not found");

            ValidateChapterParams(chapterParam);
            chapter.Content = chapterParam.Content;

            _context.Chapter.Update(chapter);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var chapter = _context.Chapter.Find(id);
            if (chapter != null)
            {
                _context.Chapter.Remove(chapter);
                _context.SaveChanges();
            }
        }
        public void DeleteAll()
        {
            _context.Chapter.RemoveRange(_context.Chapter);
            _context.SaveChanges();
        }

        // private helper methods
        private static void ValidateChapterParams(Chapter chapter) {
      
            if (string.IsNullOrWhiteSpace(chapter.Content))
                throw new AppException("content is required.");
        }
    }
}