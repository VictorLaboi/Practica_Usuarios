using PracticaVentas.Commands;
using PracticaVentas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PracticaVentas.ViewModels
{
    public class ManagmentViewModel : PersonViewModel
    {
        protected ObservableCollection<Area> _areas;

        public ManagmentViewModel(CrudOperationsData crud) : base(crud)
        {
            _person = new PersonModel();
            InitializeArea();

        }

        private Guid guid;
        public Guid _Guid
        {
            get => guid;
            private set
            {
                guid = value;
                OnPropertyChanged(nameof(_Guid));
            }
        }

        private string guidInput;
        public string GuidInput
        {
            get => guidInput;
            set
            {
                guidInput = value;
                OnPropertyChanged(nameof(GuidInput));

                // Valida y convierte el texto a un GUID
                if (Guid.TryParse(guidInput, out var parsedGuid))
                {
                    _Guid = parsedGuid; // Actualiza el valor del GUID real
                }
                else
                {
                    // Maneja valores no válidos, si es necesario
                    _Guid = Guid.Empty;
                }
            }
        }

        private string completeName; 
        public string CompleteName
        {
            get => completeName;
            set
            {
                if (completeName != value)
                {
                    completeName = value;
                    OnPropertyChanged(nameof(CompleteName));
                }
            }
        }
        public ObservableCollection<Area> Areas
        {
            get => _areas;
            set
            {
                if (_areas != value)
                {
                    _areas = value;
                    OnPropertyChanged(nameof(Areas));
                }
            }
        }

        public async Task<ObservableCollection<Area>> InitializeArea()
        {
            Areas = await _crud.GetAreasAsync();
            return Areas;
        }
        public ICommand GetPerson => new RelayCommand(GetPersonCommand,CanGetPerson);


        private void GetPersonCommand(object e) {
            string message = string.Empty;
            Person = _crud.GetPerson(_Guid,out message);
            CompleteName = Person == null ? string.Empty : string.Join(" ", Person.Name, Person.LastName);
            OutputMessage = message;
        }

        //Solucion TEMPORAL: 

        private bool CanGetPerson(object e) {
            if (!Guid.TryParse(GuidInput, out Guid result)) {
                return false;
            }
            return true;
        }

    }
}
