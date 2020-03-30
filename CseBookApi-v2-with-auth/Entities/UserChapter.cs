namespace WebApi.Entities
{
    public class UserChapter
    {
        public int Id { get; set; }
        public int ChapterId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
    }
}