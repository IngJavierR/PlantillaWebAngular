namespace HyHWebPage.Db.Imas.Entities
{
    public class NmClu : IImasEntity
    {
        public virtual int CluCia { get; set; }
        public virtual string CluCte { get; set; }
        public virtual string CluId { get; set; }
        public virtual string CluDes { get; set; }
        public virtual string CluEma { get; set; }
        public virtual string CluCon { get; set; }
        public virtual string CluTel1 { get; set; }
        public virtual string CluTel2 { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as NmClu;
            if (t == null) return false;
            if (CluCia == t.CluCia
             && CluCte == t.CluCte
             && CluId == t.CluId)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ CluCia.GetHashCode();
            hash = (hash * 397) ^ CluCte.GetHashCode();
            hash = (hash * 397) ^ CluId.GetHashCode();

            return hash;
        }
        #endregion
    }
}

