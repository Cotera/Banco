using Banco.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Banco.Controllers
{
	public class DomicilioController : ApiController
	{
		private IDomicilioService domicilioService;

		public DomicilioController(DomicilioService _domicilioService)
		{
			this.domicilioService = _domicilioService;
		}

		// POST : api/Domicilio
		[ResponseType(typeof(Domicilio))]
		public IHttpActionResult Create(Domicilio _domicilio)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_domicilio = domicilioService.Create(_domicilio);
			return CreatedAtRoute("DefaultApi", new { id = _domicilio.Id }, _domicilio);
		}

		// GET : api/Domicilio/5
		[ResponseType(typeof(Domicilio))]
		public IHttpActionResult Read(long _id)
		{
			Domicilio domicilio = domicilioService.Read(_id);

			if(domicilio == null)
			{
				return NotFound();
			}

			return Ok(domicilio);
		}

		// GET : api/Domicilio
		public IQueryable<Domicilio> ReadAll()
		{
			return domicilioService.ReadAll();
		}

		// PUT : api/Domicilio
		[ResponseType(typeof(void))]
		public IHttpActionResult Update(long _id, Domicilio _domicilio)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (_id != _domicilio.Id)
			{
				return BadRequest();
			}

			try
			{
				domicilioService.Update(_domicilio);
			}
			catch (NoEncontradoException)
			{
				return NotFound();
			}
			return StatusCode(HttpStatusCode.NoContent);
		}

		// DELETE : api/Domicilio/5
		[ResponseType(typeof(Domicilio))]
		public IHttpActionResult Delete(long _id)
		{
			try
			{
				return Ok( domicilioService.Delete(_id) );
			}
			catch (NoEncontradoException)
			{
				return NotFound();
			}
		}

	}
}