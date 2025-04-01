using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kanban.Commands;
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
        private ObservableCollection<KanbanWorkspace> _workspaces;
        private LoginViewModel _loginModel;
        private INavigationServices navigation; 
        public KanbanMainViewModel(IWorkspaceManagment managment, INavigationServices nav)
        {
            this.navigation = nav;
            this._managment = managment;
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

            _managment.CreateWorkspace(_loginModel.User, Workspace);

            Workspace = new();
        }


    }
}
