using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_api.Models;

namespace web_api.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        public ItemsProcessor itProcessor;

        public ItemsController(ItemsProcessor pr)
        {
            itProcessor = pr;
        }

        [HttpGet("{id}/items")]
        public ActionResult<Task<List<Item>>> GetItems(Guid id)
        {
            return itProcessor.GetItems(id);
        }

        [HttpGet("{id}/items/{itemId}")]
        public ActionResult<Task<Item>> GetItem(Guid id, Guid itemId)
        {
            return itProcessor.GetItem(id, itemId);
        }

        [HttpPost("{id}/items/{type}/{level}")]
        public ActionResult<Task<Item>> CreateItem (Guid id, int type, int level)
        {
            NewItem newItem = new NewItem();

            int enumLength = Enum.GetNames(typeof(ItemType)).Length;
            if (type < enumLength) newItem._type = (ItemType)type;
            else return null;
            newItem._level=level;
            newItem._creationDate = DateTime.UtcNow;
            newItem._itemId = Guid.NewGuid();
            TryValidateModel(newItem);
            if (ModelState.IsValid){
                return itProcessor.CreateItem(id, newItem);
            }
            else return Task.FromResult<Item>(null);
        }

        [HttpPut("{id}/items/{itemId}/{level}")]
        public ActionResult<Task<Item>> ModifyItem(Guid id, Guid itemId, int level)
        {
            ModifiedItem modIt = new ModifiedItem();
            modIt._level = level;
            modIt._itemId = itemId;
            TryValidateModel(modIt);
            if (ModelState.IsValid){
                return itProcessor.ModifyItem(id, modIt, itemId);
            }
            else return null;
        }

        [HttpDelete("{id}/items/{itemId}")]
        public ActionResult<Task<Item>> Delete(Guid id, Guid itemId)
        {
            return itProcessor.DeleteItem(id, itemId);
        }

        [HttpDelete("{id}/items/")]
        public ActionResult<Task<Player>> DeleteAll(Guid id)
        {
            return itProcessor.DeleteAllItems(id);
        }
    }


}