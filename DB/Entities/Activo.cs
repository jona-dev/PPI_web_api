using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Activo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Ticker { get; set; }
        public string Nombre { get; set; }
        public double PrecionUnitario { get; set; }
        public int TipoId { get; set; }
        [ForeignKey(nameof(TipoId))]
        public virtual TipoActivo Tipo { get; set; }


    }
}
