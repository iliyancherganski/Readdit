using Readdit.Core.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Readdit.Models.Requests
{
    public class UserRequestViewModel
    {
        // TODO: Map User Request (in constructor)
        //public UserRequestViewModel(RequestEditDto rr)
        //{
        //    Id = rr.Id;
        //    Type = rr.Type.ToString();
        //    Categories = rr.CategoryRequests.Select(x => x.Category.CategoryName);
        //    Title = rr.Title;
        //    Author = rr.Author;
        //    Description = rr.Description;
        //    Status = rr.Status.ToString();
        //    Priority = rr.Priority.ToString();
        //    DateAdded = rr.DateAdded;
        //    Justification = rr.Justification;
        //    RejectionJustification = rr.RejectionJustification;
        //}
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
        public string Description { get; set; } = null!;

        [Required]
        public string Status { get; set; } = null!;

        [Required]
        public string Priority { get; set; } = null!;

        [Required]
        public DateTime DateAdded { get; set; }

        public string? Justification { get; set; } = null!;

        public string? RejectionJustification { get; set; }
    }
}
