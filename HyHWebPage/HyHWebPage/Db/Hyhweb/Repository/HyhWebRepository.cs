using System;
using System.Collections.Generic;
using FluentNHibernate.Utils;
using NHibernate;
using NHibernate.Criterion;
using NLog;

namespace HyHWebPage.Db.Hyhweb.Repository
{
	public class HyhWebRepository : IHyhWebRepository
	{
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        private readonly ISession _session;

        public HyhWebRepository(ISession session)
        {
            _session = session;
        }
        #region IHyhWebRepository implementation

        public List<T> Load<T>(IDictionary<string, object> restrictions) where T : class
        {
            _log.Info("Se consulta BD HyhWeb");
            var criteria = _session.CreateCriteria<T>();
            restrictions.Each(x =>
            {
                var type = typeof(T).GetProperty(x.Key).PropertyType;
                var obj = Convert.ChangeType(x.Value, type);
                criteria.Add(Restrictions.Eq(x.Key, obj));
            });
            return (List<T>)criteria.List<T>();
        }

	    public List<T> Save<T>(List<T> listToSave) where T : class
	    {
            _log.Info("Se consulta BD HyhWeb");
	        using (var tx = _session.BeginTransaction())
	        {
	            try
	            {
	                foreach (var toSave in listToSave)
	                {
                        _session.SaveOrUpdate(toSave);
                    }
                    tx.Commit();
	            }
	            catch (Exception ex)
	            {
                    tx.Rollback();
                    listToSave.Clear();
                    _log.Error("Error al guardar datos: {0} ", ex.Message);
	            }
	        }
	        return listToSave;
	    }

	    public List<int> Delete<T>(List<int> listId)
	    {
            _log.Info("Se consulta BD HyhWeb");
            using (var tx = _session.BeginTransaction())
            {
                try
                {
                    listId.ForEach(x =>
                    {
                        var toDelete = _session.Get<T>(x);
                        _session.Delete(toDelete);
                    });
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    _log.Error("Error al borrar datos: {0} ", ex.Message);
                }
            }
            return listId;
        }

	    #endregion
    }
}

