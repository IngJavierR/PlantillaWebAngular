using System;
using HyHWebPage.Db.Imas.Entities;

namespace HyHWebPage.Db.Imas.Repository
{
    public class ImasRepositoryBuilder
    {
        static public object CreateInstance(string entityName)
        {
            var entityTypeName = string.Format("{0}.{1}", typeof(IImasEntity).Namespace, entityName);
            var entityType = Type.GetType(entityTypeName);
            var instance = Activator.CreateInstance(entityType);
            return instance;
        }
    }
}
