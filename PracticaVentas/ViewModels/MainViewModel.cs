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

        private bool IsLoggedOn => _auth.IsLoggedOn;


        private ViewMediator _viewMediator; 

        public ViewModel CurrentView => _viewMediator.CurrentViewModel;

        public MainViewModel(INavigationServices services, ViewMediator mediator)
        {
            _viewMediator = mediator;
            _services = services;
            _viewMediator.CurrentViewModelChanged+= OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentView));
        }
        private void AuthState_Changed() {
            OnPropertyChanged(nameof(IsLoggedOn));
        }


    }
}
