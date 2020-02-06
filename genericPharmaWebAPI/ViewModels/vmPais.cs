using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace genericPharmaWebAPI.ViewModels
{
    public class vmPais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Provincia { get; set; }
        public bool Activo { get; set; }
    }
}