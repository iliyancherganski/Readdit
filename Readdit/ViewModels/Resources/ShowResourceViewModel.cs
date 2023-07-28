using System.ComponentModel.DataAnnotations;

namespace Readdit.ViewModels.Resources
{
    public class ShowResourceViewModel
    {
        /*public ShowResourceViewModel(Resource r)
        {
            Id = r.Id;
            Type = r.Type.ToString();
            Categories = r.CategoryResources.Select(x=>x.Category.CategoryName);
            Title = r.Title;
            Author = r.Author;
            Status = r.Status.ToString();
            DateAdded = r.DateAdded;
        }*/

        [Required]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public IEnumerable<string> Categories { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Author { get; set; } = null!;

        [Required]
        public string Status { get; set; } = null!;

        [Required]
        public DateTime DateAdded { get; set; }
    }
}
