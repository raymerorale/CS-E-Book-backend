using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Answer
{
    public class CreateAnswerModel
    {
        [Required]
        public int QuestionId { get; set; }

        [Required]
        public int AnswerId { get; set; }

        [Required]
        public string AnswerContent { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}