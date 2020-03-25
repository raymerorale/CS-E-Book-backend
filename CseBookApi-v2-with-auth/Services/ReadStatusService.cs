using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IReadStatusService
    {
        IEnumerable<ReadStatus> GetAll();
        ReadStatus GetById(int id);
        ReadStatus Create(ReadStatus readStatus);
        void Update(ReadStatus readStatus);
        void Delete(int id);
    }

    public class ReadStatusService : IReadStatusService
    {
        private DataContext _context;

        public ReadStatusService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<ReadStatus> GetAll()
        {
            return _context.ReadStatus;
        }

        public ReadStatus GetById(int id)
        {
            return _context.ReadStatus.Find(id);
        }

        public ReadStatus Create(ReadStatus readStatus)
        {
            ValidateReadStatusParams(readStatus);

            if (_context.ReadStatus.Any(x => x.ChapterId == readStatus.ChapterId && x.UserId == readStatus.UserId && x.Status == readStatus.Status))
                throw new AppException("ReadStatus data already exists.");

            _context.ReadStatus.Add(readStatus);
            _context.SaveChanges();

            return readStatus;
        }

        public void Update(ReadStatus readStatusParam)
        {
            var readStatus = _context.ReadStatus.Find(readStatusParam.Id);

            if (readStatus == null)
                throw new AppException("Read Status not found");

            _context.ReadStatus.Update(readStatus);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var readStatus = _context.ReadStatus.Find(id);
            if (readStatus != null)
            {
                _context.ReadStatus.Remove(readStatus);
                _context.SaveChanges();
            }
        }

        // private helper methods
        private static void ValidateReadStatusParams(ReadStatus readStatus) {
            if (readStatus.ChapterId == 0)
                throw new AppException("ChapterId is required.");

            if (readStatus.UserId == 0)
                throw new AppException("UserId is required.");

            if (string.IsNullOrWhiteSpace(readStatus.Status))
                throw new AppException("Status is required.");

            string[] validStatusArray = { "ENABLED", "DISABLED", "IN PROGRESS" };
            if (!validStatusArray.Contains(readStatus.Status.ToUpper()))
                throw new AppException("Status must be in ['ENABLED', 'DISABLED', 'IN PROGRESS' ]");
        }

    }
}