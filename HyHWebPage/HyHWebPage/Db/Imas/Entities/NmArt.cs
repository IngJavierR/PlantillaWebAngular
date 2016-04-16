using System;
using System.Text;
using System.Collections.Generic;


namespace HyHWebPage.Db.Imas.Entities {
    
    public class NmArt {
        public virtual int ArtCia { get; set; }
        public virtual string ArtId { get; set; }
        public virtual string ArtNom { get; set; }
        public virtual string ArtUnd { get; set; }
        public virtual float? ArtPes { get; set; }
        public virtual float? ArtPun { get; set; }
        public virtual float? ArtCos { get; set; }
        public virtual float? ArtVen { get; set; }
        public virtual string ArtFve { get; set; }
        public virtual int? ArtSeg { get; set; }
        public virtual int? ArtEnt { get; set; }
        public virtual int? ArtMin { get; set; }
        public virtual int? ArtMax { get; set; }
        public virtual string ArtAlt { get; set; }
        public virtual string ArtMod { get; set; }
        public virtual string ArtUco { get; set; }
        public virtual string ArtUve { get; set; }
        public virtual float? ArtUlc { get; set; }
        public virtual string ArtD01 { get; set; }
        public virtual string ArtD02 { get; set; }
        public virtual string ArtD03 { get; set; }
        public virtual string ArtD04 { get; set; }
        public virtual string ArtD05 { get; set; }
        public virtual string ArtP01 { get; set; }
        public virtual string ArtP02 { get; set; }
        public virtual string ArtP03 { get; set; }
        public virtual string ArtP04 { get; set; }
        public virtual string ArtP05 { get; set; }
        public virtual float? ArtImp { get; set; }
        public virtual string ArtTip { get; set; }
        public virtual string ArtAbc { get; set; }
        public virtual string ArtLin { get; set; }
        public virtual string ArtUnc { get; set; }
        public virtual float? ArtRun { get; set; }
        public virtual string ArtMon { get; set; }
        public virtual float? ArtVol { get; set; }
        public virtual float? ArtMul { get; set; }
        public virtual float? ArtIm2 { get; set; }
        public virtual string ArtCod { get; set; }
        public virtual string ArtF01 { get; set; }
        public virtual string ArtF02 { get; set; }
        public virtual string ArtF03 { get; set; }
        public virtual string ArtF04 { get; set; }
        public virtual string ArtF05 { get; set; }
        public virtual string ArtF06 { get; set; }
        public virtual string ArtF07 { get; set; }
        public virtual string ArtF08 { get; set; }
        public virtual string ArtF09 { get; set; }
        public virtual string ArtF10 { get; set; }
        public virtual string ArtUob { get; set; }
        public virtual float? ArtFac { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as NmArt;
			if (t == null) return false;
			if (ArtCia == t.ArtCia
			 && ArtId == t.ArtId)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ ArtCia.GetHashCode();
			hash = (hash * 397) ^ ArtId.GetHashCode();

			return hash;
        }
        #endregion
    }
}
