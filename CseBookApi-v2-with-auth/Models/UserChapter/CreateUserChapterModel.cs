using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.UserChapter
{
    public class CreateUserChapterModel
    {
        [Required]
        public int ChapterId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Status { get; set; }
    }
}