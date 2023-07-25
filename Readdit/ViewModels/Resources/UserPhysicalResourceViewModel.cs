using System.ComponentModel.DataAnnotations;

namespace Readdit.ViewModels.Resources
{
    public class UserPhysicalResourceViewModel
    {
        public UserPhysicalResourceViewModel(Resource r)
        {
            Id = r.Id;
            Categories = r.CategoryResources.Select(x => x.Category.CategoryName);
            Title = r.Title;
            Author = r.Author;
            DateAdded = r.DateAdded;
            ExpectedReturnDate = r.ExpectedReturnDate;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public IEnumerable<string> Categories { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Author { get; set; } = null!;

        [Required]
        public DateTime DateAdded { get; set; }

        public DateTime? ExpectedReturnDate { get; set; }
    }
}
