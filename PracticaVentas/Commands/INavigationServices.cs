using CommunityToolkit.Mvvm.ComponentModel;
using Kanban.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Commands
{
    public interface INavigationServices
    {
        ViewModel CurrentView { get; }

        void Navigation<T>() where T : ViewModel;
    }
}
