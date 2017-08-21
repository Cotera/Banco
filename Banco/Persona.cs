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
        public DateTime FechaNacimiento { get; set; }

        public Persona()
        {

        }

        public Persona(long _Id, String _Nombre, String _Apellidos, DateTime _FechaNacimiento)
        {
            this.Id = _Id;
            this.Nombre = _Nombre;
            this.Apellidos = _Apellidos;
            this.FechaNacimiento = _FechaNacimiento;
        }
    }
}