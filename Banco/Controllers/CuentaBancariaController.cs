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

namespace Banco.Controllers
{
    public class CuentaBancariaController : ApiController
    {
        private ICuentaBancariaService CuentaBancariaService;
        public CuentaBancariaController(ICuentaBancariaService _CuentaBancariaService)
        {
            this.CuentaBancariaService = _CuentaBancariaService;
        }
        // GET: api/CuentaBancaria
        public IQueryable<CuentaBancaria> GetCuentaBancarias()
        {
            return this.CuentaBancariaService.ReadCuentaBancarias();
        }

        // GET: api/CuentaBancaria/5
        [ResponseType(typeof(CuentaBancaria))]
        public IHttpActionResult GetCuentaBancaria(string no)
        {
            CuentaBancaria cuentaBancaria = this.CuentaBancariaService.GetCuentaBancaria(no);
            if (cuentaBancaria == null)
            {
                return NotFound();
            }

            return Ok(cuentaBancaria);
        }

        // PUT: api/CuentaBancaria/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCuentaBancaria(String no, CuentaBancaria cuentaBancaria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (no != cuentaBancaria.No)
            {
                return BadRequest();
            }


            try
            {
                this.CuentaBancariaService.PutCuentaBancaria(cuentaBancaria);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this.CuentaBancariaService.GetCuentaBancaria(no)==null)
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

            this.CuentaBancariaService.PutCuentaBancaria(cuentaBancaria);

            return CreatedAtRoute("DefaultApi", new { id = cuentaBancaria.No }, cuentaBancaria);
        }

        // DELETE: api/CuentaBancaria/5
        [ResponseType(typeof(CuentaBancaria))]
        public IHttpActionResult DeleteCuentaBancaria(string no)
        {
            CuentaBancaria cuentaBancaria = this.CuentaBancariaService.GetCuentaBancaria(no);
            if (cuentaBancaria == null)
            {
                return NotFound();
            }

            this.CuentaBancariaService.Delete(cuentaBancaria);

            return Ok(cuentaBancaria);
        }

       
    }
}