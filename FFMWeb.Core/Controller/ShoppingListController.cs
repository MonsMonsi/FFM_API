using FFMWeb.Core.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Controller
{
    [Route("api/shoppingList")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _service;

        public ShoppingListController(IShoppingListService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets all items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<string> GetAllItems()
        {
            return _service.GetAllItems();
        }

        /// <summary>
        /// Adds an item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public string AddItem([FromBody] string item)
        {
            return _service.AddItem(item);
        }

        /// <summary>
        /// Deletes an entry
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpDelete("{item}")]
        public string RemoveItem([FromRoute] string item)
        {
            return _service.RemoveItem(item);
        }

        /// <summary>
        /// Deletes All entries
        /// </summary>
        /// <returns></returns>
        [HttpDelete("all")]
        public List<string> ClearAll()
        {
            return _service.ClearAll();
        }
    }
}
