using DB;
using DB.Entities;
using Microsoft.EntityFrameworkCore;
using PPI_web_Api.Controllers;

namespace PPI_web_Api.DB
{
    public class InitialData
    {
        private DbPPIContext _context;

        public InitialData( DbPPIContext context)
        {
            _context = context;
        }
        public void InitAll()
        {
            InitEstados();
            InitTipoActivos();
            InitActivos();
            InitUser();
            //_context.SaveChanges();
        }

        private void InitEstados()
        {
            if( !_context.Estados.Any(e => e.Descripcion== "En Proceso") )
                _context.Estados.Add(new Estado() { Descripcion="En Proceso"});
            if (!_context.Estados.Any(e => e.Descripcion == "Ejecutada"))
                _context.Estados.Add(new Estado() { Descripcion = "Ejecutada" });
            if (!_context.Estados.Any(e => e.Descripcion == "Cancelada"))
                _context.Estados.Add(new Estado() { Descripcion = "Cancelada" });
            _context.SaveChanges();

        }

        private void InitTipoActivos()
        {
            if (!_context.TipoActivos.Any(e => e.Descripcion == "Acción"))
                _context.TipoActivos.Add(new TipoActivo() { Descripcion = "Acción" });
            if (!_context.TipoActivos.Any(e => e.Descripcion == "Bono"))
                _context.TipoActivos.Add(new TipoActivo() { Descripcion = "Bono" });
            if (!_context.TipoActivos.Any(e => e.Descripcion == "FCI"))
                _context.TipoActivos.Add(new TipoActivo() { Descripcion = "FCI" });
            _context.SaveChanges();
        }

        private void InitActivos()
        {

            var tipoAccion = _context.TipoActivos.FirstOrDefault(t => t.Descripcion == "Acción");
            var tipoBono = _context.TipoActivos.FirstOrDefault(t => t.Descripcion == "Bono"); ;
            var tipoFCI = _context.TipoActivos.FirstOrDefault(t => t.Descripcion == "FCI"); ;
            if (!_context.Activos.Any(e => e.Ticker == "AAPL"))
                _context.Activos.Add(new Activo() {
                    Ticker = "AAPL",
                    Nombre = "Apple",
                    TipoId = 1,
                    Tipo = tipoAccion,
                    PrecionUnitario = 177.97
                }) ;
            if (!_context.Activos.Any(e => e.Ticker == "GOOGL"))
                _context.Activos.Add(new Activo()
                {
                    Ticker = "GOOGL",
                    Nombre = "Alphabet Inc",
                    TipoId = 1,
                    Tipo = tipoAccion,
                    PrecionUnitario = 138.21
                });
            if (!_context.Activos.Any(e => e.Ticker == "MSFT"))
                _context.Activos.Add(new Activo()
                {
                    Ticker = "MSFT",
                    Nombre = "Microsoft",
                    TipoId = 1,
                    Tipo = tipoAccion,
                    PrecionUnitario = 329.04
                });
            if (!_context.Activos.Any(e => e.Ticker == "KO"))
                _context.Activos.Add(new Activo()
                {
                    Ticker = "KO",
                    Nombre = "Coca cola",
                    TipoId = 1,
                    Tipo = tipoAccion,
                    PrecionUnitario = 58.3
                });
            if (!_context.Activos.Any(e => e.Ticker == "WMT"))
                _context.Activos.Add(new Activo()
                {
                    Ticker = "WMT",
                    Nombre = "Walmart",
                    TipoId = 1,
                    Tipo = tipoAccion,
                    PrecionUnitario = 163.42
                });
            if (!_context.Activos.Any(e => e.Ticker == "AL30"))
                _context.Activos.Add(new Activo()
                {
                    Ticker = "AL30",
                    Nombre = "Bonos Argentina USD 2030 L.A",
                    TipoId = 2,
                    Tipo = tipoBono,
                    PrecionUnitario = 307.4
                });
            if (!_context.Activos.Any(e => e.Ticker == "GD30"))
                _context.Activos.Add(new Activo()
                {
                    Ticker = "GD30",
                    Nombre = "Bonos Globales Argentina USD Step Up 2030",
                    TipoId = 2,
                    Tipo = tipoBono,
                    PrecionUnitario = 336.1
                });
            if (!_context.Activos.Any(e => e.Ticker == "Delta.Pesos"))
                _context.Activos.Add(new Activo()
                {
                    Ticker = "Delta.Pesos",
                    Nombre = "Delta Pesos Clase A",
                    TipoId = 3,
                    Tipo = tipoFCI,
                    PrecionUnitario = 0.0181
                });
            if (!_context.Activos.Any(e => e.Ticker == "Fima.Premium"))
                _context.Activos.Add(new Activo()
                {
                    Ticker = "Fima.Premium",
                    Nombre = "Fima Premium Clase A",
                    TipoId = 1,
                    Tipo = tipoFCI,
                    PrecionUnitario = 0.0317
                });
            _context.SaveChanges();
        }

        private void InitUser()
        {
            if (!_context.Users.Any(e => e.Email == "moran.j.e99@gmail.com"))
                _context.Users.Add(new User() 
                { 
                    Email = "moran.j.e99@gmail.com",
                    Password = "PPI2023"
                });
            _context.SaveChanges();

        }
    }
}
