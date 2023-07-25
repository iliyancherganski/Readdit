using Readdit.Core.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Readdit.ViewModels.Categories
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {

        }
        public CategoryViewModel(List<string> categoryNames)
        {
            if (categoryNames == null)
            {
                CategoryNames = new List<string>();
            }
            else
            {
                CategoryNames = categoryNames;
            }
        }

        public int Id { get; set; }
        [Required]
        [StringLength(30), MinLength(3)]
        public string Name { get; set; } = null!;

        public List<string> CategoryNames { get; set; } = new List<string>();
    }
}
