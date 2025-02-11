using PracticaVentas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaVentas.Commands
{
    internal class NavigationCommand :ViewModelBase, INavigationServices
    {
        private ViewModel _currentView;

        private readonly Func<Type, ViewModel> viewModelFactory;

        public ViewModel CurrentView
        { 
        get { 
                return _currentView; 
            }
            set { 
                if(value != _currentView) _currentView = value;
                OnPropertyChanged();
            }
        }

        public NavigationCommand(Func<Type, ViewModel> viewModelFactory)
        {
            this.viewModelFactory = viewModelFactory;
            /*Explicacion. 
            Lanzamos un Func con un parámetro type, el cual será el tipo de nuestra clase a la que queremos navegar.
            Despues nos devolvera un singleton de la clase que hemos registrado en el DI container (Clase HostBuilder)
            */
        }

        public void Navigation<TViewModel>() where TViewModel : ViewModel
        {
            /*Utilizacion: Si tu pasas el tipo Navigation<MainViewModel>() a este método,
             el viewModelFactory invocará el Func<Type,ViewModel>, lo cual nos devolverá un 
            tipo de viewModel.

            RECORDATORIO: Func<A,A> tiene un primer parámetro que es de entrada, el segundo es de salida.
             */

            ViewModel  view =  viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = view; 
        }
    }
}
