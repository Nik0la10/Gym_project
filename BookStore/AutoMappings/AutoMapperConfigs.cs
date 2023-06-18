using AutoMapper;
using Gym.Models.Data;
using Gym.Models.Request;

namespace Gym.AutoMappings
{
    public class AutoMapperConfigs : Profile
    {
        public AutoMapperConfigs()
        {
            CreateMap<AddManufacturerRequest, Manufacturer>();
        }
    }
}
