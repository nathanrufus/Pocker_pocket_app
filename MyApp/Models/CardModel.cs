using System.ComponentModel.DataAnnotations;

namespace PokerPocket.Models
{
    public class CardModel
    {
        [Key]
        public int CardId { get; set; }
        public string Suit { get; set; }
        public string Rank { get; set; }
    }
}
