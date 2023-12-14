using AutoMapper;
using OnlineGame.DTO_S;
using OnlineGame.DTO_S.Achievement;
using OnlineGame.Models;

namespace OnlineGame.MappingProfiles
{
    public class AchievementProfile: Profile
    {
        public AchievementProfile()
        {
            CreateMap<NewAchievementDto, Achievement>();
            CreateMap<Achievement, AchievementDto>();
            CreateMap<AchievementDto, Achievement>();
            CreateMap<Achievement, AchievementFullDto>();
            CreateMap<AchievementEditDto, Achievement>();
        }
    }
}
