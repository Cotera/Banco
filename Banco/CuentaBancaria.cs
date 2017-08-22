using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banco
{
    public class CuentaBancaria
    {
        [Key]
        public String No { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Double Saldo { get; set; }
    }
}