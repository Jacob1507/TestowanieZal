using Microsoft.AspNetCore.Mvc;
using TicTacToeGame.Models;

namespace TicTacToeGame.Controllers
{
    public class TicTacToeController : Controller
    {
        private static TicTacToe game = new TicTacToe();

        public IActionResult Index()
        {
            return View(game);
        }

        [HttpPost]
        public IActionResult MakeMove(int index)
        {
            game.MakeMove(index);
            char winner = game.CheckWinner();
            if (winner != ' ')
            {
                ViewBag.Winner = winner;
                game = new TicTacToe(); // Restart the game
            }
            return View("Index", game);
        }
    }
}
