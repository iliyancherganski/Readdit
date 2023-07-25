using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Readdit.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace Readdit.Data.Models.Resources
{
    public class Resource
    {
        public Resource()
        {
            CategoryResources = new List<CategoryResource>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public ResourceType Type { get; set; }

        [Required]
        [MaxLength(40)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(40)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string Description { get; set; } = null!;

        // Status - 
        [Required]
        public ResourceStatus Status { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        public DateTime? ExpectedReturnDate { get; set; }

        [Required]
        public string OfficialPageUrl { get; set; } = null!;

        public string? FilePathOrUrl { get; set; }

        public virtual ICollection<CategoryResource> CategoryResources { get; set; }
    }
}
