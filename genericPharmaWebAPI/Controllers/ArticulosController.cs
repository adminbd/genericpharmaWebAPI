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
    public class ArticulosController : ApiController
    {

        // GET: api/Articulos
        public IHttpActionResult Get()
        {
            List<vmArticulo> articulos = new List<vmArticulo>();
            using (PharmaEntities db = new PharmaEntities())
            {
                var lst = db.Articulo.ToList();

                Mapper.Map(lst, articulos);
                return Ok(articulos);
            }
        }

        // POST: api/Articulos
        public IHttpActionResult Post([FromBody]vmArticulo articulo)
        {
            try
            {
                if (articulo != null)
                {
                    using (PharmaEntities db = new PharmaEntities())
                    {
                        var oArticulo = new Articulo()
                        {
                            ID = articulo.Id,
                            Codigo = articulo.Codigo,
                            Nombre = articulo.Nombre,
                            Stock = articulo.Stock,
                            Descripcion = articulo.Descripcion,
                            Imagen = articulo.Imagen,
                            Vencimiento = articulo.Vencimiento,
                            IdPaquete = articulo.IdPaquete,
                            IdClasificacion = articulo.IdClasificacion
                        };
                        db.Articulo.Add(oArticulo);
                        db.SaveChanges();

                    }
                    return Ok("success");
                }
                else
                {
                    return Ok("incomplete");
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return Ok("error");
                throw;
            }

        }

        // PUT: api/Articulos/5
        public void Put(int id, [FromBody]vmArticulo articulo)
        {
            using (PharmaEntities db = new PharmaEntities())
            {
                var edtArticulo = db.Articulo.Find(id);
                edtArticulo.Codigo = articulo.Codigo;
                edtArticulo.Nombre = articulo.Nombre;
                edtArticulo.Stock = articulo.Stock;
                edtArticulo.Descripcion = articulo.Descripcion;
                edtArticulo.Imagen = articulo.Imagen;
                edtArticulo.Vencimiento = articulo.Vencimiento;
                edtArticulo.IdPaquete = articulo.IdPaquete;
                edtArticulo.IdClasificacion = articulo.IdClasificacion;

                db.Entry(edtArticulo).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        // DELETE: api/Articulos/5
        public void Delete(int id)
        {
            using (PharmaEntities db = new PharmaEntities())
            {
                var rmArticulo = db.Articulo.Find(id);
                db.Articulo.Remove(rmArticulo);
                db.SaveChanges();
            }
        }
    }
}
