using System.ComponentModel.DataAnnotations;

namespace PokerPocket.Models
{
    public class TournamentModel
    {
        [Key]
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public List<GameModel> Games { get; set; }
    }
}
