using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace web_api.Models
{
    public class InMemoryRepository : IRepository
    {
        private readonly Dictionary<Guid, Player> players;

        public InMemoryRepository()
        {
            players = new Dictionary<Guid, Player>();
        }
        
        public Task<Player> Get(Guid id)
        {
            if (players.ContainsKey(id))
            {
                return Task.FromResult(players[id]);
            }
            else return Task.FromResult<Player>(null);
        }

        public Task<Player[]> GetAll()
        {
            
            int size = players.Count;
            Player[] pl = new Player[size];
            players.Values.CopyTo(pl, 0);
            return Task.FromResult(pl);
        }

        public Task<Player> Create(Player player)
        {
            players.Add(player.Id, player);
            return Task.FromResult(player);
        }

        public Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            if (players.ContainsKey(id))
            {
                Player pl = players[id];
                pl.Score = player.Score;
                players[id] = pl;

                return Task.FromResult(pl);
            }
            else return Task.FromResult<Player>(null);
        }

        public Task<Player> SetBanned(Guid id, bool status)
        {
            if (players.ContainsKey(id))
            {
                players[id].IsBanned = status;
                return Task.FromResult(players[id]);
            }
            else return Task.FromResult<Player>(null);
        }

        public Task<Player> SetLevel(Guid id, int lvl)
        {
             if (players.ContainsKey(id))
            {
                players[id].level = lvl;
                return Task.FromResult(players[id]);
            }
            else return Task.FromResult<Player>(null);
        }

        public Task<Player> Delete(Guid id)
        {
            if (players.ContainsKey(id))
            {
                Player pl = players[id];
                players.Remove(id);
                return Task.FromResult(pl);
            }
            else return Task.FromResult<Player>(null);
        }

        public Task<List<Item>> GetItems(Guid id)
        {
            if (players.ContainsKey(id))
            {
                return Task.FromResult(players[id].items);
            }
            else return Task.FromResult<List<Item>>(null);
        }

        public Task<Item> CreateItem(Guid id, NewItem newItem)
        {
            if (players.ContainsKey(id))
            {
                Item item = new Item(newItem._level, newItem._type, newItem._creationDate, newItem._itemId);
                players[id].items.Add(item);
                return Task.FromResult(item);
            }
            else return Task.FromResult<Item>(null);
        }

        public Task<Item> ModifyItem(Guid id, ModifiedItem modItem, Guid itemId)
        {
            if (players.ContainsKey(id))
            {
                for (int i=0; i < players[id].items.Count; i++)
                {
                    if (players[id].items[i]._itemId == itemId)
                    {
                        players[id].items[i]._level=modItem._level;
                        return Task.FromResult(players[id].items[i]);
                    }
                }
                return null;
            }
            else return Task.FromResult<Item>(null);
        }

        public Task<Item> DeleteItem(Guid id, Guid itemId)
        {
            if (players.ContainsKey(id))
            {
                for (int i=0; i < players[id].items.Count; i++)
                {
                    if (players[id].items[i]._itemId == itemId)
                    {
                        Item item = players[id].items[i];
                        players[id].items.RemoveAt(i);
                        return Task.FromResult(item);
                    }
                }
                return Task.FromResult<Item>(null);
            }
            else return Task.FromResult<Item>(null);
        }

        public Task<Player> DeleteAllItems(Guid id)
        {
            if (players.ContainsKey(id))
            {
                players[id].items.Clear();
                return Task.FromResult(players[id]);
            }
            else return Task.FromResult<Player>(null);
        }

        public Task<Item> GetItem(Guid id, Guid itemId)
        {
            if (players.ContainsKey(id))
            {
                for (int i=0; i < players[id].items.Count; i++)
                {
                    if (players[id].items[i]._itemId == itemId)
                    {
                        return Task.FromResult(players[id].items[i]);
                    }
                }
                return Task.FromResult<Item>(null);
            }
            else return Task.FromResult<Item>(null);
        }
    }
}