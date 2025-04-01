using Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban.Models
{
    public class KanbanHomeworks: DomainId
    {

        [Required]
        public Guid LayoutId { get; set; } // Clave foránea

        [Required, MaxLength(50)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }

        [Required, MaxLength(50)]
        public string AssignablePerson { get; set; } = string.Empty;

        // Relación con el layout
        [ForeignKey("LayoutId")]
        public virtual KanbanLayout Layout { get; set; }
    }
}
