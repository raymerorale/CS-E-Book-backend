namespace WebApi.Models.ReadStatus
{
  public class UpdateReadStatusModel
    {
        public int ChapterId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
    }
}