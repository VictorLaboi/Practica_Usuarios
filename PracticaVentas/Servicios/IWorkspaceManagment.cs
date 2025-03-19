using Kanban.Commands;
using Kanban.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Servicios
{
    public interface IWorkspaceManagment
    {
        abstract KanbanWorkspace CreateWorkspace(UserModel user, KanbanWorkspace workspace);    
        public void AddLayout(Guid id, KanbanLayout kanban);

        public ObservableCollection<KanbanWorkspace> GetWorkspaces();
    }
}
