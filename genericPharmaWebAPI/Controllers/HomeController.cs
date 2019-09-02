using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using genericPharmaWebAPI.Models;
using genericPharmaWebAPI.ViewModels;
using AutoMapper;

namespace genericPharmaWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            List<vmArticulo> articulos = new List<vmArticulo>();
            using (PharmaEntities db = new PharmaEntities())
            {
                var lst = db.Articulo.ToList();
                Mapper.Map(lst, articulos);
                return View(articulos);
            }
        }
    }
}
