namespace WebApi.Models.UserChapter
{
  public class UpdateUserChapterModel
    {
        public int ChapterId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
    }
}