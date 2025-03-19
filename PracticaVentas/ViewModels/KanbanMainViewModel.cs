using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kanban.Models;
using Kanban.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kanban.ViewModels
{
    public partial class KanbanMainViewModel : ViewModel
    {
        private IWorkspaceManagment _managment;

        private KanbanWorkspace _workspace;
        private UserModel _user;
        private ObservableCollection<KanbanWorkspace> _workspaces;
        private IHandleList<UserModel> _userHandler;
        public KanbanMainViewModel(IWorkspaceManagment managment, IHandleList<UserModel> userHandler)
        {
            this._managment = managment;
            this._userHandler = userHandler;
        }

        //Generamos get y set para Workspace.
        public KanbanWorkspace Workspace
        {
            get => _workspace;
            set
            {
                if (value != _workspace)
                {
                    _workspace = value;
                    OnPropertyChanged();
                }
            }
        }
        public UserModel User
        {
            get => _user;
            set
            {
                if (value != _user)
                {
                    _user = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<KanbanWorkspace> Workspaces
        {
            get => _workspaces;
            set
            {
                if (value != _workspaces)
                {
                    _workspaces = value;
                    OnPropertyChanged();
                }
            }
        }

        [RelayCommand]

        public void CreateWorkspace()
        {
            if (Workspace == null)
                Workspace = new KanbanWorkspace();

            _managment.CreateWorkspace(User, Workspace);

            Workspace = new();
        }


    }
}
