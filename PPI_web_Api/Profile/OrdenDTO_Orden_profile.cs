using AutoMapper;
using DB.Entities;
using DB.Entities.DTO;

namespace PPI_web_Api.Mapper
{
    public class OrdenDTO_Orden_profile : Profile
    {
        public OrdenDTO_Orden_profile()
        {
            CreateMap<OrdenDTO, Orden>();
        }
    }
}
