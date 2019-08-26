using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using genericPharmaWebAPI.Models;
using genericPharmaWebAPI.ViewModels;
using AutoMapper;
using System.Data.Entity;

namespace genericPharmaWebAPI.Controllers
{
    public class PaisController : ApiController
    {
        // GET: api/Pais
        public IHttpActionResult Get()
        {
            List<vmPais> paises = new List<vmPais>();
            using (PharmaEntities db = new PharmaEntities())
            {
                var lst = db.Pais.ToList();
                Mapper.Map(lst, paises);
                return Ok(paises);
            }
        }

        // GET: api/Pais/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pais
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Pais/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pais/5
        public void Delete(int id)
        {
        }
    }
}
