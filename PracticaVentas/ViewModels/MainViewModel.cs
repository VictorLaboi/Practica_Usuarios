using CommunityToolkit.Mvvm.Input;
using Kanban.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.ViewModels
{
    public partial class MainViewModel : ViewModel
    {

        private INavigationServices _services;

        public INavigationServices Services
        {
            get => _services;

            set
            {
                _services = value;
                OnPropertyChanged(nameof(Services));
            }
        }


        public MainViewModel(INavigationServices services)
        {
            Services = services;
        }

        [RelayCommand]
        public void NavigateHome()
        {
            Services.Navigation<KanbanMainViewModel>();
        }

    }
}
