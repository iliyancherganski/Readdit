using System.ComponentModel.DataAnnotations.Schema;

namespace Readdit.Data.Models.Requests
{
    public class CategoryRequest
    {
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;


        [ForeignKey(nameof(ResourceRequest))]
        public int RequestId { get; set; }
        public virtual ResourceRequest ResourceRequest { get; set; } = null!;
    }
}
