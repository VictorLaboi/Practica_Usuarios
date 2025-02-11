using Microsoft.Win32;
using PracticaVentas.Commands;
using PracticaVentas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;
using PracticaVentas.Servicios;
using System.Threading.Tasks.Dataflow;
using System.Windows;
using System.Configuration;

namespace PracticaVentas.ViewModels
{
    public class PersonViewModel : ViewModel
    {
        protected readonly CrudOperationsData _crud;
        protected ObservableCollection<PersonModel> _personModels;


        protected PersonModel _person;

        public PersonViewModel(CrudOperationsData crud)
        {
            _crud = crud;
            _person = new PersonModel();
            InitializeAsync();
        }



        public PersonModel Person {
            get => _person;
            set {
                if (_person != value) {
                    _person = value;
                    OnPropertyChanged(nameof(Person));
                    OnPropertyChanged(nameof(FotoEmpleado));
                    OnPropertyChanged(nameof(OutputSource));
                }
            }
        }

        public BitmapImage? FotoEmpleado
        {
            get { return Person.FotoEmpleado; }
            set
            {
                if (Person.FotoEmpleado != value)
                {
                    Person.FotoEmpleado = value;
                    OnPropertyChanged(nameof(FotoEmpleado));
                    OnPropertyChanged(nameof(OutputSource));
                }
            }
        }

        private string _outputMessage;

        public string OutputMessage
        {
            get => _outputMessage;
            set
            {
                if (value != _outputMessage)
                {
                    _outputMessage = value;
                    OnPropertyChanged(nameof(OutputMessage));
                }
            }
        }



        private string _outputSource;
        public string OutputSource {
            get => Person.FotoEmpleado?.UriSource.LocalPath ?? string.Empty;
        }

        public ObservableCollection<PersonModel> PersonsModels {
            get => _personModels;
            set {
                if (_personModels != value) {
                    _personModels = value;
                    OnPropertyChanged(nameof(PersonsModels));
                }
            }
        }        

        public ICommand AddCommand
        {
            get {
                return new RelayCommand(AddExecute, AddCanExecute);
            }
        }

        public ICommand Clear => new RelayCommand(ClearField);

        public ICommand ImageAddCommand
        {
            get => new RelayCommand(PhotoHandler);
        }


        public ICommand Reload {
            get => new RelayCommand(ReloadExecute);
        }

        public async Task<ObservableCollection<PersonModel>> InitializeAsync()
        {
            PersonsModels =  await _crud.GetAsync();
            return PersonsModels;
        }        

        private void PhotoHandler(object e) {
            FotoEmpleado = _crud.AgregarImagen();
        }

        protected virtual async void AddExecute(object user)
        {
            MessageBoxResult result = MessageBox.Show("Agregar empleado?","Confirmar",MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result is MessageBoxResult.Yes) {
                _crud.Add(Person);
                Person = new();
                PersonsModels = await InitializeAsync();
            }
        }

        private bool AddCanExecute(object user)
        {
            return Checkers.CheckField(Person);
        }


        protected async void ReloadExecute(object user) {
            PersonsModels = await InitializeAsync();
        }


        public async void LimpiarMensaje(int time)
        {
            await Task.Delay(time);
            OutputMessage = string.Empty;
        }


        public void ClearField(object e) {
            var result = MessageBox.Show("Seguro que quieres limpiar pantalla?", "Seguro?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Person = new();
            }
        }
    
        }


}


