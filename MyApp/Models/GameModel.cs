using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PokerPocket.Models
{
    public class GameModel
    {
        [Key]
        public int GameId { get; set; }
        public string Name { get; set; }
        public List<PlayerModel> Players { get; set; }
        public List<CardModel> CommunityCards { get; set; }
        public int Pot { get; set; }
        public int CurrentBetAmount { get; set; }
        public int CurrentPlayerIndex { get; set; }

        public int DeckId { get; set; } // Foreign key to DeckModel
        public DeckModel Deck { get; set; }

        public GameModel()
        {
            Players = new List<PlayerModel>();
            CommunityCards = new List<CardModel>(); // Initialize the CommunityCards list
            CurrentPlayerIndex = 0;
        }

        public void DealCardsToPlayers()
        {
            foreach (var player in Players)
            {
                player.Cards.Clear();
                player.Cards.Add(Deck.DealCard());
                player.Cards.Add(Deck.DealCard());
            }
        }

        public void DealCommunityCards()
        {
            CommunityCards.Clear();
            for (int i = 0; i < 5; i++)
            {
                CommunityCards.Add(Deck.DealCard());
            }
        }

        public PlayerModel GetCurrentPlayer()
        {
            return Players[CurrentPlayerIndex];
        }

        public void NextTurn()
        {
            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Players.Count;
        }
    }
}
