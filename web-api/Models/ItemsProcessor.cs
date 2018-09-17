using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_api.ErrorHandling;

namespace web_api.Models
{
    public class ItemsProcessor
    {
        IRepository memRep;

        public ItemsProcessor(IRepository rep)
        {
            memRep = rep;
        }

        public Task<List<Item>> GetItems(Guid id)
        {
            return memRep.GetItems(id);
        }

        public Task<Item> GetItem(Guid id, Guid itemId)
        {
            return memRep.GetItem(id, itemId);
        }
        [ServiceFilter (typeof(LLExceptionFilterAttribute))]//ei toimi
        public async Task<Item> CreateItem (Guid id, NewItem newItem)
        {

            Player pl = await memRep.Get(id);
            if (newItem._type == ItemType.Sword && pl.level < 3)
            {
                throw new LowLevelException(String.Format("{0}'s level is too low.", pl.Name));            
            }
            
            return await memRep.CreateItem(id, newItem);
        }

        public Task<Item> ModifyItem (Guid id, ModifiedItem modIt, Guid itemId)
        {
            return memRep.ModifyItem(id, modIt, itemId);
        }

        public Task<Item> DeleteItem (Guid id, Guid itemId)
        {
            return memRep.DeleteItem(id, itemId);
        }

        public Task<Player> DeleteAllItems(Guid id)
        {
            return memRep.DeleteAllItems(id);
        }

    }
}