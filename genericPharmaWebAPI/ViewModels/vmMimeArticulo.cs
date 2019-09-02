using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace genericPharmaWebAPI.ViewModels
{
    public class vmMimeArticulo
    {
        public vmArticulo articulo { get; set; }
        public HttpPostedFileBase imagen { get; set; }
    }
}