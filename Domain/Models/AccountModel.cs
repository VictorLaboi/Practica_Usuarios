using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Kanban.Models;

namespace Domain.Models
{
    public class AccountModel: DomainId
    {

        [Required]
        public Guid UserId { get; set; } // Clave foránea

        [Required]
        public Guid WorkspaceId { get; set; } // Clave foránea

        // Relaciones con otras entidades
        [ForeignKey("UserId")]
        public virtual UserModel CurrentUser { get; set; }

        [ForeignKey("WorkspaceId")]
        public virtual KanbanWorkspace Workspace { get; set; }
    }
}
