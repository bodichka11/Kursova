using OnlineGame.Models;

namespace OnlineGame.DTO_S.Player
{
    public class PlayerEditDto: Entity<long>
    {
        public string Nickname { get; set; }
        public int Rating { get; set; }
        public int Level { get; set; } 
    }
}
