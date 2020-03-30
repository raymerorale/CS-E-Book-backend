using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Chapter
{
    public class CreateChapterModel
    {
        [Required]
        public string Content { get; set; }
    }
}