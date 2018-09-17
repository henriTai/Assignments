using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_api.Models;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        public PlayersProcessor plProcessor;
        public PlayersController(PlayersProcessor pl)
        {
            plProcessor = pl;
        }

        [HttpGet("{id}")]
        public ActionResult<Task<Player>> Get(Guid id)
        {
            return plProcessor.Get(id);
        }

        [HttpGet]
        public ActionResult<Task<Player[]>> GetAll()
        {
            return plProcessor.GetAll();
        }

        [HttpPost("{player}")]
        public ActionResult<Task<Player>> Create (NewPlayer player)
        {
            return plProcessor.Create(player);
        }
        
        [HttpPut("{id}/{player}")]
        public ActionResult<Task<Player>> Modify(Guid id, ModifiedPlayer player)
        {
            return plProcessor.Modify(id, player);
        }

        [HttpPut("{id}/Banned/{status}")]
        public ActionResult<Task<Player>> SetBanned(Guid id, bool status)
        {
            return plProcessor.SetBanned(id, status);
        }

        [HttpPut("{id}/Level/{lvl}")]
        public ActionResult<Task<Player>> SetLevel(Guid id, int lvl)
        {
            return plProcessor.SetLevel(id, lvl);
        }

        [HttpDelete("{id}")]
        public ActionResult<Task<Player>> Delete(Guid id)
        {
            return plProcessor.Delete(id);
        }

    }
}