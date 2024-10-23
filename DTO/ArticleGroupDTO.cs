using System.ComponentModel.DataAnnotations;

namespace ArticleWebApi.DTO
{
    public class ArticleGroupDTO
    {

        [Key]
        [Required]
        public int ArticleGroupId { get; set; }

        [Required]
        [StringLength(100)]
        public string GroupName { get; set; }

    }
}