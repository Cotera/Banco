using Banco.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Banco.Repository
{
    public class CuentaBancariaRepository : ICuentaBancariaRepository
    {
        public CuentaBancaria Create(CuentaBancaria _entrada)
        {

            return ApplicationDbContext.applicationDbContext.CuentaBancarias.Add(_entrada);
        }

        public IQueryable<CuentaBancaria> ReadCuentaBancaria()
        {
            IList<CuentaBancaria> lista = new List<CuentaBancaria>(ApplicationDbContext.applicationDbContext.CuentaBancarias);
            return lista.AsQueryable();
        }

        public CuentaBancaria Read(long Id)
        {

            return ApplicationDbContext.applicationDbContext.CuentaBancarias.Find(Id);
        }

        public CuentaBancaria Delete(long Id)
        {
            CuentaBancaria cuentaBancaria = this.Read(Id);
            if (cuentaBancaria == null)
            {
                throw new NoEncontradoException("No se ha encontrado la persona  a eliminar");
            }
            return ApplicationDbContext.applicationDbContext.CuentaBancarias.Remove(cuentaBancaria);

        }

        public void PutEntrada(CuentaBancaria cuentaBancaria)
        {

            ApplicationDbContext.applicationDbContext.Entry(cuentaBancaria).State = EntityState.Modified;

        }
    }
}