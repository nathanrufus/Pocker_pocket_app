namespace PokerPocket.Data.Entities
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; } // Add this property

        public string Description { get; set; }
    }
}
