using System.ComponentModel.DataAnnotations;

namespace ArticleWebApi.DTO
{
    public class PackageDTO
    {
        [Key]
        [Required]
        public int PackageId { get; set; }

        [Required]
        [StringLength(100)]
        public string PackageName { get; set; }
        public decimal Price { get; set; }

        // Foreign Key
        public int ArticleGroupId { get; set; }
    }
}