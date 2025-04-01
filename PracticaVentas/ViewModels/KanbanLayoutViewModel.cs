using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kanban.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.ViewModels
{
    internal partial class KanbanLayoutViewModel: ViewModel
    {
        private KanbanMainViewModel _viewModelKanban;
        private KanbanLayout _kanbanLayout;
        public KanbanLayoutViewModel(KanbanMainViewModel viewModelKanban)
        {   
            this._viewModelKanban = viewModelKanban;
            this._kanbanLayout = new();
        }
        public KanbanLayout KanbanLayout
        {
            get => _kanbanLayout;
            set
            {
                if (value != _kanbanLayout)
                {
                    _kanbanLayout = value;
                    OnPropertyChanged();
                }
            }
        }


    }
}
