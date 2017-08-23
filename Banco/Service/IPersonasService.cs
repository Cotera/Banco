using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Service
{
    public interface IPersonasService
    {
        Persona Create(Persona persona);
        Persona Delete(long id);
        Persona GetPersona(long id);
        void PutPersona(Persona persona);
        IQueryable<Persona> ReadPersonas();
    }
}
