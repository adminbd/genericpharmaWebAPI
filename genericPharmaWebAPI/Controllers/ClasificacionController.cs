using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using genericPharmaWebAPI.Models;
using genericPharmaWebAPI.ViewModels;
using AutoMapper;

namespace genericPharmaWebAPI.Controllers
{
    public class ClasificacionController : ApiController
    {
        // GET: api/Clasificacion
        public IHttpActionResult Get()
        {
            List<vmClasificacion> clasificacion = new List<vmClasificacion>();
            using (PharmaEntities db = new PharmaEntities())
            {
                var lst = db.Clasificacion.ToList();
                Mapper.Map(lst, clasificacion);
                return Ok(clasificacion);
            }
        }

        // GET: api/Clasificacion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Clasificacion
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clasificacion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clasificacion/5
        public void Delete(int id)
        {
        }
    }
}
