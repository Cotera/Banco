using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banco
{
    public class Persona
    {
        public long Id { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }

       
    }
}