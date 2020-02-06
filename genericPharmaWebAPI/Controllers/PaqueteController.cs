using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using genericPharmaWebAPI.ViewModels;
using genericPharmaWebAPI.Models;
using System.Data.Entity;
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
                var lst = db.Paquete.Where(x => x.activo == true).ToList();
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
        public IHttpActionResult Post([FromBody]vmPaquete paquete)
        {
            try
            {
                if (paquete != null)
                {
                    using (PharmaEntities db = new PharmaEntities())
                    {
                        var oPaquete = new Paquete()
                        {
                            Descripcion = paquete.Descripcion,
                            activo = paquete.Activo,
                        };
                        db.Paquete.Add(oPaquete);
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
                        message = "La informacion del paquete es erronea"
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

        // PUT: api/Paquete/5
        public IHttpActionResult Put(int id, [FromBody]vmPaquete paquete)
        {
            try
            {
                using (PharmaEntities db = new PharmaEntities())
                {
                    var edPaquete = db.Paquete.Find(id);
                    if (edPaquete != null)
                    {
                        edPaquete.Descripcion = paquete.Descripcion;

                        db.Entry(edPaquete).State = EntityState.Modified;
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
                            message = "No existe el paquete"
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

        // DELETE: api/Paquete/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (PharmaEntities db = new PharmaEntities())
                {
                    // verificar si esta clasificacion esta ligada a uno o varios articulos
                    var pkgExistente = db.Articulo.Where(x => x.IdPaquete == id).FirstOrDefault();
                    if (pkgExistente == null)
                    {
                        var rmPaquete = db.Paquete.Find(id);
                        if (rmPaquete != null)
                        {
                            rmPaquete.activo = false;
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
                                message = "No existe el paquete"
                            });
                        }
                    }
                    else
                    {
                        return Ok(new
                        {
                            status = "error",
                            message = "Error. Este paquete esta ligado a uno o varios articulos"
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
