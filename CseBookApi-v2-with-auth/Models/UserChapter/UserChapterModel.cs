namespace WebApi.Models.UserChapter
{
  public class UserChapterModel
    {
        public int Id { get; set; }
        public int ChapterId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
    }
}