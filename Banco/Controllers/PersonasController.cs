using Banco.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Banco.Controllers
{
    public class PersonasController : ApiController
    {
        private IPersonasService PersonasService;
        public PersonasController(IPersonasService _PersonasService)
        {
            this.PersonasService = _PersonasService;
        }
        // GET: api/Personas
        public IQueryable<Persona> GetPersonas()
        {
            return this.PersonasService.ReadPersonas();
        }

        // GET: api/Personas/5
        [ResponseType(typeof(Persona))]
        public IHttpActionResult GetPersona(long id)
        {
            Persona persona = this.PersonasService.GetPersona(id);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // PUT: api/Personas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersona(long id, Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persona.Id)
            {
                return BadRequest();
            }


            try
            {
                this.PersonasService.PutPersona(persona);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this.PersonasService.GetPersona(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Personas
        [ResponseType(typeof(Persona))]
        public IHttpActionResult PostPersona(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            persona = this.PersonasService.Create(persona);

            return CreatedAtRoute("DefaultApi", new { id = persona.Id }, persona);
        }

        // DELETE: api/Personas/5
        [ResponseType(typeof(Persona))]
        public IHttpActionResult DeletePersona(long id)
        {
            Persona persona = this.PersonasService.GetPersona(id);
            if (persona == null)
            {
                return NotFound();
            }

            this.PersonasService.Delete(persona);
            return Ok(persona);

        }

        
    }
}