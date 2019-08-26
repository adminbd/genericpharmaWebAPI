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
using System.Web.Http.Cors;

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
                throw e;
            }

        }

        // PUT: api/Articulos/5
        public IHttpActionResult Put(int id, [FromBody]vmArticulo articulo)
        {
            try
            {
                using (PharmaEntities db = new PharmaEntities())
                {
                    var edtArticulo = db.Articulo.Find(id);
                    if (edtArticulo != null)
                    {
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
                        return Ok("success");
                    }
                    else
                    {
                        return Ok("incomplete");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok("error");
                throw ex;
            }
        }

        [HttpDelete]
        [HttpOptions]
        // DELETE: api/Articulos/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (PharmaEntities db = new PharmaEntities())
                {
                    var rmArticulo = db.Articulo.Find(id);
                    if (rmArticulo != null)
                    {
                        db.Articulo.Remove(rmArticulo);
                        db.SaveChanges();
                        return Ok("success");
                    }
                    else
                    {
                        return Ok("incomplete");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Ok("Error");
                throw e;
            }
        }
    }
}
