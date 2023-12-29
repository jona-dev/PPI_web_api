using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities.DTO
{
    public class OrdenDTO
    {
        public int ID { get; set; }
        public int IdCuenta { get; set; }
        public String Activo { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public char Operacion { get; set; }
        public int? IdEstado { get; set; }
        public Estado? EstadoOperacion { get; set; }
        public virtual double MontoTotal { get; set; }

    }
}
