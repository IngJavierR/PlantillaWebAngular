using System;
using System.Text;
using System.Collections.Generic;


namespace HyHWebPage.Db.Hyhweb.Entities {
    
    public class Pedidos {
        public Pedidos() { }
        public virtual string Id { get; set; }
        public virtual PedidosEstadoCt PedidosEstadoCt { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        public virtual DateTime FechaGeneracion { get; set; }
        public virtual DateTime FechaARecibir { get; set; }
        public virtual string Subtotal { get; set; }
        public virtual string Iva { get; set; }
        public virtual int Estatus { get; set; }
        public virtual string ReferenciaImas { get; set; }
    }
}
