using System.ComponentModel.DataAnnotations;

namespace PokerPocket.Models
{
    public class GameModel
    {
        [Key]
        public int GameId { get; set; }
        public string Name { get; set; }
        public List<PlayerModel> Players { get; set; }
    }
}
