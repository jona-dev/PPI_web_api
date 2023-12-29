using AutoMapper;
using DB.Entities;
using DB.Entities.DTO;

namespace PPI_web_Api.Mapper
{
    public class OrdenDTO_Remove_Orden_profile : Profile
    {
        public OrdenDTO_Remove_Orden_profile()
        {
            CreateMap<OrdenDTO_Remove, Orden>()
                .ForMember(dest => dest.Activo, origen => origen.MapFrom(mapa => new Activo()));
        }
    }
}
