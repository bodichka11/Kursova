using AutoMapper;
using OnlineGame.DTO_S;
using OnlineGame.DTO_S.Game;
using OnlineGame.DTO_S.Mode;
using OnlineGame.Models;

namespace OnlineGame.MappingProfiles
{
    public class ModeProfile: Profile
    {
        public ModeProfile()
        {
            CreateMap<NewModeDto, Mode>();
            CreateMap<Mode, ModeDto>();
            CreateMap<ModeDto, Mode>();
            CreateMap<Mode, ModeFullDto>();
            CreateMap<ModeEditDto, Mode>();
        }
    }
}
