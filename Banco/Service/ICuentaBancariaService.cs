using System.Linq;

namespace Banco.Service
{
    public interface ICuentaBancariaService
    {
        CuentaBancaria Create(CuentaBancaria cuentaBancaria);
        IQueryable<CuentaBancaria> ReadCuentaBancarias();
        CuentaBancaria GetCuentaBancaria(long Id);
        void PutCuentaBancaria(CuentaBancaria cuentaBancaria);
        CuentaBancaria Delete(CuentaBancaria cuentaBancaria);
    }
}