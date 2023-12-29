using AutoMapper;
using DB.Entities;
using DB.Entities.DTO;

namespace PPI_web_Api.Mapper
{
    public class Orden_OrdenDTO_profile : Profile
    {
        public Orden_OrdenDTO_profile()
        {
            CreateMap<Orden, OrdenDTO>()
                .ForMember(dest => dest.ID, origen => origen.MapFrom(mapa => mapa.ID))
                .ForMember(dest => dest.IdCuenta, origen => origen.MapFrom(mapa => mapa.IdCuenta))
                .ForMember(dest => dest.Cantidad, origen => origen.MapFrom(mapa => mapa.Cantidad))
                .ForMember(dest => dest.Activo, origen => origen.MapFrom(mapa => mapa.Activo.Nombre.ToString()))
                .ForMember(dest => dest.Operacion, origen => origen.MapFrom(mapa => mapa.Operacion))
                .ForMember(dest => dest.Precio, origen => origen.MapFrom(mapa => mapa.Precio))
                .ForMember(dest => dest.IdEstado, origen => origen.MapFrom(mapa => mapa.IdEstado))
                .ForMember(dest => dest.EstadoOperacion, origen => origen.MapFrom(mapa =>
                                                                                   new Estado()
                                                                                   {
                                                                                       ID = mapa.EstadoOperacion.ID,
                                                                                       Descripcion = mapa.EstadoOperacion.Descripcion
                                                                                   }))
                ;
        }
    }
}
