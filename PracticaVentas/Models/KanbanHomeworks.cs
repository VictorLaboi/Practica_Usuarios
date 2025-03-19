using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Models
{
    public class KanbanHomeworks
    {
        [Required]
        [StringLength(50, ErrorMessage = "Title is too long.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Mensaje demasiado largo")]
        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }

        [Required]
        public string AssignablePerson { get; set; } = string.Empty;
    }
}
