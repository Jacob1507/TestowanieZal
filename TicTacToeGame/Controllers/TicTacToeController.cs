using Microsoft.AspNetCore.Mvc;
using TicTacToeGame.Models;

namespace TicTacToeGame.Controllers
{
    public class TicTacToeController : Controller
    {
        private static TicTacToe game = new TicTacToe();

        public IActionResult Index()
        {
            ViewBag.CurrentPlayer = game.CurrentPlayer;
            return View(game);
        }

        [HttpPost]
        public IActionResult MakeMove(int index)
        {
            game.MakeMove(index);
            char winner = game.CheckWinner();

            if (winner != ' ')
            {
                ViewBag.Winner = $"Player {winner} has won!";
                game = new TicTacToe(); // Restart the game
            }
            else if (game.IsBoardFull())
            {
                ViewBag.Winner = "It's a tie!";
                game = new TicTacToe(); // Restart the game
            }
            else
            {
                ViewBag.CurrentPlayer = game.CurrentPlayer;
            }

            return View("Index", game);
        }
    }
}
