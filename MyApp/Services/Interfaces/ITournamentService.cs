using System.Collections.Generic;
using System.Threading.Tasks;
using PokerPocket.Models;

namespace PokerPocket.Services.Interfaces
{
    public interface ITournamentService
    {
        Task<List<TournamentModel>> GetAllTournaments();
        Task<TournamentModel> GetTournamentById(int id);
        Task CreateTournament(TournamentModel tournament);
        Task UpdateTournament(TournamentModel tournament);
        Task DeleteTournament(int id);
    }
}
