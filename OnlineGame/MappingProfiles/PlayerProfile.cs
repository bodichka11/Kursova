using AutoMapper;
using OnlineGame.DTO_S;
using OnlineGame.DTO_S.Player;
using OnlineGame.Models;

namespace OnlineGame.MappingProfiles
{
    public class PlayerProfile: Profile
    {
        public PlayerProfile()
        {
            CreateMap<NewPlayerDto, Player>();
            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerDto, Player>();
            CreateMap<Player, PlayerFullDto>();
            CreateMap<PlayerEditDto, Player>();
        }
    }
}
