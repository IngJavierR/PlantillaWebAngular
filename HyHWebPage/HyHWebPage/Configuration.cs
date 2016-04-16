using System.Configuration;
using NLog;

namespace HyHWebPage
{
    public class Configuration
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger ();

        private static volatile Configuration _instance;
        private static readonly object SyncRoot = new object();

        public static Configuration Instance
        {
            get 
            {
                if (_instance == null) 
                {
                    lock (SyncRoot) 
                    {
                        if (_instance == null) 
                        {
                            _instance = new Configuration ();
                            Log.Debug ("Creando instancia de configuracion HyH");
                        }
                    }
                }

                return _instance;
            }
        }

        public string ReadConfig(string configKey)
        {
            return ConfigurationManager.AppSettings[configKey];
        }
    }
}

