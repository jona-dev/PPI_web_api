using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities.DTO
{
    public  class OrdenFCIDTO : OrdenDTO
    {
        public override double MontoTotal => Precio * Cantidad;

    }
}
