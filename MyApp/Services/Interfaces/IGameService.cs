using PokerPocket.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokerPocket.Services.Interfaces
{
    public interface IGameService
    {
        Task<GameModel> CreateGame(GameModel game);
        Task<List<GameModel>> GetAllGames();
        Task<GameModel> GetGameById(int gameId);
        Task<bool> AddPlayerToGame(int gameId, PlayerModel player);
        Task StartGame(int gameId);
        string GetPlayerHand(int gameId, int playerId);
    }
}
