﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Repository
{
	public interface IDomicilioRepository
	{
		Domicilio Create(Domicilio _domicilio);

		Domicilio Read(long _id);

		IQueryable<Domicilio> ReadAll();

		void Update(Domicilio _domicilio);

		Domicilio Delete(long _id);

	}
}