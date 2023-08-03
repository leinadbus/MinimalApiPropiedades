using AutoMapper;
using MinimalApiPropiedades.Models;
using MinimalApiPropiedades.Models.DTOS;

namespace MinimalApiPropiedades.Mapper
{
    public class ConfiguracionMapper : Profile
    {
        public ConfiguracionMapper()
        {
            CreateMap<Propiedad, CrearPropiedadDto>().ReverseMap();
            CreateMap<Propiedad, PropiedadDto>().ReverseMap();
        }
    }
}
