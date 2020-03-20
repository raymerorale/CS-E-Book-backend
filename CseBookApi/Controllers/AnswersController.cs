using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CseBookApi.Models;

namespace CseBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly AnswerContext _context;

        public AnswersController(AnswerContext context)
        {
            _context = context;
        }

        // GET: api/Answers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAnswerDTO>>> GetUserAnswers()
        {
            return await _context.UserAnswers.Select(x => AnswerToDTO(x)).ToListAsync();
        }

        // GET: api/Answers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAnswerDTO>> GetUserAnswer(long id)
        {
            var userAnswer = await _context.UserAnswers.FindAsync(id);

            if (userAnswer == null)
            {
                return NotFound();
            }

            return AnswerToDTO(userAnswer);
        }

        // PUT: api/Answers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAnswer(long id, UserAnswerDTO userAnswer)
        {
            if (id != userAnswer.Id)
            {
                return BadRequest();
            }

            _context.Entry(userAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAnswerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Answers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserAnswer>> PostUserAnswer(UserAnswerDTO userAnswerDTO)
        {
            _context.UserAnswers.Add(userAnswer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserAnswer), new { id = userAnswer.Id }, AnswerToDTO(userAnswer));
        }

        // DELETE: api/Answers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserAnswer>> DeleteUserAnswer(long id)
        {
            var userAnswer = await _context.UserAnswers.FindAsync(id);
            if (userAnswer == null)
            {
                return NotFound();
            }

            _context.UserAnswers.Remove(userAnswer);
            await _context.SaveChangesAsync();

            return userAnswer;
        }

        private bool UserAnswerExists(long id)
        {
            return _context.UserAnswers.Any(e => e.Id == id);
        }

        private static UserAnswerDTO AnswerToDTO(UserAnswer userAnswer) =>
            new UserAnswerDTO
            {
                Id = userAnswer.Id,
                Content = userAnswer.Content,
                QuestionCode = userAnswer.QuestionCode,
                UserId = userAnswer.UserId
            }
    }
}
