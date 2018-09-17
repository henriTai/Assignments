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
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(Guid id)
        {
            return "no match";
        }
        /*

        // POST api/values
        [HttpPost("{value}")]
        public void Post([FromBody] string value)
        {
        }*/

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] int value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }

        private string playerToString(Player pl)
        {
            string s = "ID: " + pl.Id + ", " + pl.Name + " : " + pl.Score;
            return s;
        }
    }
}
