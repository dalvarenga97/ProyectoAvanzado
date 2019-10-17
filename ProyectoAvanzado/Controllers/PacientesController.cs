using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProyectoAvanzado.Models;

namespace ProyectoAvanzado.Controllers
{
    public class PacientesController : ApiController
    {
        private MediCsharp2Entities db = new MediCsharp2Entities();

        // GET: api/Pacientes
        public IQueryable<Paciente> GetPaciente()
        {
            return db.Paciente;
        }

        // GET: api/Pacientes/5
        [ResponseType(typeof(Paciente))]
        public async Task<IHttpActionResult> GetPaciente(int id)
        {
            Paciente paciente = await db.Paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }

        // PUT: api/Pacientes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPaciente(int id, Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paciente.Id)
            {
                return BadRequest();
            }

            db.Entry(paciente).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
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

        // POST: api/Pacientes
        [ResponseType(typeof(Paciente))]
        public async Task<IHttpActionResult> PostPaciente(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Paciente.Add(paciente);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = paciente.Id }, paciente);
        }

        // DELETE: api/Pacientes/5
        [ResponseType(typeof(Paciente))]
        public async Task<IHttpActionResult> DeletePaciente(int id)
        {
            Paciente paciente = await db.Paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            db.Paciente.Remove(paciente);
            await db.SaveChangesAsync();

            return Ok(paciente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PacienteExists(int id)
        {
            return db.Paciente.Count(e => e.Id == id) > 0;
        }
    }
}