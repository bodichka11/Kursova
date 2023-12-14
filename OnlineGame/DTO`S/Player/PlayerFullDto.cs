﻿using OnlineGame.Models;

namespace OnlineGame.DTO_S.Player
{
    public class PlayerFullDto
    {
        public string Nickname { get; set; }
        public int Rating { get; set; }
        public int Level { get; set; }
        public ICollection<AchievementDto> Achievements { get; set; }
        public ICollection<GameSessionDto> GameSessions { get; set; }
    }
}
