using Banco.Models;
using Banco.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banco.Service
{
    public class CuentaBancariaService : ICuentaBancariaService
    {
        private ICuentaBancariaRepository cuentaBancariaRepository;
        public CuentaBancariaService(ICuentaBancariaRepository _cuentaBancariaRepository)
        {
            this.cuentaBancariaRepository = _cuentaBancariaRepository;
        }
        public CuentaBancaria Create(CuentaBancaria cuentaBancaria)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        cuentaBancaria = cuentaBancariaRepository.Create(cuentaBancaria);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return cuentaBancaria;
            }
        }

        public IQueryable<CuentaBancaria> ReadCuentaBancarias()
        {
            using (var context = new ApplicationDbContext())
            {
                IQueryable<CuentaBancaria> cuentasBancarias;
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        cuentasBancarias = cuentaBancariaRepository.ReadCuentaBancaria();
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return cuentasBancarias;
            }
        }

        public CuentaBancaria GetCuentaBancaria(string no)
        {
            using (var context = new ApplicationDbContext())
            {
                CuentaBancaria cuentaBancaria;
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        cuentaBancaria = cuentaBancariaRepository.Read(no);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return cuentaBancaria;
            }
        }

        public void PutCuentaBancaria(CuentaBancaria cuentaBancaria)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        cuentaBancariaRepository.PutEntrada(cuentaBancaria);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
            }
        }

        public CuentaBancaria Delete(CuentaBancaria cuentaBancaria)
        {
            CuentaBancaria resultado;
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        resultado = cuentaBancariaRepository.Delete(cuentaBancaria);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
            }
            return resultado;
        }
    }
}