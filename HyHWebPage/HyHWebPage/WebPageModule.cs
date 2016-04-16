using System;
using System.Collections.Generic;
using Nancy;
using HyHWebPage.Db.Hyhweb.Repository;
using HyHWebPage.Db.Imas.Repository;
using Nancy.Extensions;
using Newtonsoft.Json;
using NLog;

namespace HyHWebPage
{
    public class WebPageModule : NancyModule
    {
		private static readonly Logger Log = LogManager.GetCurrentClassLogger ();

        public WebPageModule(IHyhWebRepository hyhWebSession, IImasRepository imasSession) : base("/api")
        {
			Get["/"] = _ => Response.AsRedirect("Content/app/index.html");

            #region HyhWebAccess
            Get["/hyhweb/{name}"] = parameters =>
            { 
                Log.Info("Get {0}", parameters.name);
                var dict = (Dictionary<string, object>)Request.Query.ToDictionary();
                var resultado = new object();
                try
                {
                    var instance = HyhWebRepositoryBuilder.CreateInstance(parameters.name);
                    var method = hyhWebSession.GetType().GetMethod("Load");
                    var generic = method.MakeGenericMethod(new Type[] { instance.GetType() });
                    resultado = generic.Invoke(hyhWebSession, new object[] { dict });
                }
                catch (Exception ex)
                {
                    Log.Error("Error {0}", ex.Message);
                }
                return ResponseSerialize(resultado);
            };

            Post["/hyhweb/{name}"] = parameters =>
            {
                Log.Info("Post {0}", parameters.name);
                var resultado = new object();
                try
                {
                    var listaIn = HyhWebRepositoryBuilder.EntityDeserialize(parameters.name, Request.Body);
                    var instance = HyhWebRepositoryBuilder.CreateInstance(parameters.name);
                    var method = hyhWebSession.GetType().GetMethod("Save");
                    var generic = method.MakeGenericMethod(new Type[] { instance.GetType() });
                    resultado = generic.Invoke(hyhWebSession, new object[] { listaIn });
                }
                catch (Exception ex)
                {
                    Log.Error("Error {0}", ex.Message);
                }
                return ResponseSerialize(resultado);
            };

            Delete["/hyhweb/{name}"] = parameters =>
            {
                Log.Info("Delete {0}", parameters.name);
                var resultado = new object();
                try
                {
                    var listaIn = JsonConvert.DeserializeObject<List<int>>(Request.Body.AsString());
                    var instance = HyhWebRepositoryBuilder.CreateInstance(parameters.name);
                    var method = hyhWebSession.GetType().GetMethod("Delete");
                    var generic = method.MakeGenericMethod(new Type[] { instance.GetType() });
                    resultado = generic.Invoke(hyhWebSession, new object[] { listaIn });
                }
                catch (Exception ex)
                {
                    Log.Error("Error {0}", ex.Message);
                }
                return ResponseSerialize(resultado);
            };

            #endregion

            #region ImasAccess
            Get["/imas/{name}"] = parameters =>
            {
                Log.Info("Get {0}", parameters.name);
                var dict = (Dictionary<string, object>) Request.Query.ToDictionary();
                var resultado = new object();
                try
                {
                    var instance = ImasRepositoryBuilder.CreateInstance(parameters.name);
                    var method = imasSession.GetType().GetMethod("Load");
                    var generic = method.MakeGenericMethod(new Type[] {instance.GetType()});
                    resultado = generic.Invoke(imasSession, new object[] { dict });
                }
                catch (Exception ex)
                {
                    Log.Error("Error {0}", ex.Message);
                }
                return ResponseSerialize(resultado);
            };
            #endregion
        }

        private Response ResponseSerialize(object entity)
		{
			var result = (Response)JsonConvert.SerializeObject(entity, new JsonSerializerSettings()
				{
					ContractResolver = new NHibernateContractResolver()
				});
			result.ContentType = "application/json";
			return result;
		}
    }
}
