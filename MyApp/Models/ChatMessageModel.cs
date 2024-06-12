using System.ComponentModel.DataAnnotations;

namespace PokerPocket.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
