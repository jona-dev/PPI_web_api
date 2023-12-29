using AutoMapper;
using DB.Entities;
using DB.Entities.DTO;

namespace PPI_web_Api.Mapper
{
    public class OrdenDTO_Add_Orden_profile : Profile
    {
        public OrdenDTO_Add_Orden_profile()
        {
            CreateMap<OrdenDTO_Add, Orden>()
                .ForMember(dest => dest.Activo, origen => origen.MapFrom(mapa => new Activo()))
                ;
        }
    }
}
