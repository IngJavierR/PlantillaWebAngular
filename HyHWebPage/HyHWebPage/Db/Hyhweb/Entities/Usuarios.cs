using System;
using System.Text;
using System.Collections.Generic;


namespace HyHWebPage.Db.Hyhweb.Entities {
    
    public class Usuarios {
        public Usuarios() { }
        public virtual string Id { get; set; }
        public virtual UsuariosTipoCt UsuariosTipoCt { get; set; }
        public virtual UsuariosEstadoCt UsuariosEstadoCt { get; set; }
        public virtual string NombreUsuario { get; set; }
        public virtual string Contrasea { get; set; }
        public virtual string Correo { get; set; }
        public virtual byte[] Logo { get; set; }
        public virtual string ClaveCliente { get; set; }
        public virtual string UnidadEntrega { get; set; }
        public virtual DateTime UltimaConexion { get; set; }
    }
}
