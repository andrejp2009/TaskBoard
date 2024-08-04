namespace TaskBoard.Models
{
    public class BoardUser
    {
        public int BoardId { get; set; }
        public Board Board { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public string Role { get; set; } 
    }
}
