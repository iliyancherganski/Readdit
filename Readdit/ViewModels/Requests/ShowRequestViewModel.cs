using Readdit.Data.Models.Requests;
using Readdit.Models.Requests;
using System.ComponentModel.DataAnnotations;

namespace Readdit.ViewModels.Requests
{
    public class ShowRequestViewModel
    {
        public ShowRequestViewModel()
        {
        }
        public ShowRequestViewModel(ShowRequestDto r)
        {
            Id = r.Id;
            UserId = r.UserId;
            Categories = r.Categories;
            Title = r.Title;
            Author = r.Author;
            Status = r.Status.ToString();
            Justification = r.Justification;
            Priority = r.Priority.ToString();
            DateAdded = r.DateAdded;
            UsersUpvoted = r.UsersUpvoted.ToList();
            Upvotes = r.Upvotes;
            IsUpvoted = r.IsUpvoted;
        }

        public int Id { get; set; }
        public string UserId { get; set; }

        [Required]
        public IEnumerable<string> Categories { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Author { get; set; } = null!;

        [Required]
        public string Justification { get; set; } = null!;

        [Required]
        public string Status { get; set; } = null!;

        [Required]
        public string Priority { get; set; } = null!;

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public IEnumerable<string> UsersUpvoted { get; set; }

        public bool? IsUpvoted { get; set; }

        [Required]
        public int Upvotes { get; set; }
    }
}