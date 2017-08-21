using System.Linq;

namespace Banco.Services
{
    public interface IPersonasService
    {
        Persona Create(Persona persona);
        Persona Delete(Persona persona);
        Persona GetPersona(long id);
        void PutPersona(Persona persona);
        IQueryable<Persona> ReadPersonas();
    }
}