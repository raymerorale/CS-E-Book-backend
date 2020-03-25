namespace WebApi.Models.Answer
{
  public class UpdateAnswerModel
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public string AnswerContent { get; set; }
        public int UserId { get; set; }
    }
}