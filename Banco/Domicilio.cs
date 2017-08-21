using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banco
{
	public class Domicilio
	{
		public long Id { get; set; }

		public String Calle { get; set; }
		public String NumeroPortal { get; set; }
		public int Piso { get; set; }
		public char Puerta { get; set; }
		public String CodPostal { get; set; }
		
	}
}