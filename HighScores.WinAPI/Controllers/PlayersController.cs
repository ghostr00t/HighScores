using HighScores.WebAPI.Models;
using HighScores.WinAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HighScores.WinAPI.Controllers
{
    [EnableCorsAttribute("http://localhost:58450", "*", "*")]
    public class PlayersController : ApiController
    {
        // GET: api/Players
        public IEnumerable<Player> Get()
        {
            var playerRepository = new PlayerRepository();
            return playerRepository.Retrieve();
        }

        public IEnumerable<Player> Get(string search)
        {
            var playerRepository = new PlayerRepository();
            var players = playerRepository.Retrieve();
            return players.Where(p => p.Username.Contains(search));
        }

        // GET: api/Players/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Players
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Players/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Players/5
        public void Delete(int id)
        {
        }
    }
}
