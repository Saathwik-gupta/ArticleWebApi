using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ArticleWebApi.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string StateName { get; set; }
        
        // Foreign Key
        public int CountryId { get; set; }

        [JsonIgnore]
        public virtual Country Country { get; set; }
        
        // Navigation property
        [JsonIgnore]
        public virtual ICollection<City> Cities { get; set; }
    }
}
