using Kanban.Models;
using Kanban.Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.TEMPORAL
{
    public class PersonListHandler : IHandleList<UserModel>
    {
        private readonly ObservableCollection<UserModel> _items;

        public PersonListHandler(ObservableCollection<UserModel> userModels)
        {
            _items = userModels ?? new ObservableCollection<UserModel>();
        }

        public void AddItem(UserModel item)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem == null)
            {
                _items.Add(item);
            }
        }

        public IEnumerator<UserModel> GetEnumerator() => _items.GetEnumerator();

        public ObservableCollection<UserModel> GetItems() => _items;

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
    }
}
