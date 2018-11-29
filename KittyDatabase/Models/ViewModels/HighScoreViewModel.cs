using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KittyDatabase.Models.ViewModels
{
    public class HighScoreViewModel
    {
        public List<HighScore> HighScores { get; set; }
        public int Score { get; set; }
        public int Player { get; set; }
    }
}
