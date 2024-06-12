using PokerPocket.Data;  // Correct namespace
using PokerPocket.Models;
using PokerPocket.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PokerPocket.Services.Implementations
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext _context;

        public GameService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GameModel> CreateGame(GameModel game)
        {
            game.Players = new List<PlayerModel>();
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<List<GameModel>> GetAllGames()
        {
            return await _context.Games.Include(g => g.Players).ToListAsync();
        }

        public async Task<GameModel> GetGameById(int gameId)
        {
            return await _context.Games.Include(g => g.Players).FirstOrDefaultAsync(g => g.GameId == gameId);
        }

        public async Task<bool> AddPlayerToGame(int gameId, PlayerModel player)
        {
            var game = await _context.Games.Include(g => g.Players).FirstOrDefaultAsync(g => g.GameId == gameId);
            if (game == null)
                return false;

            game.Players.Add(player);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task StartGame(int gameId)
        {
            var game = await _context.Games.Include(g => g.Players).FirstOrDefaultAsync(g => g.GameId == gameId);
            if (game == null)
                return;

            DeckModel deck = new DeckModel();
            deck.Shuffle();
            PokerLogic.DealToPlayers(game.Players, deck, 2); // Deal 2 cards to each player

            await _context.SaveChangesAsync();
        }

        public string GetPlayerHand(int gameId, int playerId)
        {
            var game = _context.Games.Include(g => g.Players).ThenInclude(p => p.Cards).FirstOrDefault(g => g.GameId == gameId);
            if (game == null)
                return "Game not found";

            var player = game.Players.FirstOrDefault(p => p.PlayerId == playerId);
            if (player == null)
                return "Player not found";

            return string.Join(", ", player.Cards.Select(c => $"{c.Rank} of {c.Suit}"));
        }

        public async Task PlaceBet(int gameId, int playerId, int betAmount)
        {
            // Implement bet logic here
            // For example: Update player's balance, add bet to pot, etc.
            await Task.CompletedTask;
        }

        public async Task Fold(int gameId, int playerId)
        {
            // Implement fold logic here
            await Task.CompletedTask;
        }

        public async Task Check(int gameId, int playerId)
        {
            // Implement check logic here
            await Task.CompletedTask;
        }

        public async Task Call(int gameId, int playerId)
        {
            // Implement call logic here
            await Task.CompletedTask;
        }
    }
}
