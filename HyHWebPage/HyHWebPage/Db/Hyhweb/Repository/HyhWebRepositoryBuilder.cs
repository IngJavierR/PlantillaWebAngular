using System;
using System.Collections.Generic;
using HyHWebPage.Db.Hyhweb.Entities;
using HyHWebPage.Utils;
using Nancy.IO;
using Newtonsoft.Json;

namespace HyHWebPage.Db.Hyhweb.Repository
{
    public class HyhWebRepositoryBuilder
    {
        static public object CreateInstance(string entityName)
        {
            var entityTypeName = string.Format("{0}.{1}", typeof(IHyhWebEntity).Namespace, entityName);
            var entityType = Type.GetType(entityTypeName);
            var instance = Activator.CreateInstance(entityType);
            return instance;
        }

        public static object EntityDeserialize(string entityName, RequestStream requestStream)
        {
            var requestString = requestStream.StreamAsString();
            var entityTypeName = string.Format("{0}.{1}", typeof(IHyhWebEntity).Namespace, entityName);

            var entityType = Type.GetType(entityTypeName);
            var genericList = typeof (List<>).MakeGenericType(entityType);
            return JsonConvert.DeserializeObject(requestString, genericList);
        }
    }
}
