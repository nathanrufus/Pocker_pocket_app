using System.Collections.Generic;
using System.Linq;

namespace PokerPocket.Models
{
    public class PokerLogic
    {
        public static string EvaluateHand(HandModel hand)
        {
            // Basic hand evaluation logic for example purposes.
            // Implement proper poker hand ranking here.
            if (hand.Cards.Any(card => card.Rank == "A"))
            {
                return "High Card: Ace";
            }
            return "Unknown Hand";
        }

        public static void DealToPlayers(List<PlayerModel> players, DeckModel deck, int cardsPerPlayer)
        {
            for (int i = 0; i < cardsPerPlayer; i++)
            {
                foreach (var player in players)
                {
                    player.Cards.Add(deck.DealCard());
                }
            }
        }
    }
}
