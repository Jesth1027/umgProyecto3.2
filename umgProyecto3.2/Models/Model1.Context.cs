﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class webEntities1 : DbContext
    {
        public webEntities1()
            : base("name=webEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<asign_cheque_cp> asign_cheque_cp { get; set; }
        public virtual DbSet<desposito> desposito { get; set; }
        public virtual DbSet<gest_cheque> gest_cheque { get; set; }
        public virtual DbSet<gest_cliente> gest_cliente { get; set; }
        public virtual DbSet<gest_cuenta> gest_cuenta { get; set; }
        public virtual DbSet<gest_factura> gest_factura { get; set; }
        public virtual DbSet<gest_proveedor> gest_proveedor { get; set; }
        public virtual DbSet<mov_factura_credito> mov_factura_credito { get; set; }
        public virtual DbSet<mov_factura_pagos> mov_factura_pagos { get; set; }
        public virtual DbSet<mov_trasf_cuenta> mov_trasf_cuenta { get; set; }
        public virtual DbSet<nota_debito_cc> nota_debito_cc { get; set; }
        public virtual DbSet<nota_debito_cp> nota_debito_cp { get; set; }
        public virtual DbSet<saldos> saldos { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
    
        public virtual ObjectResult<Nullable<decimal>> asignar_cheque(Nullable<int> serie, Nullable<decimal> cantidad, Nullable<System.DateTime> fecha, string pago, Nullable<int> id)
        {
            var serieParameter = serie.HasValue ?
                new ObjectParameter("serie", serie) :
                new ObjectParameter("serie", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("cantidad", cantidad) :
                new ObjectParameter("cantidad", typeof(decimal));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            var pagoParameter = pago != null ?
                new ObjectParameter("pago", pago) :
                new ObjectParameter("pago", typeof(string));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("asignar_cheque", serieParameter, cantidadParameter, fechaParameter, pagoParameter, idParameter);
        }
    
        public virtual ObjectResult<buscar_user_Result> buscar_user(string user, string pass)
        {
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<buscar_user_Result>("buscar_user", userParameter, passParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> insert_cheque(Nullable<int> serie, Nullable<System.DateTime> ingreso, string cuenta, string estado, string moneda)
        {
            var serieParameter = serie.HasValue ?
                new ObjectParameter("serie", serie) :
                new ObjectParameter("serie", typeof(int));
    
            var ingresoParameter = ingreso.HasValue ?
                new ObjectParameter("ingreso", ingreso) :
                new ObjectParameter("ingreso", typeof(System.DateTime));
    
            var cuentaParameter = cuenta != null ?
                new ObjectParameter("cuenta", cuenta) :
                new ObjectParameter("cuenta", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("estado", estado) :
                new ObjectParameter("estado", typeof(string));
    
            var monedaParameter = moneda != null ?
                new ObjectParameter("moneda", moneda) :
                new ObjectParameter("moneda", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("insert_cheque", serieParameter, ingresoParameter, cuentaParameter, estadoParameter, monedaParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> insert_cliente(string nit, string nombre, string telefono, string direccion, Nullable<int> codigo, Nullable<System.DateTime> fecha)
        {
            var nitParameter = nit != null ?
                new ObjectParameter("nit", nit) :
                new ObjectParameter("nit", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("direccion", direccion) :
                new ObjectParameter("direccion", typeof(string));
    
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(int));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("insert_cliente", nitParameter, nombreParameter, telefonoParameter, direccionParameter, codigoParameter, fechaParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> insert_cuenta(Nullable<int> correlativo, string no_cuenta, string banco, string tipo, Nullable<System.DateTime> fecha)
        {
            var correlativoParameter = correlativo.HasValue ?
                new ObjectParameter("correlativo", correlativo) :
                new ObjectParameter("correlativo", typeof(int));
    
            var no_cuentaParameter = no_cuenta != null ?
                new ObjectParameter("no_cuenta", no_cuenta) :
                new ObjectParameter("no_cuenta", typeof(string));
    
            var bancoParameter = banco != null ?
                new ObjectParameter("banco", banco) :
                new ObjectParameter("banco", typeof(string));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("tipo", tipo) :
                new ObjectParameter("tipo", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("insert_cuenta", correlativoParameter, no_cuentaParameter, bancoParameter, tipoParameter, fechaParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> insert_deposito(Nullable<int> serie, Nullable<System.DateTime> fecha, Nullable<decimal> total, string cuenta, Nullable<System.DateTime> fechasis, Nullable<int> user)
        {
            var serieParameter = serie.HasValue ?
                new ObjectParameter("serie", serie) :
                new ObjectParameter("serie", typeof(int));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            var totalParameter = total.HasValue ?
                new ObjectParameter("total", total) :
                new ObjectParameter("total", typeof(decimal));
    
            var cuentaParameter = cuenta != null ?
                new ObjectParameter("cuenta", cuenta) :
                new ObjectParameter("cuenta", typeof(string));
    
            var fechasisParameter = fechasis.HasValue ?
                new ObjectParameter("fechasis", fechasis) :
                new ObjectParameter("fechasis", typeof(System.DateTime));
    
            var userParameter = user.HasValue ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("insert_deposito", serieParameter, fechaParameter, totalParameter, cuentaParameter, fechasisParameter, userParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> insert_factura(Nullable<int> serie, string estado, Nullable<System.DateTime> fecha)
        {
            var serieParameter = serie.HasValue ?
                new ObjectParameter("serie", serie) :
                new ObjectParameter("serie", typeof(int));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("estado", estado) :
                new ObjectParameter("estado", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("insert_factura", serieParameter, estadoParameter, fechaParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> insert_proveedor(string nit, string nombre, string telefono, string direccion, Nullable<int> codigo)
        {
            var nitParameter = nit != null ?
                new ObjectParameter("nit", nit) :
                new ObjectParameter("nit", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("direccion", direccion) :
                new ObjectParameter("direccion", typeof(string));
    
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("insert_proveedor", nitParameter, nombreParameter, telefonoParameter, direccionParameter, codigoParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<Nullable<decimal>> insert_facturacp(Nullable<int> nfactura, string descripcion, Nullable<decimal> total, Nullable<int> empresa, string cancelado, Nullable<System.DateTime> fecha_factura, Nullable<System.DateTime> fecha_ingreso, Nullable<int> id)
        {
            var nfacturaParameter = nfactura.HasValue ?
                new ObjectParameter("nfactura", nfactura) :
                new ObjectParameter("nfactura", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("descripcion", descripcion) :
                new ObjectParameter("descripcion", typeof(string));
    
            var totalParameter = total.HasValue ?
                new ObjectParameter("total", total) :
                new ObjectParameter("total", typeof(decimal));
    
            var empresaParameter = empresa.HasValue ?
                new ObjectParameter("empresa", empresa) :
                new ObjectParameter("empresa", typeof(int));
    
            var canceladoParameter = cancelado != null ?
                new ObjectParameter("cancelado", cancelado) :
                new ObjectParameter("cancelado", typeof(string));
    
            var fecha_facturaParameter = fecha_factura.HasValue ?
                new ObjectParameter("fecha_factura", fecha_factura) :
                new ObjectParameter("fecha_factura", typeof(System.DateTime));
    
            var fecha_ingresoParameter = fecha_ingreso.HasValue ?
                new ObjectParameter("fecha_ingreso", fecha_ingreso) :
                new ObjectParameter("fecha_ingreso", typeof(System.DateTime));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("insert_facturacp", nfacturaParameter, descripcionParameter, totalParameter, empresaParameter, canceladoParameter, fecha_facturaParameter, fecha_ingresoParameter, idParameter);
        }
    }
}
