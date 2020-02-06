using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using genericPharmaWebAPI.Models;
using genericPharmaWebAPI.ViewModels;
using System.Data.Entity;
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
                var lst = db.Clasificacion.Where(x => x.activo == true).ToList();
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
        public IHttpActionResult Post([FromBody]vmClasificacion clasificacion)
        {
            try
            {
                if (clasificacion != null)
                {
                    using (PharmaEntities db = new PharmaEntities())
                    {
                        var oClasificacion = new Clasificacion()
                        {
                            Descripcion = clasificacion.Descripcion,
                            activo = clasificacion.Activo,
                        };
                        db.Clasificacion.Add(oClasificacion);
                        db.SaveChanges();
                        return Ok(new
                        {
                            status = "success",
                            message = "Guardado de manera exitosa."
                        });
                    }
                }
                else
                {
                    return Ok(new
                    {
                        status = "error",
                        message = "La informacion de la clasificacion es erronea"
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok(new
                {
                    status = "error",
                    message = "Ha ocurrido un error: " + ex.Message
                });
                throw ex;
            }

        }

        // PUT: api/Clasificacion/5
        public IHttpActionResult Put(int id, [FromBody]vmClasificacion clasificacion)
        {
            try
            {
                using (PharmaEntities db = new PharmaEntities())
                {
                    var edClasificacion = db.Clasificacion.Find(id);
                    if (edClasificacion != null)
                    {
                        edClasificacion.Descripcion = clasificacion.Descripcion;

                        db.Entry(edClasificacion).State = EntityState.Modified;
                        db.SaveChanges();
                        return Ok(new
                        {
                            status = "success",
                            message = "Registro editado de manera exitosa."
                        });
                    }
                    else
                    {
                        return Ok(new
                        {
                            status = "error",
                            message = "No existe la clasificacion"
                        });
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok(new
                {
                    status = "error",
                    message = "Ha ocurrido un error: " + ex.Message
                });
                throw;
            }
        }

        // DELETE: api/Clasificacion/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (PharmaEntities db = new PharmaEntities())
                {
                    // verificar si esta clasificacion esta ligada a uno o varios articulos
                    var clasExistente = db.Articulo.Where(x => x.IdClasificacion == id).FirstOrDefault();
                    if (clasExistente == null)
                    {
                        var rmClasificacion = db.Clasificacion.Find(id);
                        if (rmClasificacion != null)
                        {
                            rmClasificacion.activo = false;
                            db.SaveChanges();
                            return Ok(new
                            {
                                status = "success",
                                message = "Registro eliminado de manera exitosa."
                            });
                        }
                        else
                        {
                            return Ok(new
                            {
                                status = "error",
                                message = "No existe la clasificacion"
                            });
                        }
                    }
                    else
                    {
                        return Ok(new
                        {
                            status = "error",
                            message = "Error. Esta clasificacion esta ligada a uno o varios articulos"
                        });
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok(new
                {
                    status = "error",
                    message = "Ha ocurrido un error: " + ex.Message
                });
                throw;
            }

        }
    }
}
