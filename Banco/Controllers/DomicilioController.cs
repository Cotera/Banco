using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace Banco.Controllers
{
	public class DomicilioController : IDomicilioController
	{
		//GET : api/Persona
		[ResponseType(typeof(Domicilio))]
		public void Create(Domicilio _domicilio)
		{
			throw new NotImplementedException();
		}

		public void Delete(long _id)
		{
			throw new NotImplementedException();
		}

		public Domicilio Read(long _id)
		{
			throw new NotImplementedException();
		}

		public IList<Domicilio> ReadAll(long _id)
		{
			throw new NotImplementedException();
		}

		public void Update(Domicilio _domicilio)
		{
			throw new NotImplementedException();
		}
	}
}