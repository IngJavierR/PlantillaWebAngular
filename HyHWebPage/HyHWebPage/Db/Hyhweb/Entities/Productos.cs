using System;
using System.Text;
using System.Collections.Generic;


namespace HyHWebPage.Db.Hyhweb.Entities {
    
    public class Productos {
        public Productos() { }
        public virtual int Id { get; set; }
        public virtual ProductosEstadoCt ProductosEstadoCt { get; set; }
        public virtual string ClaveProducto { get; set; }
        public virtual string NombreWeb { get; set; }
        public virtual string NombreImas { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual byte[] Imagen { get; set; }
    }
}
