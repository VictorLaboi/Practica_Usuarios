using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.ViewModels
{
    public abstract class ViewModel : ViewModelBase, IDisposable
    {
        public virtual void Dispose()
        {
        }
    }
}
