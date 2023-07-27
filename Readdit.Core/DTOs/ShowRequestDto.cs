using Readdit.Core.DTOs;
using Readdit.Data.Models.Requests;
using System.ComponentModel.DataAnnotations;

namespace Readdit.Models.Requests
{
    public class ShowRequestDto
    {
        public ShowRequestDto(ResourceRequest rr, IEnumerable<string> usersUpvoted)
        {
            Id = rr.Id;
            UserId = rr.UserId;
            Categories = rr.Categories.Select(x => x.CategoryName);
            Title = rr.Title;
            Author = rr.Author;
            Status = rr.Status.ToString();
            Priority = rr.Priority.ToString();
            Justification = rr.Justification;
            RejectionJustification = rr.RejectionJustification;
            DateAdded = rr.DateAdded;
            UsersUpvoted = usersUpvoted;
            Upvotes = UsersUpvoted.Count();
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
        public string Status { get; set; } = null!;

        [Required]
        public string Priority { get; set; } = null!;
        [Required]
        public string Justification { get; set; } = null!;

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public IEnumerable<string> UsersUpvoted { get; set; }

        [MaxLength(200)]
        public string? RejectionJustification { get; set; }

        [Required]
        public int Upvotes { get; set; }

        public bool? IsUpvoted { get; set; }
    }
}

//      Статус на желанието – Очаква потвърждение, Подготвя се, Доставя се,
//      Доставена, Отхвърлена
//      ▪ Категория
//      ▪ Автор
//      ▪ Заглавие
//      ▪ Приоритет
//      ▪ Дата на добавяне
//▪ Брой потребители, подкрепили желанието
//• Да има възможност за преглед на потребителите, подкрепили
//желанието
//• Ако ресурсът не е на потребителя да има бутон „Подкрепи“ (Upvote)
//▪ Бутон за промяна на записа
//▪ Бутон за изтриване на желанието