using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace web_api.Models
{
    public class PlayersProcessor
    {
        IRepository memRep;

        public PlayersProcessor(IRepository mem)
        {
            memRep = mem;
        }

        public async Task<Player> Get(Guid id)
        {
            return await memRep.Get(id);
        }
        public async Task<Player[]> GetAll()
        {
            return await memRep.GetAll();
        }
        
        public Task<Player> Create(NewPlayer player)
        {
            Guid id = Guid.NewGuid();
            Player pl = new Player();
            pl.Id=id;
            pl.Name=player.Name;
            pl.IsBanned=false;
            pl.Score = 0;
            pl.level = 1;
            pl.CreationTime = DateTime.UtcNow;
            pl.items = new List<Item>();
            return memRep.Create(pl);//wait & async voi ottaa pois ja palauttaa mem rep
        }
        public Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            return memRep.Modify(id, player);
        }

        public Task<Player> Delete(Guid id)
        {
            return memRep.Delete(id);
        }

        public Task<Player> SetBanned(Guid id, bool status)
        {
            return memRep.SetBanned(id, status);
        }

        public Task<Player> SetLevel(Guid id, int lvl)
        {
            return memRep.SetLevel(id, lvl);
        }
    }
}