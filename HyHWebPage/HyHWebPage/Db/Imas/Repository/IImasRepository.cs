using System.Collections.Generic;

namespace HyHWebPage.Db.Imas.Repository
{
	public interface IImasRepository
	{
	    List<T> Load<T>(IDictionary<string, object> restrictions) where T : class;
	}
}

