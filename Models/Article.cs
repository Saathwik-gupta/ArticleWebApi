using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ArticleWebApi.Models.Mappings;

namespace ArticleWebApi.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        
        public string Content { get; set; }
        
        // Additional Properties
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; 

        [Required]
        public bool IsActive { get; set; } = true; 

        

        // Navigation properties
        [JsonIgnore]
        public virtual ICollection<Article_ArticleGroup> Article_ArticleGroups { get; set; }

        [JsonIgnore]
        public virtual ICollection<Article_City> Article_Cities { get; set; }
    }
}
