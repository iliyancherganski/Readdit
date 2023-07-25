using Readdit.Data.Models.Enums;
using Readdit.Data.Models.Resources.Actions;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Readdit.Data.Models.Requests
{
    public class ResourceRequest
    {
        public ResourceRequest()
        {
            Categories = new List<Category>();
            RequestFollows = new List<RequestFollow>();
            RequestUpvotes = new List<RequestUpvote>();
        }

        [Key]
        public int Id { get; set; }
        // TODO: gbhthyjyuu

        // UserId - the Guid user Id
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public virtual IdentityUser User { get; set; } = null!;

        [Required]
        [MaxLength(40)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(40)]
        public string Author { get; set; } = null!;

        [Required]
        public RequestStatus Status { get; set; }

        [Required]
        public RequestPriority Priority { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [MaxLength(200)]
        public string Justification { get; set; } = null!;

        [MaxLength(200)]
        public string? RejectionJustification { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = null!;
        public virtual ICollection<RequestFollow> RequestFollows { get; set; } = null!;
        public virtual ICollection<RequestUpvote> RequestUpvotes { get; set; } = null!;
    }
}
