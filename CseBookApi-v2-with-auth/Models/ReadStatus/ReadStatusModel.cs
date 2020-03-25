namespace WebApi.Models.ReadStatus
{
  public class ReadStatusModel
    {
        public int Id { get; set; }
        public int ChapterId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
    }
}