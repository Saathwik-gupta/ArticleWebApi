using System.ComponentModel.DataAnnotations;

namespace ArticleWebApi.DTO
{
    public class ArticleDTO
    {
        

    [Required]
    [StringLength(100)]
    public string Title { get; set; }

    public string Content { get; set; }

    }
}