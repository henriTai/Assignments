using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace web_api.Models
{
    public interface IRepository
    {
        Task<Player> Get(Guid id);
        Task<Player[]> GetAll();
        Task<Player> Create (Player player);
        Task<Player> Modify(Guid id, ModifiedPlayer player);
        Task<Player> Delete(Guid id);

        Task<Player> SetBanned(Guid id, bool status);

        Task<Player> SetLevel(Guid id, int lvl);

        Task<List<Item>> GetItems(Guid id);

        Task<Item> GetItem(Guid id, Guid itemId);

        Task<Item> CreateItem(Guid id, NewItem newItem);

        Task<Item> ModifyItem(Guid id, ModifiedItem modItem, Guid itemId);

        Task<Item> DeleteItem(Guid id, Guid itemId);
        Task<Player> DeleteAllItems(Guid id);
    }
}