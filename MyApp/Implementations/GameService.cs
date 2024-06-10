using System;
using System.Linq;
using System.Threading.Tasks;
using PokerPocket.Models;
using PokerPocket.Services.Interfaces;
using PokerPocket.Data.Entities;



namespace PokerPocket.Services.Implementations
{
    public class GameService : IGameService
    {
        // Placeholder for demo purposes. Replace with actual data access logic.
        private static GameModel[] _games = new GameModel[0];

        public Task<GameModel> CreateGame(GameModel game)
        {
            // Generate a unique ID for the game (replace with actual logic)
            game.Id = _games.Length + 1;
            
            // Add the game to the collection (replace with actual data storage logic)
            _games = _games.Append(game).ToArray();

            return Task.FromResult(game);
        }

        public Task<GameModel> GetGameById(int id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            if (game == null)
                {
                    // Handle the case where the game with the specified ID is not found
                    throw new ArgumentException("Game not found", nameof(id));
                }
            return Task.FromResult(game);
        }

        public Task<GameModel[]> GetAllGames()
        {
            return Task.FromResult(_games);
        }

        public Task<GameModel[]> GetGamesByUserId(int userId)
        {
            var userGames = _games.Where(g => g.UserId == userId).ToArray();
            return Task.FromResult(userGames);
        }

        public Task<GameModel> UpdateGame(GameModel game)
        {
            var existingGame = _games.FirstOrDefault(g => g.Id == game.Id);
            if (existingGame != null)
            {
                // Update the existing game (replace with actual update logic)
                existingGame.Name = game.Name;
                existingGame.Description = game.Description;
            }

            return Task.FromResult(existingGame);
        }

        public Task<bool> DeleteGame(int id)
        {
            var existingGame = _games.FirstOrDefault(g => g.Id == id);
            if (existingGame != null)
            {
                // Remove the game from the collection (replace with actual deletion logic)
                _games = _games.Where(g => g.Id != id).ToArray();
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
