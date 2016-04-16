using System;
using System.Text;
using System.Collections.Generic;


namespace HyHWebPage.Db.Hyhweb.Entities {
    
    public class UsuariosTipoCt {
        public UsuariosTipoCt() { }
        public virtual int Id { get; set; }
        public virtual string TipoUsuario { get; set; }
        public virtual string Descripcion { get; set; }
    }
}
