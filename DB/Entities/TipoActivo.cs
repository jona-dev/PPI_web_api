
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Entities
{
    public enum enumTipoActivos
    { 
        Acción = 1,
        Bono = 2,
        FCI = 3
    }
    public class TipoActivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Descripcion {  get; set; }

    }
}