using AutoMapper;
using OnlineGame.DTO_S;
using OnlineGame.DTO_S.GameSession;
using OnlineGame.Models;

namespace OnlineGame.MappingProfiles
{
    public class GameSessionProfile: Profile
    {
        public GameSessionProfile()
        {
            CreateMap<NewGameSessionDto, GameSession>();
            CreateMap<GameSession, GameSessionDto>();
            CreateMap<GameSessionDto, GameSession>();
            CreateMap<GameSession, GameSessionFullDto>();
            CreateMap<GameSessionEditDto, GameSession>();

        }
    }
}
