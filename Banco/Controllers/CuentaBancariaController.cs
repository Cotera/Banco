using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Banco;
using Banco.Models;
using Banco.Service;
using System.Web.Http.Cors;

namespace Banco.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CuentaBancariaController : ApiController
    {
        private ICuentaBancariaService CuentaBancariaService;
        public CuentaBancariaController(ICuentaBancariaService _CuentaBancariaService)
        {
            this.CuentaBancariaService = _CuentaBancariaService;
        }
        // GET: api/CuentaBancaria
        public IQueryable<CuentaBancaria> GetCuentaBancaria()
        {
            return this.CuentaBancariaService.ReadCuentaBancarias();
        }

        // GET: api/CuentaBancaria/5
        [ResponseType(typeof(CuentaBancaria))]
        public IHttpActionResult GetCuentaBancaria(long Id)
        {
            CuentaBancaria cuentaBancaria = this.CuentaBancariaService.GetCuentaBancaria(Id);
            if (cuentaBancaria == null)
            {
                return NotFound();
            }

            return Ok(cuentaBancaria);
        }

        // PUT: api/CuentaBancaria/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCuentaBancaria(long Id, CuentaBancaria cuentaBancaria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (Id != cuentaBancaria.Id)
            {
                return BadRequest();
            }


            try
            {
                this.CuentaBancariaService.PutCuentaBancaria(cuentaBancaria);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this.CuentaBancariaService.GetCuentaBancaria(Id)==null)
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

        // POST: api/CuentaBancaria
        [ResponseType(typeof(CuentaBancaria))]
        public IHttpActionResult PostCuentaBancaria(CuentaBancaria cuentaBancaria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.CuentaBancariaService.Create(cuentaBancaria);

            return CreatedAtRoute("DefaultApi", new { id = cuentaBancaria.Id }, cuentaBancaria);
        }

        // DELETE: api/CuentaBancaria/5
        [ResponseType(typeof(CuentaBancaria))]
        public IHttpActionResult DeleteCuentaBancaria(long Id)
        {
            CuentaBancaria cuentaBancaria = this.CuentaBancariaService.GetCuentaBancaria(Id);
            if (cuentaBancaria == null)
            {
                return NotFound();
            }

            this.CuentaBancariaService.Delete(Id);

            return Ok(cuentaBancaria);
        }

       
    }
}