﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities.DTO
{
    public class OrdenDTO_Add
    {
        public int IdCuenta { get; set; }
        public String Activo { get; set; }
        public int Cantidad { get; set; } = 0;
        public double Precio { get; set; }
        public char Operacion { get; set; }
       
    }
}
