using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PokerPocket.Models
{
    public class PlayerModel
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public List<CardModel> Cards { get; set; } = new List<CardModel>();
        public int Balance { get; set; }
        public int BetAmount { get; set; } // Add this property for player bet amount

        public PlayerModel()
        {
            Balance = 1000; // Example initial balance
        }

        public void PlaceBet(int amount)
        {
            BetAmount += amount;
            Balance -= amount;
        }

        public void ClearHand()
        {
            Cards.Clear();
        }
    }
}
