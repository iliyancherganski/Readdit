using Readdit.Data.Models.Requests;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Readdit.Data.Models.Resources.Actions
{
    public class RequestFollow
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public virtual IdentityUser User { get; set; } = null!;


        [ForeignKey(nameof(ResourceRequest))]
        public int RequestId { get; set; }
        public virtual ResourceRequest ResourceRequest { get; set; } = null!;
    }
}
