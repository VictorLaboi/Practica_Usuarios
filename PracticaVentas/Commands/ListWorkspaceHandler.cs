using Kanban.Models;
using Kanban.Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Commands
{
    public class ListWorkspaceHandler
    {
        private readonly ObservableCollection<KanbanWorkspace> _workspaces = new();

        public ObservableCollection<KanbanWorkspace> GetWorkspaces() => _workspaces;

        public void AddWorkspace(KanbanWorkspace workspace) => _workspaces.Add(workspace);
    }
}
