using Readdit.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readdit.Core.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        public List<string> CategoryNames { get; set; } = new List<string>();
    }
}
