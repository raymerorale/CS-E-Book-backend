namespace WebApi.Entities
{
    public class ReadStatus
    {
        public int Id { get; set; }
        public int ChapterId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
    }
}