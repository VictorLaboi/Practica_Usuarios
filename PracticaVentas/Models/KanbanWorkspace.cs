using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Models
{
    public class KanbanWorkspace
    {
        private string _name = string.Empty;

        public UserModel UserSession { get; set; }

        public List<KanbanLayout> Layouts { get; set; } = new(); //Esto lo usaré despues para agregar administracion.

        private Guid _workspaceId = Guid.NewGuid();


        //Obtenermos el id del workspace
        public Guid Id => _workspaceId;

        public string Name
        {
            get => _name; set
            {

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("El nombre del workspace no puede ser nulo o vacio");

                }
                else { _name = value; }
            }
        }
    }
}
