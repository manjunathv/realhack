using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Housing.Controllers
{
    public class LocalityController : ApiController
    {
        private ankurEntities db = new ankurEntities();

        // GET api/Locality
        public IEnumerable<Locality> GetLocalities()
        {
            var locality = db.Locality.Include(l => l.City);
            return locality.AsEnumerable();
        }

        // GET api/Locality/5
        public List<Locality> GetLocality(int id)
        {
            var ll = db.Locality.Where(l => l.CityId == id);

            return ll.ToList();
        }

        // PUT api/Locality/5
        public HttpResponseMessage PutLocality(int id, Locality locality)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != locality.LocalityId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(locality).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Locality
        public HttpResponseMessage PostLocality(Locality locality)
        {
            if (ModelState.IsValid)
            {
                db.Locality.Add(locality);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, locality);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = locality.LocalityId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Locality/5
        public HttpResponseMessage DeleteLocality(int id)
        {
            Locality locality = db.Locality.Find(id);
            if (locality == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Locality.Remove(locality);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, locality);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}