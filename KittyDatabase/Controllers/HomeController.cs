using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KittyDatabase.Models;
using KittyDatabase.Models.ViewModels;

namespace KittyDatabase.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(int Score, string Player)
        {
            var highscore = new HighScore()
            {
                Player = Player,
                Score = Score
            };
            HighScoreRepo.CreateHighScore(highscore);
            return RedirectToAction("Highscores", "Home");
        }

        public IActionResult HighScores()
        {
            var hsm = new HighScoreViewModel();
            hsm.HighScores = HighScoreRepo.GetHighScores();
            return View(hsm);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
