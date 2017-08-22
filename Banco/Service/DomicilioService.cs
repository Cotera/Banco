using Banco.Models;
using Banco.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banco.Service
{
	public class DomicilioService : IDomicilioService
	{
		private IDomicilioRepository domicilioRepository;

		public DomicilioService(IDomicilioRepository _domicilioRepository)
		{
			this.domicilioRepository = _domicilioRepository;
		}

		public Domicilio Create(Domicilio _domicilio)
		{
			using (var context = new ApplicationDbContext())
			{
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try
					{
						_domicilio = domicilioRepository.Create(_domicilio);
						context.SaveChanges();
						dbContextTransaction.Commit();
					}
					catch(Exception e)
					{
						dbContextTransaction.Rollback();
						throw new Exception("Rollback realizado ", e);
					}
				}
			}

			return _domicilio;
		}

		public Domicilio Read(long _id)
		{
			Domicilio resultado = null;

			using (var context = new ApplicationDbContext())
			{
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try
					{
						resultado = domicilioRepository.Read(_id);
							
					}catch (Exception e)
					{
						throw new Exception("Fallo de lectura de db: ", e);
					}
				}
			}
			return resultado;
		}

		public IQueryable<Domicilio> ReadAll()
		{
			IQueryable<Domicilio> resultado = null;
			using (var context = new ApplicationDbContext())
			{
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try
					{
						resultado = domicilioRepository.ReadAll();
					}
					catch (Exception e)
					{
						new Exception("Fallo de lectura de db: ", e);
					}
				}
			}
			return resultado;
		}

		public void Update(Domicilio _domicilio)
		{
			using (var context = new ApplicationDbContext())
			{
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try
					{
						domicilioRepository.Update(_domicilio);
						context.SaveChanges();
						dbContextTransaction.Commit();
					} catch(Exception e)
					{
						dbContextTransaction.Rollback();
						throw new Exception("Rollback realizado ", e);
					}
				}
			}
			
		}

		public Domicilio Delete(long _id)
		{
			Domicilio resultado = null;
			using (var context = new ApplicationDbContext())
			{
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try
					{
						resultado = domicilioRepository.Delete(_id);
						context.SaveChanges();
						dbContextTransaction.Commit();
					}
					catch (NoEncontradoException)
					{
						dbContextTransaction.Rollback();
						throw;
					}
					catch (Exception e)
					{
						new Exception("Rollback realizado ", e);
					}
				}
			}
			return resultado;
		}

	}
}