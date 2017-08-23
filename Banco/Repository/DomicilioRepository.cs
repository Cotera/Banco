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

		public Domicilio Read(long id)
		{
			return ApplicationDbContext.applicationDbContext.Domicilio.Find(id);
		}

		public IQueryable<Domicilio> ReadAll()
		{
			IList<Domicilio> lista = new List<Domicilio>(
				ApplicationDbContext.applicationDbContext.Domicilio);
			return lista.AsQueryable();
		}

		public void Update(Domicilio domicilio)
		{
			if (ApplicationDbContext.applicationDbContext.Domicilio.Count
				(d => d.Id == domicilio.Id) == 0)
			{
				throw new NoEncontradoException("No se ha encontrado la entidad");
			}

			ApplicationDbContext.applicationDbContext.Entry(domicilio).State =
				EntityState.Modified;
		}

		public Domicilio Delete(long id)
		{
			Domicilio domicilio = ApplicationDbContext.applicationDbContext.Domicilio.Find(id);

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