using System.Threading.Tasks;
using PokerPocket.Models;
using PokerPocket.Data.Entities;


namespace PokerPocket.Services.Interfaces
{
    public interface IGameService
    {
        Task<GameModel> CreateGame(GameModel game);
        Task<GameModel> GetGameById(int id);
        Task<GameModel[]> GetAllGames();
        Task<GameModel[]> GetGamesByUserId(int userId);
        Task<GameModel> UpdateGame(GameModel game);
        Task<bool> DeleteGame(int id);
    }
}
