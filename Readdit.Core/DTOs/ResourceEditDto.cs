using Readdit.Data.Models.Enums;
using Readdit.Data.Models.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readdit.Core.DTOs
{
    public class ResourceEditDto
    {
        // TODO: Finish mapping
        public ResourceEditDto(Resource res, List<CategoryDto> categories)
        {
            Id = res.Id;
            Types = Enum.GetNames(typeof(ResourceType)).ToList();
            Title = res.Title;
            Author = res.Author;
            Description = res.Description;
            //StatusId = 
            AllStatus = Enum.GetNames(typeof(ResourceStatus)).ToList();
            DateAdded = res.DateAdded;
            ExpectedReturnDate = res.ExpectedReturnDate;
            OfficialPageUrl = res.OfficialPageUrl;
            FilePathOrUrl = res.FilePathOrUrl;
            Categories = categories.Select(x=>x.Name).ToList();
            CategoryIds = res.CategoryResources.Where(c => c.ResourceId == res.Id).Select(c => c.CategoryId).ToList();
        }

        public int Id { get; set; }

        [Required]
        public int TypeId { get; set; }
        public IEnumerable<string> Types { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Author { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public int StatusId { get; set; }
        public IEnumerable<string> AllStatus { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        public DateTime? ExpectedReturnDate { get; set; }

        [Required]
        public string OfficialPageUrl { get; set; } = null!;

        public string? FilePathOrUrl { get; set; }

        [Required]
        public List<int> CategoryIds { get; set; } = null!;
        public List<string> Categories { get; set; }

        public virtual ICollection<CategoryResource> CategoryResources { get; set; }
    }
}
