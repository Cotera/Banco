using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Repository
{
    public interface IPersonasRepository
    {
        Persona Create(Persona _entrada);
        Persona Delete(Persona persona);
        void PutEntrada(Persona persona);
        Persona Read(long id);
        IQueryable<Persona> ReadPersonas();
    }
}
