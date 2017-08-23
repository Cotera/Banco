using System.Linq;

namespace Banco.Repository
{
    public interface ICuentaBancariaRepository
    {
        CuentaBancaria Create(CuentaBancaria _entrada);
        IQueryable<CuentaBancaria> ReadCuentaBancaria();
        CuentaBancaria Read(long Id);
        CuentaBancaria Delete(long Id);
        void PutEntrada(CuentaBancaria cuentaBancaria);
    }
}