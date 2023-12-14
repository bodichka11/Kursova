namespace OnlineGame.DTO_S.GameSession
{
    public class GameSessionFullDto
    {
        public long ModeId { get; set; }
        public long GameId { get; set; }
        //public long PlayerId { get; set; }
        public GameDto Game { get; set; }
        public ModeDto Mode { get; set; }
        public ICollection<PlayerDto> Players { get; set; }
    }
}
