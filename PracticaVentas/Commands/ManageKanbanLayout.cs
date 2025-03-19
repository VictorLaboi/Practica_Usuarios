using Kanban.Models;
using Kanban.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Commands
{
    internal class ManageKanbanLayout : IManageKanbanLayout
    {
        private readonly ObservableCollection<KanbanLayout> _kanbanLayouts;
        public ManageKanbanLayout(ObservableCollection<KanbanLayout>kanbanLayout)
        {
            this._kanbanLayouts = kanbanLayout; 
        }

        public void CreateKanban(KanbanLayout kanban)
        {
            
        }

        public void GetKanbanLayout(Guid id)
        {
            
        }

        public void SetKanbanCreationDate(DateOnly creationDate)
        {
            ;
        }

        public void SetKanbanDescription(string description)
        {
            
        }

        public void SetKanbanModificationDate()
        {
           
        }

        public void SetKanbanName(string name)
        {
            
        }

        public void SetKanbanOwner(string owner)
        {
            
        }

        public void SetKanbanVisibility()
        {
            
        }
    }
}
