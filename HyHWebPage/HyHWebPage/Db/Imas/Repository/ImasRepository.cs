using System;
using System.Collections.Generic;
using FluentNHibernate.Utils;
using NHibernate;
using NHibernate.Criterion;
using NLog;

namespace HyHWebPage.Db.Imas.Repository
{
	public class ImasRepository : IImasRepository
    {
		private readonly Logger _log = LogManager.GetCurrentClassLogger ();
		private readonly ISession _session;

		public ImasRepository(ISession session){
			_session = session;
		}
        #region IImasRepository implementation

        public List<T> Load<T>(IDictionary<string, object> restrictions) where T : class
        {
            _log.Info("Se consulta BD Imas");
            var criteria = _session.CreateCriteria<T>();
            restrictions.Each(x =>
            {
                var type = typeof(T).GetProperty(x.Key).PropertyType;
                var obj = Convert.ChangeType(x.Value, type);
                criteria.Add(Restrictions.Eq(x.Key, obj));
            });
            return (List<T>)criteria.List<T>();
        }
		#endregion
	}
}

