using Banco.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Banco.Repository
{
	public class DomicilioRepository : IDomicilioRepository
	{
		public Domicilio Create(Domicilio _domicilio)
		{ 
			return ApplicationDbContext.applicationDbContext.Domicilio.Add(_domicilio);
		}

		public Domicilio Read(long _id)
		{
			return ApplicationDbContext.applicationDbContext.Domicilio.Find(_id);
		}

		public IQueryable<Domicilio> ReadAll()
		{
			IList<Domicilio> lista = new List<Domicilio>(
				ApplicationDbContext.applicationDbContext.Domicilio);
			return lista.AsQueryable();
		}

		public void Update(Domicilio _domicilio)
		{
			if (ApplicationDbContext.applicationDbContext.Domicilio.Count
				(d => d.Id == _domicilio.Id) == 0)
			{
				throw new NoEncontradoException("No se ha encontrado la entidad");
			}

			ApplicationDbContext.applicationDbContext.Entry(_domicilio).State =
				EntityState.Modified;
			throw new NotImplementedException();
		}

		public Domicilio Delete(long _id)
		{
			Domicilio domicilio = ApplicationDbContext.applicationDbContext.Domicilio.Find(_id);

			if (domicilio == null)
			{
				throw new NoEncontradoException("Entidad no encontrada");
			}
			ApplicationDbContext.applicationDbContext.Domicilio.Remove(domicilio);
			ApplicationDbContext.applicationDbContext.SaveChanges();

			return domicilio;
		}

	}
}