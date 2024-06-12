using Microsoft.AspNetCore.Mvc;
using PokerPocket.Models;
using PokerPocket.Services.Interfaces;
using System.Threading.Tasks;

namespace PokerPocket.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _gameService.GetAllGames();
            return View(games);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GameModel game)
        {
            if (ModelState.IsValid)
            {
                await _gameService.CreateGame(game);
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        public async Task<IActionResult> Play(int id)
        {
            var game = await _gameService.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer(int gameId, PlayerModel player)
        {
            if (ModelState.IsValid)
            {
                await _gameService.AddPlayerToGame(gameId, player);
                return RedirectToAction(nameof(Play), new { id = gameId });
            }
            return View("Play", new { id = gameId });
        }

        [HttpPost]
        public async Task<IActionResult> StartGame(int gameId)
        {
            await _gameService.StartGame(gameId);
            return RedirectToAction(nameof(StartPlay), new { id = gameId });
        }

        public async Task<IActionResult> StartPlay(int id)
        {
            var game = await _gameService.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> Bet(int gameId, int playerId, int betAmount)
        {
            // Implement bet logic here
            // Example: await _gameService.PlaceBet(gameId, playerId, betAmount);
            return RedirectToAction(nameof(StartPlay), new { id = gameId });
        }

        [HttpPost]
        public async Task<IActionResult> Fold(int gameId, int playerId)
        {
            // Implement fold logic here
            // Example: await _gameService.Fold(gameId, playerId);
            return RedirectToAction(nameof(StartPlay), new { id = gameId });
        }

        [HttpPost]
        public async Task<IActionResult> Check(int gameId, int playerId)
        {
            // Implement check logic here
            // Example: await _gameService.Check(gameId, playerId);
            return RedirectToAction(nameof(StartPlay), new { id = gameId });
        }

        [HttpPost]
        public async Task<IActionResult> Call(int gameId, int playerId)
        {
            // Implement call logic here
            // Example: await _gameService.Call(gameId, playerId);
            return RedirectToAction(nameof(StartPlay), new { id = gameId });
        }

        public string PlayerHand(int gameId, int playerId)
        {
            return _gameService.GetPlayerHand(gameId, playerId);
        }
    }
}
