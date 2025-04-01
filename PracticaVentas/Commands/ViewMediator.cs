using Kanban.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Commands
{

    //Este es el mediador de vistas principales, no de NAV menu
    public class ViewMediator : ViewModel
    {
        private ViewModel _currentViewModel;
        public event Action CurrentViewModelChanged;

        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;

            set
            {

                if (value != _currentViewModel)
                {
                    _currentViewModel?.Dispose();
                    _currentViewModel = value;
                    OnCurrentViewModelChanged();
                }

            }
        }
        public void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
