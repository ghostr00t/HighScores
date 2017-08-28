using HighScores.WinAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;

namespace HighScores.WebAPI.Models
{
    public class PlayerRepository
    {
        internal Player Create()
        {
            Player player = new Player
            {
               // ReleaseDate = DateTime.Now
            };
            return player;
        }

        internal List<Player> Retrieve()
        {
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/player.json");

            var json = System.IO.File.ReadAllText(filePath);

            var players = JsonConvert.DeserializeObject<List<Player>>(json);

            return players;
        }

        internal Player Save(Player player)
        {
            // Read in the existing Players
            var players = this.Retrieve();

            // Assign a new Id
            var maxId = players.Max(p => p.Id);
            player.Id = maxId + 1;
            players.Add(player);

            WriteData(players);
            return player;
        }

        internal Player Save(int id, Player player)
        {
            // Read in the existing Players
            var players = this.Retrieve();

            // Locate and replace the item
            var itemIndex = players.FindIndex(p => p.Id == player.Id);
            if (itemIndex > 0)
            {
                players[itemIndex] = player;
            }
            else
            {
                return null;
            }

            WriteData(players);
            return player;
        }

        private bool WriteData(List<Player> players)
        {
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/Player.json");

            var json = JsonConvert.SerializeObject(players, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);

            return true;
        }

    }
}