using CommunityToolkit.Mvvm.Collections;
using Kanban.Models;
using Kanban.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Commands
{
    public class WorkspaceManagment : IWorkspaceManagment
    {
        private readonly ListWorkspaceHandler _listWorkspaceHandler;
            private readonly object _lock = new();

            public WorkspaceManagment(ListWorkspaceHandler listWorkspaceHandler)
            {
                this._listWorkspaceHandler = listWorkspaceHandler;
            }
        public KanbanWorkspace CreateWorkspace(UserModel user, KanbanWorkspace workspace)
            {
                workspace.UserSession = user;

                lock (_lock)
                {
                    _listWorkspaceHandler.AddWorkspace(workspace);
            }

                return workspace;
            }

            public void AddLayout(Guid id, KanbanLayout kanban)
            {
                lock (_lock)
                {
                    var work = _listWorkspaceHandler.GetWorkspaces().FirstOrDefault(w => w.Id == id);
                    if (work != null)
                    {
                        work.Layouts.Add(kanban);
                    }

                }   
            }
        
            public ObservableCollection<KanbanWorkspace> GetWorkspaces()
            {
                 return _listWorkspaceHandler.GetWorkspaces(); 
            }

    }

}
