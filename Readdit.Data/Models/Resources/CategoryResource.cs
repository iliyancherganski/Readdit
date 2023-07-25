using System.ComponentModel.DataAnnotations.Schema;

namespace Readdit.Data.Models.Resources
{
    public class CategoryResource
    {
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        [ForeignKey(nameof(Resource))]
        public int ResourceId { get; set; }
        public virtual Resource Resource { get; set; } = null!;
    }
}
