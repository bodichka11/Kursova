using AutoMapper;
using OnlineGame.DTO_S;
using OnlineGame.DTO_S.Game;
using OnlineGame.Models;

namespace OnlineGame.MappingProfiles
{
    public class GameProfile: Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameDto>();
            CreateMap<GameDto, Game>();
            CreateMap<GameEditDto, Game>();
            CreateMap<Game, GameFullDto>();
            CreateMap<NewGameDto, Game>();
        }
    }
}
