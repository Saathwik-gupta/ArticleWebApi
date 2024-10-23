using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ArticleWebApi.Models
{
    public class Package
    {
        [Key]
        public int PackageId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string PackageName { get; set; }
        
        public decimal Price { get; set; }

        // Foreign Key
        public int ArticleGroupId { get; set; }

        [JsonIgnore]
        public virtual ArticleGroup ArticleGroup { get; set; }
    }
}
