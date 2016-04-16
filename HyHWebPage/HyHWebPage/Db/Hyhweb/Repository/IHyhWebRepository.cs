using System.Collections.Generic;
using HyHWebPage.Db.Hyhweb.Entities;

namespace HyHWebPage.Db.Hyhweb.Repository
{
	public interface IHyhWebRepository
	{
        List<T> Load<T>(IDictionary<string, object> restrictions) where T : class;
        List<T> Save<T>(List<T> listToSave) where T : class;
	    List<int> Delete<T>(List<int> listId);
	}
}

