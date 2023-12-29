using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities.DTO
{
    public class OrdenAccionDTO :OrdenDTO
    {
        private double Comision => Precio * Cantidad * 0.006;
        private double Impuestos => Comision * 0.21;

        public override double MontoTotal => Precio * Cantidad + Comision + Impuestos;
    }
}
