using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ArticleWebApi.Models.Mappings;

namespace ArticleWebApi.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        [StringLength(100)]
        public string CityName { get; set; }

        // Foreign Key
        public int StateId { get; set; }

        [JsonIgnore]
        public virtual State State { get; set; }
        
        // Navigation property for many-to-many relationship
        [JsonIgnore]
        public virtual ICollection<Article_City> Article_Cities { get; set; }
    }
}
