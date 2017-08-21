using Banco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banco.Repository
{
    public class PersonasRepository : IPersonasRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Persona Create(Persona _entrada)
        {
            throw new NotImplementedException();
        }

        public Persona Delete(Persona persona)
        {
            throw new NotImplementedException();
        }

        public void PutEntrada(Persona persona)
        {
            throw new NotImplementedException();
        }

        public Persona Read(long id)
        {
            return db.Personas.Find(id);
        }

        public IQueryable<Persona> ReadPersonas()
        {
            return ApplicationDbContext.applica.Personas;
        }
    }
}