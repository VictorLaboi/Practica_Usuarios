using Kanban.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Commands
{
    internal class NavigationCommand :  INavigationServices
    {
        private ViewMediator _viewMediator;

        private readonly Func<Type, ViewModel> viewModelFactory;

        public NavigationCommand(ViewMediator viewMediator,Func<Type, ViewModel> viewModelFactory)
        {
            this._viewMediator = viewMediator;
            this.viewModelFactory = viewModelFactory;
        }

        public void Navigation<TViewModel>() where TViewModel : ViewModel
        {
            _viewMediator.CurrentViewModel = viewModelFactory.Invoke(typeof(TViewModel));
        }
    }
}
