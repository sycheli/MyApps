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
    public class PointsController : ApiController
    {
        private MyAppAPIContext db = new MyAppAPIContext();

        // GET: api/Points
        public IQueryable<Point> GetPoints()
        {
            return db.Points;
        }

        // GET: api/Points/5
        [ResponseType(typeof(Point))]
        public async Task<IHttpActionResult> GetPoint(int id)
        {
            Point point = await db.Points.FindAsync(id);
            if (point == null)
            {
                return NotFound();
            }

            return Ok(point);
        }

        // PUT: api/Points/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPoint(int id, Point point)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != point.id)
            {
                return BadRequest();
            }

            db.Entry(point).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointExists(id))
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

        // POST: api/Points
        [ResponseType(typeof(Point))]
        public async Task<IHttpActionResult> PostPoint(Point point)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Points.Add(point);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = point.id }, point);
        }

        // DELETE: api/Points/5
        [ResponseType(typeof(Point))]
        public async Task<IHttpActionResult> DeletePoint(int id)
        {
            Point point = await db.Points.FindAsync(id);
            if (point == null)
            {
                return NotFound();
            }

            db.Points.Remove(point);
            await db.SaveChangesAsync();

            return Ok(point);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PointExists(int id)
        {
            return db.Points.Count(e => e.id == id) > 0;
        }
    }
}