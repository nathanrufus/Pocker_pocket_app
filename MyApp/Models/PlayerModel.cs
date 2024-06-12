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
    }
}
