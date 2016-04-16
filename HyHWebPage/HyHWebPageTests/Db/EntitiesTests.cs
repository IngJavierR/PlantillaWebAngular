using System;
using System.Linq;
using HyHWebPage.Db.Hyhweb.Entities;
using HyHWebPage.Db.Imas.Entities;
using NUnit.Framework;

namespace HyHWebPageTests.Db
{
    [TestFixture, Description("Valida la correcta implementacion de las clases")]
    public class EntitiesTests
    {
        #region HyHWeb

        [Test, Description("Valida el numero de clases que implementan la interfaz IHyhWebEntity")]
        public void Should_get_the_number_of_classes_that_implements_IHyhWebEntity()
        {
            const int numberOfClasesImplemenstIHyhWebEntity = 3;
            var type = typeof (IHyhWebEntity);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
            Assert.AreEqual(numberOfClasesImplemenstIHyhWebEntity, types.Count());
        }

        #endregion

        #region Imas
        [Test, Description("Valida el numero de clases que implementan la interfaz IImasEntity")]
        public void Should_get_the_number_of_classes_that_implements_IImasEntity()
        {
            const int numberOfClasesImplemenstIImasEntity = 3;
            var type = typeof(IImasEntity);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
            Assert.AreEqual(numberOfClasesImplemenstIImasEntity, types.Count());
        }
        #endregion
    }
}
