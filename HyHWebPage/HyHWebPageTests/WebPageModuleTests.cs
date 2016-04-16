using System.Collections.Generic;
using CsQuery.ExtensionMethods;
using HyHWebPage;
using HyHWebPage.Db.Hyhweb.Entities;
using Nancy;
using Nancy.Bootstrappers.Ninject;
using Nancy.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace HyHWebPageTests
{
    [TestFixture, Description("Pruebas unitarias a modulos REST")]
    public class WebPageModuleTests
    {
        private NinjectNancyBootstrapper _bootstrapper;
        private Browser _browser;

        private static readonly List<string> HyhWebEntities = new List<string>
        {
            "Clientes",
            "Pedidos",
            "Productos",
            "Usuarios",
            "DetallePedidos",
            "UsuariosTipoCt"
        };

        private static readonly List<string> ImasEntities = new List<string>
        {
            "NmClu",
            "NmInv",
            "NmArt",
            "NmCli",
            "NmLis"
        };

        private static readonly List<List<IHyhWebEntity>> HyhWeCatalogosList = new List<List<IHyhWebEntity>>
        {
            new List<IHyhWebEntity>
            {
                new Clientes
                {
                    ClaveCliente = "CveTest",
                    UnidadEntrega = "UniTest",
                    ClientesEstadoCt = new ClientesEstadoCt
                    {
                        Id = 1,
                        Descripcion = "DescTest"
                    }
                }
            }
        };

        [SetUp]
        public void SetUp()
        {
            _bootstrapper = new HyhBootstrapper();
            _browser = new Browser(_bootstrapper, to => to.Accept("application/json"));
        }

        #region General
        [Test, Description("Valida que la ruta api retorne index.html")]
        public void Should_return_index_html_origin_api()
        {
            var result = _browser.Get("/api/", with =>
            {
                with.HttpRequest();
            });
            result.ShouldHaveRedirectedTo("Content/app/index.html");
            Assert.AreEqual(HttpStatusCode.SeeOther, result.StatusCode);
        }

        [Test, Description("Valida que se retorne un error 404 con una ruta invalida")]
        public void Should_return_status_not_found_when_route_not_exists()
        {
            var result = _browser.Get("/fail/", with =>
            {
                with.HttpRequest();
            });

            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }
        #endregion

        #region HyHWeb
        [Test, TestCaseSource(nameof(HyhWebEntities)), Description("Valida que exista una ruta /api/hyhweb/{name}")]
        public void Should_return_ok_when_for_hyhweb_entities(string catalogo)
        {
            var result = _browser.Get(string.Format("/api/hyhweb/{0}/", catalogo), with =>
            {
                with.HttpRequest();
            });

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test, TestCaseSource(nameof(HyhWeCatalogosList)), Description("Valida proceso alta, consulta y baja de catalogos HyhWeb")]
        public void Should_return_ok_when_for_catalogos_name_id_concepto(List<IHyhWebEntity> catalogo)
        {
            var jsonToSave = JsonConvert.SerializeObject(catalogo);

            var toSave = _browser.Post(string.Format("/api/hyhweb/{0}", catalogo[0].GetType().Name), with =>
            {
                with.HttpRequest();
                with.Header("Accept", "application/json");
                with.Body(jsonToSave);
            });
            Assert.AreEqual(HttpStatusCode.OK, toSave.StatusCode, "Error al guardar el catalogo {0}", catalogo[0].GetType().Name);

            var resultGetAll = _browser.Get(string.Format("/api/hyhweb/{0}/", catalogo[0].GetType().Name), with =>
            {
                with.HttpRequest();
                with.Header("content-type", "application/json");
            });
            Assert.AreEqual(HttpStatusCode.OK, resultGetAll.StatusCode, "Error al consultar todos los registros del catalogo {0}", catalogo.GetType().Name);

            var body = resultGetAll.Body.AsString();
            var responseObjectList = (JArray)JsonConvert.DeserializeObject(body, catalogo[0].GetType().BaseType);
            IJEnumerable<JToken>[] list = { responseObjectList.Last.AsJEnumerable() };

            var properties = catalogo[0].GetType().GetProperties();
            var newId = "";
            properties.ForEach(x =>
            {
                if (!x.Name.StartsWith("Id"))
                {
                    var catalogoProp = catalogo[0].GetType().GetProperty(x.Name).GetValue(catalogo[0], null).ToString();
                    var listProp = list[0][x.Name].ToString();
                    if (!catalogoProp.Contains("HyHWebPage.Db.Hyhweb.Entities"))
                    {
                        Assert.AreEqual(catalogoProp, listProp,
                            "Error al compara informacion por cada propiedad [Consulta de todos los catalogos]");
                    }
                }
                else
                {
                    newId = list[0][x.Name].ToString();
                }
            });

            var resultGet = _browser.Get(string.Format("/api/hyhweb/{0}/", catalogo[0].GetType().Name), with =>
            {
                with.HttpRequest();
                with.Header("content-type", "application/json");
                with.Query("Id", newId);
            });
            Assert.AreEqual(HttpStatusCode.OK, resultGet.StatusCode, "Error en el la consulta de un solo elemento del catalogo");
            body = resultGetAll.Body.AsString();
            responseObjectList = (JArray)JsonConvert.DeserializeObject(body, catalogo.GetType().BaseType);
            list[0] = responseObjectList.Last.AsJEnumerable();
            properties = catalogo[0].GetType().GetProperties();
            properties.ForEach(x =>
            {
                if (!x.Name.StartsWith("Id"))
                {
                    var catalogoProp = catalogo[0].GetType().GetProperty(x.Name).GetValue(catalogo[0], null).ToString();
                    var listProp = list[0][x.Name].ToString();
                    if (!catalogoProp.Contains("HyHWebPage.Db.Hyhweb.Entities"))
                    {
                        Assert.AreEqual(catalogoProp, listProp,
                            "Error al compara informacion por cada propiedad [Consulta de todos los catalogos]");
                    }
                }
                else
                {
                    newId = list[0][x.Name].ToString();
                }
            });

            var jsonToDelete = JsonConvert.SerializeObject(new List<int> { int.Parse(newId) });
            var resultDelete = _browser.Delete(string.Format("/api/hyhweb/{0}/", catalogo[0].GetType().Name), with =>
            {
                with.HttpRequest();
                with.Header("content-type", "application/json");
                with.Body(jsonToDelete);
            });
            Assert.AreEqual(HttpStatusCode.OK, resultDelete.StatusCode, "Error en el borrado del catalogo {0}", catalogo[0].GetType().Name);
        }

        #endregion

            #region Imas
        [Test, TestCaseSource(nameof(ImasEntities)), Description("Valida que exista una ruta /api/imas/{name}")]
        public void Should_return_ok_when_for_imas_entities(string catalogo)
        {
            var result = _browser.Get(string.Format("/api/imas/{0}/", catalogo), with =>
            {
                with.HttpRequest();
            });

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
        #endregion


    }
}
