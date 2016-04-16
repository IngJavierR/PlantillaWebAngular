using System.Collections.Generic;
using System.Text;
using HyHWebPage.Email;
using NUnit.Framework;

namespace HyHWebPageTests.Email
{
    [TestFixture]
    public class SendMailTests
    {
        private SendMail _sendMail;
        [SetUp]
        public void SetUp()
        {
            _sendMail = new SendMail("chrisgugo0720@gmail.com", "CDgg2007");
        }

        [Test, Ignore("Para no enviar mail todo el tiempo")]
        public void send_mail_correct()
        {
            var mailList = new List<string>
            {
                "edgar.martinez@happenmx.com",
                "daniel.teran@happenmx.com",
                "javier.rodriguez@happenmx.com"
            };
            var body = new StringBuilder();
            body.Append("<h1>Happen</h1>");
            body.Append("<h2>Correo de prueba</h2>");
            body.Append("<h3>Confirmacion de pedidos</h3>");
            body.Append("<h4>Proveedora HyH</h4>");

            var result = _sendMail.Send(mailList, "Mail de prueba", body.ToString());
            Assert.IsTrue(result, "El mensaje de correo no se envió");
        }
    }
}
