using Kanban.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Servicios
{
    internal interface IManageKanbanLayout
    {
        public void CreateKanban(KanbanLayout kanban);

        public void GetKanbanLayout(Guid id);

        public void SetKanbanName(string name);

        public void SetKanbanDescription(string description);

        public void SetKanbanOwner(string owner);

        public void SetKanbanCreationDate(DateOnly creationDate);

        public void SetKanbanModificationDate();

        public void SetKanbanVisibility();


    }
}
