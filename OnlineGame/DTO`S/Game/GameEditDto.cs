using OnlineGame.Models;

namespace OnlineGame.DTO_S
{
    public class GameEditDto : Entity<long>
    {
        public string GameName { get; set; }
    }
}
