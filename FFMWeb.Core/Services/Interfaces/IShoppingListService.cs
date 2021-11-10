using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Services.Interfaces
{
    public interface IShoppingListService
    {
        List<string> GetAllItems();
        string AddItem(string item);
        string RemoveItem(string item);
        List<string> ClearAll();
    }
}
