using Readdit.Models.Requests;
using System.ComponentModel.DataAnnotations;

namespace Readdit.ViewModels.Requests
{
    public class DeclineRequestViewModel
    {
        public DeclineRequestViewModel()
        {

        }
        public DeclineRequestViewModel(ShowRequestDto r)
        {
            Id = r.Id;
            UserId = r.UserId;
            Categories = r.Categories;
            Title = r.Title;
            Author = r.Author;
            Status = r.Status.ToString();
            Justification = r.Justification;
            RejectionJustification = r.RejectionJustification;
            Priority = r.Priority.ToString();
            DateAdded = r.DateAdded;
            UsersUpvoted = r.UsersUpvoted.ToList();
            Upvotes = r.Upvotes;
            IsUpvoted = r.IsUpvoted;
        }

        public int Id { get; set; }
        
        public string? UserId { get; set; }

        public IEnumerable<string>? Categories { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? Justification { get; set; }

        public string? Status { get; set; }

        public string? Priority { get; set; }

        public DateTime DateAdded { get; set; }

        public IEnumerable<string>? UsersUpvoted { get; set; }

        public bool? IsUpvoted { get; set; }

        public int? Upvotes { get; set; }

        [Required]
        [MaxLength(200)]
        public string RejectionJustification { get; set; } = null!;

    }
}

