using System.ComponentModel.DataAnnotations;

namespace ArticleWebApi.Models.Mappings
{
    public class Article_City
    {
        [Key]
        public int Id { get; set; }

        // Foreign Keys
        public int ArticleId { get; set; }
        public int CityId { get; set; }

        // Navigation properties
        public virtual Article Article { get; set; }
        public virtual City City { get; set; }
    }
}
