using System;
using System.Text;
using System.Collections.Generic;


namespace HyHWebPage.Db.Imas.Entities {
    
    public class NmLis {
        public virtual int LisCia { get; set; }
        public virtual string LisCli { get; set; }
        public virtual string LisArt { get; set; }
        public virtual float LisPre { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as NmLis;
			if (t == null) return false;
			if (LisCia == t.LisCia
			 && LisCli == t.LisCli
			 && LisArt == t.LisArt)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ LisCia.GetHashCode();
			hash = (hash * 397) ^ LisCli.GetHashCode();
			hash = (hash * 397) ^ LisArt.GetHashCode();

			return hash;
        }
        #endregion
    }
}
