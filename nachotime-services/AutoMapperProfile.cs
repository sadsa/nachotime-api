using AutoMapper;
using nachotime_api_models.Models;
using nachotime_data.Models;

namespace nachotime_services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Card, CardApiModel>().ReverseMap();
            CreateMap<Expression, ExpressionApiModel>().ReverseMap();
        }
    }
}
