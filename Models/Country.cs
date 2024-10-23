using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ArticleWebApi.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string CountryName { get; set; }
        
        // Navigation property
        [JsonIgnore]
        public virtual ICollection<State> States { get; set; }
    }
}
