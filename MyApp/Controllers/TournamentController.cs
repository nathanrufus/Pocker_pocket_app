using Microsoft.AspNetCore.Mvc;
using PokerPocket.Services.Interfaces;
using PokerPocket.Models;
using System.Threading.Tasks;

namespace PokerPocket.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        public async Task<IActionResult> Index()
        {
            var tournaments = await _tournamentService.GetAllTournaments();
            return View(tournaments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TournamentModel tournament)
        {
            if (ModelState.IsValid)
            {
                await _tournamentService.CreateTournament(tournament);
                return RedirectToAction(nameof(Index));
            }
            return View(tournament);
        }

        public async Task<IActionResult> Details(int id)
        {
            var tournament = await _tournamentService.GetTournamentById(id);
            if (tournament == null)
            {
                return NotFound();
            }
            return View(tournament);
        }
    }
}
