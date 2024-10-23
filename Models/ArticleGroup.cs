using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ArticleWebApi.Models.Mappings;

namespace ArticleWebApi.Models
{
    public class ArticleGroup
    {
        [Key]
        public int ArticleGroupId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string GroupName { get; set; }
        
        // Navigation properties
        [JsonIgnore]
        public virtual ICollection<Article_ArticleGroup> Article_ArticleGroups { get; set; }

        [JsonIgnore]
        public virtual ICollection<Package> Packages { get; set; }
    }
}
