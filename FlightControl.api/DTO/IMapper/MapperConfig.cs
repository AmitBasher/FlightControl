using AutoMapper;
using FlightControl.Api.Models;
using FlightControl.Domain.Models;

namespace FlightControl.Api.DTO.IMapper {
    public class MapperConfig {
        public static Mapper InitializeAutoMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<FlightDto, Flight>();
                cfg.CreateMap<Flight, FlightHistory>()
                    .ForMember(
                        dest => dest.FlightId,
                        opt => opt.MapFrom(src => $"{src.Id}"))
                    .ForMember(
                        dest => dest.StageId,
                        opt => opt.MapFrom(src => $"{src.CurrentStage}"))
                    .ForMember(
                        dest => dest.Id,
                        opt => opt.Ignore());
                cfg.CreateMap<Stage, StageDto>();
            });
            return new Mapper(config);
        }
    }
}
