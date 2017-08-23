using Banco.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Banco.Repository
{
    public class PersonasRepository : IPersonasRepository
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        public Persona Create(Persona _entrada)
        {
            return ApplicationDbContext.applicationDbContext.Personas.Add(_entrada);
        }

        public Persona Delete(long id)
        {
            Persona persona = this.Read(id);
            if(persona == null)
            {
                throw new NoEncontradoException("No se ha encontrado la persona  a eliminar");
            }
            return ApplicationDbContext.applicationDbContext.Personas.Remove(persona);

        }

        public void PutEntrada(Persona persona)
        {
            ApplicationDbContext.applicationDbContext.Entry(persona).State = EntityState.Modified;
        }

        public Persona Read(long id)
        {
            return ApplicationDbContext.applicationDbContext.Personas.Find(id);
        }

        public IQueryable<Persona> ReadPersonas()
        {
            IList<Persona> lista = new List<Persona>(ApplicationDbContext.applicationDbContext.Personas);
            return lista.AsQueryable();
        }
    }
}