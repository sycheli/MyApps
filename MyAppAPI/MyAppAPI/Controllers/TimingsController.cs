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
    public class TimingsController : ApiController
    {
        private MyAppAPIContext db = new MyAppAPIContext();

        // GET: api/Timings
        public IQueryable<Timing> GetTimings()
        {
            return db.Timings;
        }

        // GET: api/Timings/5
        [ResponseType(typeof(Timing))]
        public async Task<IHttpActionResult> GetTiming(int id)
        {
            Timing timing = await db.Timings.FindAsync(id);
            if (timing == null)
            {
                return NotFound();
            }

            return Ok(timing);
        }

        // PUT: api/Timings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTiming(int id, Timing timing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timing.id)
            {
                return BadRequest();
            }

            db.Entry(timing).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimingExists(id))
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

        // POST: api/Timings
        [ResponseType(typeof(Timing))]
        public async Task<IHttpActionResult> PostTiming(Timing timing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Timings.Add(timing);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TimingExists(timing.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = timing.id }, timing);
        }

        // DELETE: api/Timings/5
        [ResponseType(typeof(Timing))]
        public async Task<IHttpActionResult> DeleteTiming(int id)
        {
            Timing timing = await db.Timings.FindAsync(id);
            if (timing == null)
            {
                return NotFound();
            }

            db.Timings.Remove(timing);
            await db.SaveChangesAsync();

            return Ok(timing);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimingExists(int id)
        {
            return db.Timings.Count(e => e.id == id) > 0;
        }
    }
}