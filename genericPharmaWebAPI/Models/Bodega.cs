//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace genericPharmaWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bodega
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bodega()
        {
            this.Empleado = new HashSet<Empleado>();
            this.Traslado = new HashSet<Traslado>();
        }
    
        public int ID { get; set; }
        public string Nombre_Bodega { get; set; }
        public string Ubicacion { get; set; }
        public int IdTipo_Bodega { get; set; }
        public bool activo { get; set; }
    
        public virtual Tipo_Bodega Tipo_Bodega { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empleado> Empleado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Traslado> Traslado { get; set; }
    }
}
