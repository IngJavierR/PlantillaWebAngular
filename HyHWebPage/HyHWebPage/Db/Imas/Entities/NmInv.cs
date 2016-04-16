namespace HyHWebPage.Db.Imas.Entities {
    
    public class NmInv : IImasEntity
    {
        public virtual int InvCia { get; set; }
        public virtual int InvAlm { get; set; }
        public virtual string InvArt { get; set; }
        public virtual float InvSdo { get; set; }
        public virtual float? InvEnt { get; set; }
        public virtual float? InvSal { get; set; }
        public virtual float InvApa { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as NmInv;
			if (t == null) return false;
			if (InvCia == t.InvCia
			 && InvAlm == t.InvAlm
			 && InvArt == t.InvArt)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ InvCia.GetHashCode();
			hash = (hash * 397) ^ InvAlm.GetHashCode();
			hash = (hash * 397) ^ InvArt.GetHashCode();

			return hash;
        }
        #endregion
    }
}
