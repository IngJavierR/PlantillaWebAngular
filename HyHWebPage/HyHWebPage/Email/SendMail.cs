using System;
using System.Collections.Generic;
using System.Net.Mail;
using NLog;

namespace HyHWebPage.Email
{
    //la hacemos publica para que sea accesible desde otros namespaces
    public class SendMail
    {
        //Agregamos la clase de log para bitacoreo de errores
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private readonly SmtpClient _smtpClient;
        private readonly string _originMailAddress;
        //Agregamos un constructor para poder iniciar el smtpclient una vez y un metodo que solo genere un nuevo MailMessage
        public SendMail(string originMailAddress, string originMailPwd)
        {
            _originMailAddress = originMailAddress;
            //En .Net podemos inicializar de esta manera un objeto en vez de acceder una a una sus propiedades como java
            _smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(originMailAddress, originMailPwd),
                EnableSsl = true
            };
        }

        //Agregamos una lista de mail destinatarios para poder enviar a mas de uno al mismo tiempo.
        public bool Send(List<string> destMailList, string subject, string body)
        {
            Log.Info("Se envia mail");
            var mail = new MailMessage
            {
                From = new MailAddress(_originMailAddress),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            destMailList.ForEach(x => mail.To.Add(x));
            try
            {
                _smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                Log.Info("Ocurrió un error al enviar el mail: {0}", ex.Message);
                return false;
            }
            return true;
        }
    }
}
