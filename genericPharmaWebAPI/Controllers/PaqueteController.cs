using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using genericPharmaWebAPI.ViewModels;
using genericPharmaWebAPI.Models;
using AutoMapper;

namespace genericPharmaWebAPI.Controllers
{
    public class PaqueteController : ApiController
    {
        // GET: api/Paquete
        public IHttpActionResult Get()
        {
            List<vmPaquete> paquetes = new List<vmPaquete>();
            using (PharmaEntities db = new PharmaEntities())
            {
                var lst = db.Paquete.ToList();
                Mapper.Map(lst, paquetes);
                return Ok(paquetes);
            }
        }

        // GET: api/Paquete/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Paquete
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Paquete/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Paquete/5
        public void Delete(int id)
        {
        }
    }
}
