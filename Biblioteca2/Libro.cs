//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Biblioteca2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Libro
    {
        public int lib_id { get; set; }
        public string lib_nombre { get; set; }
        public Nullable<double> lib_precio { get; set; }
        public string lib_isbn { get; set; }
        public Nullable<int> suc_id { get; set; }
    
        public virtual Sucursal Sucursal { get; set; }
    }
}
