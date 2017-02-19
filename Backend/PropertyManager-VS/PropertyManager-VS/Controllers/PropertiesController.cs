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
using PropertyManager_VS.Infrastructure;
using PropertyManager_VS.Models;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace PropertyManager_VS.Controllers
{
    public class PropertiesController : ApiController
    {
        private PropertyDataContext db = new PropertyDataContext();

        // GET: api/Properties
        public IQueryable<Property> GetProperties()
        {
            return db.Properties;
        }

        //GET: api/Properties/Search  (Search using one or more property fields)
        [Route("api/Properties/GetSearchProperties")]
        public IQueryable<Property> GetSearchProperties([FromUri] UserPropertySearch search)
        {

            //UserPropertySearch search = JsonConvert.DeserializeObject<UserPropertySearch>(initialSearch);

            IQueryable<Property> finalProperties = db.Properties;

            if(search.UserName != null)
            {
                finalProperties = GetPropsByUsername(search.UserName);
            }

            if(search.City != null)
            {
                finalProperties = finalProperties.Where(p => p.City == search.City);
            }

            if(search.Zip != null)
            {
                finalProperties = finalProperties.Where(p => p.Zip == search.Zip);
            }

            if(search.MinRent > 0 && search.MaxRent > 0)
            {
                finalProperties = finalProperties.Where(p => p.Rent >= search.MinRent && p.Rent <= search.MaxRent);
            }

            if (search.Bedrooms > 0)
            {
                finalProperties = finalProperties.Where(p => p.Bedrooms == search.Bedrooms);
            }

            if (search.Bathrooms > 0)
            {
                finalProperties = finalProperties.Where(p => p.Bathrooms == search.Bathrooms);
            }


            return finalProperties;
        }

        //GET: api/Properties/SearchUserName
        [Route("api/Properties/GetPropsByUsername")]
        [HttpGet]
        public IQueryable<Property> GetPropsByUsername(string username)
        {
            var searchedUser = db.Users.FirstOrDefault(u => u.UserName == username);

            var properties = db.Properties.Where(p => p.UserId == searchedUser.UserId);

            return properties;
            
        }

        // GET: api/Properties/5
        [ResponseType(typeof(Property))]
        public IHttpActionResult GetProperty(int id)
        {
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }

        // PUT: api/Properties/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProperty(int id, Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != property.PropertyId)
            {
                return BadRequest();
            }

            db.Entry(property).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
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

        // POST: api/Properties
        [ResponseType(typeof(Property))]
        public IHttpActionResult PostProperty(Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Properties.Add(property);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = property.PropertyId }, property);
        }

        // DELETE: api/Properties/5
        [ResponseType(typeof(Property))]
        public IHttpActionResult DeleteProperty(int id)
        {
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return NotFound();
            }

            db.Properties.Remove(property);
            db.SaveChanges();

            return Ok(property);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropertyExists(int id)
        {
            return db.Properties.Count(e => e.PropertyId == id) > 0;
        }
    }
}