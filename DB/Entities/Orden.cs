using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Orden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int IdCuenta { get; set; }
        public int IdActivo { get; set; }
        [ForeignKey(nameof(IdActivo))]
        public virtual Activo Activo { get; set; }
        public int Cantidad { get; set; } = 0;
        public double Precio { get; set; }
        public char Operacion { get; set; }
        public int IdEstado { get; set; }
        [ForeignKey(nameof(IdEstado))]
        public virtual Estado EstadoOperacion { get; set; }

        public virtual double MontoTotal => Precio * Cantidad;
       
    }
}
