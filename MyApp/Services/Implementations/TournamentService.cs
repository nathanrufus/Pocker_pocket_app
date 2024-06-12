using System.Collections.Generic;
using System.Threading.Tasks;
using PokerPocket.Models;
using PokerPocket.Services.Interfaces;

namespace PokerPocket.Services.Implementations
{
    public class TournamentService : ITournamentService
    {
        private static List<TournamentModel> _tournaments = new List<TournamentModel>();

        public Task<List<TournamentModel>> GetAllTournaments()
        {
            return Task.FromResult(_tournaments);
        }

        public Task<TournamentModel> GetTournamentById(int id)
        {
            return Task.FromResult(_tournaments.Find(t => t.TournamentId == id));
        }

        public Task CreateTournament(TournamentModel tournament)
        {
            tournament.TournamentId = _tournaments.Count + 1;
            _tournaments.Add(tournament);
            return Task.CompletedTask;
        }

        public Task UpdateTournament(TournamentModel tournament)
        {
            var existingTournament = _tournaments.Find(t => t.TournamentId == tournament.TournamentId);
            if (existingTournament != null)
            {
                existingTournament.Name = tournament.Name;
                existingTournament.Games = tournament.Games;
            }
            return Task.CompletedTask;
        }

        public Task DeleteTournament(int id)
        {
            _tournaments.RemoveAll(t => t.TournamentId == id);
            return Task.CompletedTask;
        }
    }
}
