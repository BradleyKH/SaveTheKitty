using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KittyDatabase.Models
{
    public class HighScore
    {
        public int Id { get; set; }
        public string Player { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}
