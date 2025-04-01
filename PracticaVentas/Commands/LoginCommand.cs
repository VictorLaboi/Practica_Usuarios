using CommunityToolkit.Mvvm.ComponentModel;
using Kanban.Servicios;
using Kanban.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kanban.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _loginView;
        private INavigationServices _navigation;
        public LoginCommand(LoginViewModel loginView, INavigationServices navigation)
        {
            _loginView = loginView;
            _navigation = navigation;
        }

        public override void Execute(object parameter)
        {
            MessageBox.Show($"Login {_loginView.User.Name}");
            _navigation.Navigation<KanbanMainViewModel>();
        }

    }
}
