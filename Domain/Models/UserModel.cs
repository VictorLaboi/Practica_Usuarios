using Kanban.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class UserModel : DomainId
    {

        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string HashedPassword { get; set; } = string.Empty;

        // Relación con Workspaces (Un usuario puede tener muchos workspaces)
        public virtual List<KanbanWorkspace> Workspaces { get; set; } = new();
    }
}
