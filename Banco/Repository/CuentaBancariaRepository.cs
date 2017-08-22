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

        public CuentaBancaria Read(string no)
        {

            return ApplicationDbContext.applicationDbContext.CuentaBancarias.Find(no);
        }

        public CuentaBancaria Delete(CuentaBancaria cuentaBancaria)
        {

            return ApplicationDbContext.applicationDbContext.CuentaBancarias.Remove(cuentaBancaria);

        }

        public void PutEntrada(CuentaBancaria cuentaBancaria)
        {

            ApplicationDbContext.applicationDbContext.Entry(cuentaBancaria).State = EntityState.Modified;

        }
    }
}