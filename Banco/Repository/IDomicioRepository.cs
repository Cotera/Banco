using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Repository
{
	public interface IDomicioRepository
	{
		void Create(Domicilio _domicilio);

		Domicilio Read(long _id);

		IList<Domicilio> ReadAll(long _id);

		void Delete(long _id);

		void Update(Domicilio _domicilio);

	}
}
