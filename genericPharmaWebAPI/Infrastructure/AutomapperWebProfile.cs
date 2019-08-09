using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using genericPharmaWebAPI.Models;
using genericPharmaWebAPI.ViewModels;
using AutoMapper;

namespace genericPharmaWebAPI.Infrastructure
{
    public class AutomapperWebProfile
    {
        public static void Run()
        {
            Mapper.CreateMap<Articulo, vmArticulo>()
               .ForMember(destino => destino.Id, opt => opt.MapFrom(origen => origen.ID))
               .ForMember(destino => destino.Codigo, opt => opt.MapFrom(origen => origen.Codigo))
               .ForMember(destino => destino.Nombre, opt => opt.MapFrom(origen => origen.Nombre))
               .ForMember(destino => destino.Stock, opt => opt.MapFrom(origen => origen.Stock))
               .ForMember(destino => destino.Descripcion, opt => opt.MapFrom(origen => origen.Descripcion))
               .ForMember(destino => destino.Imagen, opt => opt.MapFrom(origen => origen.Imagen))
               .ForMember(destino => destino.Vencimiento, opt => opt.MapFrom(origen => origen.Vencimiento))
               .ForMember(destino => destino.IdPaquete, opt => opt.MapFrom(origen => origen.IdPaquete))
               .ForMember(destino => destino.IdClasificacion, opt => opt.MapFrom(origen => origen.IdClasificacion));

            Mapper.CreateMap<Paquete, vmPaquete>()
                .ForMember(destino => destino.Id, opt => opt.MapFrom(origen => origen.ID))
                .ForMember(destino => destino.Descripcion, opt => opt.MapFrom(origen => origen.Descripcion))
                .ForMember(destino => destino.Activo, opt => opt.MapFrom(origen => origen.activo));

            Mapper.CreateMap<Clasificacion, vmClasificacion>()
                .ForMember(destino => destino.Id, opt => opt.MapFrom(origen => origen.ID))
                .ForMember(destino => destino.Descripcion, opt => opt.MapFrom(origen => origen.Descripcion))
                .ForMember(destino => destino.Activo, opt => opt.MapFrom(origen => origen.activo));
        }
    }
}