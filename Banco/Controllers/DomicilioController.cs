using Banco.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Banco.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DomicilioController : ApiController
	{
		private IDomicilioService domicilioService;

		public DomicilioController()
		{

		}

		public DomicilioController(DomicilioService _domicilioService)
		{
			this.domicilioService = _domicilioService;
		}

		// POST : api/Domicilio
		[ResponseType(typeof(Domicilio))]
		public IHttpActionResult PostCreate(Domicilio domicilio)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			domicilio = domicilioService.Create(domicilio);
			return CreatedAtRoute("DefaultApi", new { id = domicilio.Id }, domicilio);
		}

		// GET : api/Domicilio/5
		[ResponseType(typeof(Domicilio))]
		public IHttpActionResult GetRead(long id)
		{
			Domicilio domicilio = domicilioService.Read(id);

			if(domicilio == null)
			{
				return NotFound();
			}

			return Ok(domicilio);
		}

		// GET : api/Domicilio
		public IQueryable<Domicilio> GetReadAll()
		{
			return domicilioService.ReadAll();
		}

		// PUT : api/Domicilio/5
		[ResponseType(typeof(void))]
		public IHttpActionResult PutUpdate(long id, Domicilio domicilio)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (id != domicilio.Id)
			{
				return BadRequest();
			}

			try
			{
				domicilioService.Update(domicilio);
			}
			catch (NoEncontradoException)
			{
				return NotFound();
			}
			return StatusCode(HttpStatusCode.NoContent);
		}

		// DELETE : api/Domicilio/5
		[ResponseType(typeof(Domicilio))]
		public IHttpActionResult Delete(long id)
		{
			try
			{
				return Ok( domicilioService.Delete(id) );
			}
			catch (NoEncontradoException)
			{
				return NotFound();
			}
		}

	}
}