//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace umgProyecto3._2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class mov_factura_credito
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mov_factura_credito()
        {
            this.nota_debito_cc = new HashSet<nota_debito_cc>();
        }
    
        public int correlativo { get; set; }
        public int serie { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<int> id_cliente { get; set; }
        public string cancelado { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> id_user { get; set; }
    
        public virtual gest_factura gest_factura { get; set; }
        public virtual usuario usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nota_debito_cc> nota_debito_cc { get; set; }
    }
}
