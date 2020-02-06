using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace genericPharmaWebAPI.ViewModels
{
    public class vmProveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdPais { get; set; }
        public bool Activo { get; set; }
    }
}