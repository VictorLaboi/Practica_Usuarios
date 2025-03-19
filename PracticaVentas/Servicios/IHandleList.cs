using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Servicios
{
    public interface IHandleList<T> : IEnumerable<T>  
    {
        ObservableCollection<T> GetItems();
        void AddItem(T item);
    }
}
