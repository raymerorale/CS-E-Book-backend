using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IAnswerService
    {
        IEnumerable<Answer> GetAll();
        Answer GetById(int id);
        Answer Create(Answer userAnswer);
        void Update(Answer userAnswer);
        void Delete(int id);
    }

    public class AnswerService : IAnswerService
    {
        private DataContext _context;

        public AnswerService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Answer> GetAll()
        {
            return _context.Answer;
        }

        public Answer GetById(int id)
        {
            return _context.Answer.Find(id);
        }

        public Answer Create(Answer userAnswer)
        {
            ValidateAnswerParams(userAnswer);

            _context.Answer.Add(userAnswer);
            _context.SaveChanges();

            return userAnswer;
        }

        public void Update(Answer userAnswerParam)
        {
            var answer = _context.Answer.Find(userAnswerParam.Id);

            if (answer == null)
                throw new AppException("User Answer not found");

            ValidateAnswerParams(userAnswerParam);    

            _context.Answer.Update(answer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var answer = _context.Answer.Find(id);
            if (answer != null)
            {
                _context.Answer.Remove(answer);
                _context.SaveChanges();
            }
        }

        // private helper methods
        private static void ValidateAnswerParams(Answer userAnswer)
        {
            if (userAnswer.QuestionId == 0)
                throw new AppException("questionId is required.");

            if (userAnswer.AnswerId == 0)
                throw new AppException("answerId is required.");

            if (string.IsNullOrWhiteSpace(userAnswer.AnswerContent))
                throw new AppException("answerContent is required.");

            if (userAnswer.UserId == 0)
                throw new AppException("userId is required.");
        }
    }
}