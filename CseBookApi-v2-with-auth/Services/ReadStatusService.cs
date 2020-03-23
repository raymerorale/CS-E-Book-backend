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


    }
}