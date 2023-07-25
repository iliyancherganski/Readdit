using Readdit.Core.DTOs;
using Readdit.Data.Models.Enums;
using Readdit.ViewModels.Choosable;
using System.ComponentModel.DataAnnotations;

namespace Readdit.Models.Requests
{
    public class RequestEditViewModel
    {
        public RequestEditViewModel()
        {

        }
        public RequestEditViewModel(RequestEditDto r)
        {
            Categories = r.Categories;
            CategoryIds = r.CategoryIds;
            Title = r.Title;
            Author = r.Author;
            Priorities = r.Priorities;
            Priority = r.Priority;
            Justification = r.Justification;
        }
        [Required]
        public List<int> CategoryIds { get; set; } = null!;

        [Required]
        [StringLength(40), MinLength(2)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(40), MinLength(2)]
        public string Author { get; set; } = null!;

        [Required]
        public int Priority { get; set; }

        [Required]
        [StringLength(500), MinLength(5)]
        public string Justification { get; set; } = null!;

        public List<CategoryDto>? Categories { get; set; }

        public List<string>? Priorities { get; set; }
    }
}
