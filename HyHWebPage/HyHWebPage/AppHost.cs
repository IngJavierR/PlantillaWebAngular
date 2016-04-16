using System;
using Nancy.Hosting.Self;
using NLog;

namespace HyHWebPage
{
    public class AppHost
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger ();

        private static volatile AppHost _instance;
        private static readonly object SyncRoot = new object ();

        public static AppHost Instance {
            get {
                if (_instance == null) {
                    lock (SyncRoot) {
                        if (_instance == null) {
                            _instance = new AppHost ();
							Log.Info ("Creando instancia de host HyH");
                        }
                    }
                }

                return _instance;
            }
        }

        public void Start ()
        {
            var ip = Configuration.Instance.ReadConfig ("IP");
            var port = Configuration.Instance.ReadConfig ("ListenPort");

            var url = string.Format ("http://{0}:{1}", ip, port);


            using (var host = new NancyHost (new Uri (url))) {
				Log.Info("Iniciando host HyH");
                host.Start ();
                Console.ReadKey ();
				Log.Info("Deteniendo host HyH");
                host.Stop ();
            }
        }
    }
}

