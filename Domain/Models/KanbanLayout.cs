using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban.Models
{
    public class KanbanLayout : DomainId
    {

        [Required]
        public Guid WorkspaceId { get; set; } // Clave foránea

        [Required, MaxLength(50)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Description { get; set; }

        // Relación con workspace
        [ForeignKey("WorkspaceId")]
        public virtual KanbanWorkspace Workspace { get; set; }

        // Relación con tareas (Un layout puede tener varias tareas)
        public virtual List<KanbanHomeworks> Homeworks { get; set; } = new();
    }
}
