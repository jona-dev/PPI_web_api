using AutoMapper;
using DB;
using DB.Entities;
using DB.Entities.DTO;
using Microsoft.EntityFrameworkCore;

namespace PPI_web_Api.Service
{
    public class OrdenService
    {

        private DbPPIContext _context;
        private IMapper _mapper;

        public OrdenService(DbPPIContext context, IMapper mapper) 
        { 
            _context = context;
            _mapper = mapper;   
        }

        private IEnumerable<OrdenDTO> ConvertOrdenToOrdeDTO(IEnumerable<Orden> ordenes)
        {
            List<OrdenDTO> result = new List<OrdenDTO>();
            foreach (var orden in ordenes)
            {
                var activo = _context.Activos
                    .Include(a => a.Tipo)
                    .FirstOrDefault(a => a.Nombre.ToLower() == orden.Activo.Nombre.ToLower());
                bool parseCorrecto = Enum.TryParse<enumTipoActivos>(activo.Tipo.Descripcion, out var resultTipo);
                switch (resultTipo)
                {
                    case enumTipoActivos.Acción:
                        result.Add( _mapper.Map<OrdenAccionDTO>(orden));
                        break;
                    case enumTipoActivos.FCI:
                        result.Add(_mapper.Map<OrdenFCIDTO>(orden));
                        break;
                    case enumTipoActivos.Bono:
                        result.Add(_mapper.Map<OrdenBonoDTO>(orden));
                        break;
                }
            }
            return result;
        }

        public IEnumerable<OrdenDTO> GetAllOrdenes()
        {
            var ordenes = _context.Ordenes
                                    .Include(o => o.EstadoOperacion)
                                    .Include(a => a.Activo)
                                    .ToList();
            return ConvertOrdenToOrdeDTO(ordenes).ToList();
        }

        public void PutOrden(OrdenDTO_Add ordenAdd)
        {
            var orden = _mapper.Map<Orden>(ordenAdd);
            var estadoEnProgreso = _context.Estados.FirstOrDefault(e => e.ID == (int)enumEstados.EnProceso);

            var activo = _context.Activos
                .Include(a => a.Tipo)
                .FirstOrDefault(a => a.Nombre.ToLower() == ordenAdd.Activo.ToLower());
            if (activo == null) new ArgumentException("Activo no reconocido");

            orden.Precio = activo.Tipo.ID == (int)enumTipoActivos.Acción ? activo.PrecionUnitario : orden.Precio;
            orden.IdEstado = estadoEnProgreso.ID;
            orden.EstadoOperacion = estadoEnProgreso;
            orden.IdActivo = activo.ID;
            orden.Activo= activo;

            _context.Ordenes.Add(orden);
            _context.SaveChangesAsync();

        }

        public void UpdateOrden(OrdenDTO_Update ordenUpdate)
        {
            var orden = _mapper.Map<Orden>(ordenUpdate);

            var activo = _context.Activos
                .Include(a => a.Tipo)
                .FirstOrDefault(a => a.Nombre.ToLower() == ordenUpdate.Activo.ToLower());
            if (activo == null) new ArgumentException("Activo no reconocido");
            orden.Activo = activo;

            _context.Entry(orden.Activo).State = EntityState.Unchanged;

            _context.Ordenes.Update(orden);
            _context.SaveChangesAsync();
        
        }

        public void RemoveOrden(OrdenDTO_Remove ordenRemove)
        {
            var orden = new Orden()
            {
                ID = ordenRemove.ID
            };
            _context.Ordenes.Remove(orden);
            _context.SaveChangesAsync();
        }
    }
}
