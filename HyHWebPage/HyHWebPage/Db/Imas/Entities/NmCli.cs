using System;
using System.Text;
using System.Collections.Generic;


namespace HyHWebPage.Db.Imas.Entities {
    
    public class NmCli {
        public virtual int CliCia { get; set; }
        public virtual string CliId { get; set; }
        public virtual string CliNom { get; set; }
        public virtual string CliDep { get; set; }
        public virtual string CliCal { get; set; }
        public virtual string CliCol { get; set; }
        public virtual string CliDel { get; set; }
        public virtual string CliEdo { get; set; }
        public virtual string CliPai { get; set; }
        public virtual string CliCp { get; set; }
        public virtual string CliTe1 { get; set; }
        public virtual string CliTe2 { get; set; }
        public virtual string CliFax { get; set; }
        public virtual string CliEma { get; set; }
        public virtual string CliSit { get; set; }
        public virtual string CliCo1 { get; set; }
        public virtual string CliCo2 { get; set; }
        public virtual string CliAlt { get; set; }
        public virtual string CliBaj { get; set; }
        public virtual string CliMod { get; set; }
        public virtual string CliRfc { get; set; }
        public virtual string CliCurp { get; set; }
        public virtual short? CliSta { get; set; }
        public virtual string CliD01 { get; set; }
        public virtual string CliD02 { get; set; }
        public virtual string CliD03 { get; set; }
        public virtual string CliD04 { get; set; }
        public virtual string CliD05 { get; set; }
        public virtual float? CliLim { get; set; }
        public virtual int? CliPla { get; set; }
        public virtual float? CliDe1 { get; set; }
        public virtual float? CliDe2 { get; set; }
        public virtual float? CliDe3 { get; set; }
        public virtual float? CliDe4 { get; set; }
        public virtual short? CliChq { get; set; }
        public virtual string CliFan { get; set; }
        public virtual float? CliMon { get; set; }
        public virtual string CliCta { get; set; }
        public virtual string CliEca { get; set; }
        public virtual string CliEco { get; set; }
        public virtual string CliEde { get; set; }
        public virtual string CliEes { get; set; }
        public virtual string CliEpa { get; set; }
        public virtual string CliEcp { get; set; }
        public virtual string CliNac { get; set; }
        public virtual string CliDba { get; set; }
        public virtual short? CliImp { get; set; }
        public virtual short? CliMen { get; set; }
        public virtual string CliUve { get; set; }
        public virtual string CliVen { get; set; }
        public virtual int? CliRev { get; set; }
        public virtual int? CliPag { get; set; }
        public virtual short? CliLis { get; set; }
        public virtual short? CliClu { get; set; }
        public virtual string CliLad { get; set; }
        public virtual int? CliNiv { get; set; }
        public virtual int? CliPro { get; set; }
        public virtual string CliAbc { get; set; }
        public virtual int? CliPlaint { get; set; }
        public virtual string CliEme { get; set; }
        public virtual string CliCom { get; set; }
        public virtual string CliComven { get; set; }
        public virtual short? CliPco { get; set; }
        public virtual int? CliRev01 { get; set; }
        public virtual int? CliRev02 { get; set; }
        public virtual int? CliRev03 { get; set; }
        public virtual int? CliRev04 { get; set; }
        public virtual int? CliRev05 { get; set; }
        public virtual int? CliPag01 { get; set; }
        public virtual int? CliPag02 { get; set; }
        public virtual int? CliPag03 { get; set; }
        public virtual int? CliPag04 { get; set; }
        public virtual int? CliPag05 { get; set; }
        public virtual string CliHorrev { get; set; }
        public virtual string CliHorpag { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as NmCli;
			if (t == null) return false;
			if (CliCia == t.CliCia
			 && CliId == t.CliId)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ CliCia.GetHashCode();
			hash = (hash * 397) ^ CliId.GetHashCode();

			return hash;
        }
        #endregion
    }
}
