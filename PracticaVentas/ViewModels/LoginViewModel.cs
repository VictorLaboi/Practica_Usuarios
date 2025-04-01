using Kanban.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Windows;
using Kanban.Commands;
using Kanban.Servicios;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace Kanban.ViewModels
{
    public partial class LoginViewModel : ViewModel
    {
        private UserModel _user;
        private INavigationServices navigationService;
        public ICommand LoginCommands { get; set; }
        public LoginViewModel(
            INavigationServices nav)
        {
            LoginCommands = new LoginCommand(this, nav);
            _user = new(); 
            this.navigationService = nav;

        }

        public UserModel User
        {
            get => _user; set
            {
                if (value != _user)
                {
                    _user = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
