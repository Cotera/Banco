using System.Linq;

namespace Banco.Repository
{
    public interface ICuentaBancariaRepository
    {
        CuentaBancaria Create(CuentaBancaria _entrada);
        IQueryable<CuentaBancaria> ReadCuentaBancaria();
        CuentaBancaria Read(string no);
        CuentaBancaria Delete(CuentaBancaria cuentaBancaria);
        void PutEntrada(CuentaBancaria cuentaBancaria);
    }
}