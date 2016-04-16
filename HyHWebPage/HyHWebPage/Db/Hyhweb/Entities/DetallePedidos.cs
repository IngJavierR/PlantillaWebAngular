using System;
using System.Text;
using System.Collections.Generic;


namespace HyHWebPage.Db.Hyhweb.Entities {
    
    public class DetallePedidos {
        public virtual string IdPedidos { get; set; }
        public virtual int Partida { get; set; }
        public virtual Productos Productos { get; set; }
        public virtual string Cantidad { get; set; }
        public virtual string Gramaje { get; set; }
        public virtual string Piezas { get; set; }
        public virtual string Precio { get; set; }
        public virtual string Observaciones { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as DetallePedidos;
			if (t == null) return false;
			if (IdPedidos == t.IdPedidos
			 && Partida == t.Partida)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ IdPedidos.GetHashCode();
			hash = (hash * 397) ^ Partida.GetHashCode();

			return hash;
        }
        #endregion
    }
}
