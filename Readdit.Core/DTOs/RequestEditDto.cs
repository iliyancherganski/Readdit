using Readdit.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readdit.Core.DTOs
{
    public class RequestEditDto
    {
        public RequestEditDto()
        {

        }
        public RequestEditDto(List<CategoryDto> categories)
        {
            Priorities = Enum.GetNames(typeof(RequestPriority)).ToList();
            Categories = categories;
        }
        [Required]
        public List<int> CategoryIds { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Author { get; set; } = null!;

        [Required]
        public int Priority { get; set; }

        [Required]
        public string Justification { get; set; } = null!;

        public List<CategoryDto> Categories { get; set; } = null!;
        public List<string> Priorities { get; set; } = null!;
    }
}
