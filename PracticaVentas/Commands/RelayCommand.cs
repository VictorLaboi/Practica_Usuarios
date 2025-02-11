using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticaVentas.Commands
{
    public class RelayCommand : ICommand
    {

        /*Explicacion de ICommand:
        ICommand solo decide si algo se puede ejecutar o no, mediante un Action (Recordando que solo es void).
        y una condicion.

        Estos 2 argumentos vendrán por parte del usuario, cuando se utilice la interfaz ICommand dentro del viewModel.

        Ej: new RelayCommand(ejecuta,noEjecuta);

        void ejecuta (){
            string source = "";
            _image.add(source);
        }

        bool noEjecuta(){
            return false; 
        }

        RelayCommand nunca va a ejecutar porque es igual a 

        */

        private readonly Action<object> _execute;
        private readonly Predicate<object> _CanExecute;

        public event EventHandler? CanExecuteChanged {

            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;

        }

        public RelayCommand(Action<object> execute, Predicate<object> CanExecute)
        {
            this._execute = execute;
            this._CanExecute = CanExecute;  
        }
        public RelayCommand(Action<object> execute) : this(execute, null)
        {
            /*Explicacion de this(): Estamos llamando al ctor anterior, pero le estamos pasando 
            Parámetros, en este caso "execute (del nuevo ctor)" y null, asignado manualmente*/ 
        }
        public bool CanExecute(object? parameter)
        {
            return _CanExecute == null ? true : _CanExecute(parameter);    
            //Si no pasamos un estado a al predicate _CanExecute, este siempre será true.
            //De otro modo, si es != null, se ejecutara el predicado con la condicion que hemos dado.

        }

        public void Execute(object? parameter)
        {
           _execute(parameter!);
        }
    }
}
