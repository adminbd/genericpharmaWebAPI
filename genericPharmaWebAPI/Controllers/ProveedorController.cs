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
    public class ProveedorController : ApiController
    {
        // GET: api/Proveedor
        public IHttpActionResult Get()
        {
            List<vmProveedor> proveedores = new List<vmProveedor>();
            using (PharmaEntities db = new PharmaEntities())
            {
                var lst = db.Proveedor.Where(x => x.activo == true).ToList();
                Mapper.Map(lst, proveedores);
                return Ok(proveedores);
            }
        }

        // GET: api/Proveedor/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Proveedor
        public IHttpActionResult Post([FromBody]vmProveedor proveedor)
        {
            try
            {
                if (proveedor != null)
                {
                    using (PharmaEntities db = new PharmaEntities())
                    {
                        var oProveedor = new Proveedor()
                        {
                            ID = proveedor.Id,
                            Nombre = proveedor.Nombre,
                            Direccion = proveedor.Direccion,
                            Telefono = proveedor.Telefono,
                            IdPais = proveedor.IdPais,
                            activo = proveedor.Activo,
                        };
                        db.Proveedor.Add(oProveedor);
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
                        message = "La informacion del proveedor es erronea"
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

        // PUT: api/Proveedor/5
        public IHttpActionResult Put(int id, [FromBody]vmProveedor proveedor)
        {
            try
            {
                using (PharmaEntities db = new PharmaEntities())
                {
                    var edProveedor = db.Proveedor.Find(id);
                    if (edProveedor != null)
                    {
                        edProveedor.Nombre = proveedor.Nombre;
                        edProveedor.Direccion = proveedor.Direccion;
                        edProveedor.Telefono = proveedor.Telefono;
                        edProveedor.IdPais = proveedor.IdPais;

                        db.Entry(edProveedor).State = EntityState.Modified;
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
                            message = "No existe el proveedor"
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

        // DELETE: api/Proveedor/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (PharmaEntities db = new PharmaEntities())
                {
                    // verificar si este proveedor esta ligado a uno o varios articulos
                    var provExistente = db.Articulo.Where(x => x.IdProveedor == id).FirstOrDefault();
                    if (provExistente == null)
                    {
                        var rmProveedor = db.Proveedor.Find(id);
                        if (rmProveedor != null)
                        {
                            rmProveedor.activo = false;
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
                                message = "No existe el proveedor"
                            });
                        }
                    }
                    else
                    {
                        return Ok(new
                        {
                            status = "error",
                            message = "Error. Este proveedor esta ligado a uno o varios articulos"
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
