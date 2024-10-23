using System.ComponentModel.DataAnnotations;

namespace ArticleWebApi.Models.Mappings
{
    public class Article_ArticleGroup
    {
        [Key]
        public int Id { get; set; }

        // Foreign Keys
        public int ArticleId { get; set; }
        public int ArticleGroupId { get; set; }

        // Navigation properties
        public virtual Article Article { get; set; }
        public virtual ArticleGroup ArticleGroup { get; set; }
    }
}
