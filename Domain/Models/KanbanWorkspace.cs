using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban.Models
{
    public class KanbanWorkspace: DomainId
    {

        [Required]
        public Guid UserId { get; set; } // Clave foránea

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        // Relación con el usuario
        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }

        // Relación con layouts (Un workspace puede tener varios layouts)
        public virtual List<KanbanLayout> Layouts { get; set; } = new();
    }
}
