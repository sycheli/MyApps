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
using MyAppAPI.Models;

namespace MyAppAPI.Controllers
{
    public class PlatesController : ApiController
    {
        private MyAppAPIContext db = new MyAppAPIContext();

        // GET: api/Plates
        public IQueryable<Plate> GetPlates()
        {
            return db.Plates;
        }

        // GET: api/Plates/5
        [ResponseType(typeof(Plate))]
        public async Task<IHttpActionResult> GetPlate(int id)
        {
            Plate plate = await db.Plates.FindAsync(id);
            if (plate == null)
            {
                return NotFound();
            }

            return Ok(plate);
        }

        // PUT: api/Plates/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPlate(int id, Plate plate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plate.id)
            {
                return BadRequest();
            }

            db.Entry(plate).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlateExists(id))
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

        // POST: api/Plates
        [ResponseType(typeof(Plate))]
        public async Task<IHttpActionResult> PostPlate(Plate plate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Plates.Add(plate);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = plate.id }, plate);
        }

        // DELETE: api/Plates/5
        [ResponseType(typeof(Plate))]
        public async Task<IHttpActionResult> DeletePlate(int id)
        {
            Plate plate = await db.Plates.FindAsync(id);
            if (plate == null)
            {
                return NotFound();
            }

            db.Plates.Remove(plate);
            await db.SaveChangesAsync();

            return Ok(plate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlateExists(int id)
        {
            return db.Plates.Count(e => e.id == id) > 0;
        }
    }
}