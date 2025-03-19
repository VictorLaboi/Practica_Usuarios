using Kanban.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Commands
{
    internal class NavigationCommand : ViewModelBase, INavigationServices
    {
        private ViewModel _currentView;

        private readonly Func<Type, ViewModel> viewModelFactory;

        public ViewModel CurrentView
        {
            get => _currentView;
            set
            {
                if (value != _currentView) {
                    _currentView?.Dispose();
                    _currentView = value;
                }
                OnOccurViewChange();

            }
        }

        public event Action OnViewChange;
        private void OnOccurViewChange() {
            OnViewChange?.Invoke();
        }

        public NavigationCommand(Func<Type, ViewModel> viewModelFactory)
        {
            this.viewModelFactory = viewModelFactory;
        }

        public void Navigation<TViewModel>() where TViewModel : ViewModel
        {
            ViewModel view = viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = view;
        }
    }
}
