﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HighScores.WinAPI.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
    }
}