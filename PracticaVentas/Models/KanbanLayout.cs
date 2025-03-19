using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Models
{
    public class KanbanLayout
    {

        public Guid Id { get; private set; } = Guid.NewGuid(); // Se asigna al crear la instancia


        [MaxLength(50, ErrorMessage = "El título es demasiado largo.")]
        public string Title { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "La descripción es demasiado larga.")]
        public string? Description { get; set; }

        // El usuario podrá agregar tareas, pero se limita a 10
        [MaxLength(10, ErrorMessage = "No es posible agregar más de 10 tareas!")]
        public List<KanbanHomeworks> Homeworks { get; set; } = new();
    }
}
