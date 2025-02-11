using PracticaVentas.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PracticaVentas.ViewModels
{
    public class MainViewModel : ViewModel
    {

        private INavigationServices _services;

        public INavigationServices Services { get => _services;

            set
            {
                _services = value;
                OnPropertyChanged(nameof(Services));
            }
        }

        public RelayCommand NavigateHomeCommand { get; set; }
        public RelayCommand NavigateManagmentCommand { get; set; }
        public MainViewModel(INavigationServices services)
        {
            Services = services;

            NavigateHomeCommand = new RelayCommand(o => { 
                Services.Navigation<PersonViewModel>(); 
            },o => true);

            NavigateManagmentCommand = new RelayCommand(o => { 
                Services.Navigation<ManagmentViewModel>(); }
            , o => true);
        }

    }
}
