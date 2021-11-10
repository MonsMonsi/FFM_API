using FFMWeb.Core.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Services
{
    public class ShoppingListService : IShoppingListService
    {
        private List<string> _items = new();
        public string AddItem(string item)
        {
            _items.Add(item);

            return item;
        }

        public List<string> ClearAll()
        {
            _items = new();

            return _items;
        }

        public List<string> GetAllItems()
        {
            return _items;
        }

        public string RemoveItem(string item)
        {
            if (!_items.Contains(item))
            {
                throw new ArgumentException("Item could not be found");
            }

            _items.Remove(item);

            return item;
        }
    }
}
