using System;
using System.Configuration;

namespace CustomerHelperUtility
{
    public class ConfigReader
    {
        static Configuration Config;
        public ConfigReader()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            ConfigurationFileMap fileMap = new ConfigurationFileMap(path + "\\Settings.config");
            Config = ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
        }

        public string AppUrl
        {
            get
            {
                return Config.AppSettings.Settings["AppUrl"].Value;
            }
        }

        public string browser
        {
            get
            {
                return Config.AppSettings.Settings["browser"].Value;
            }
        }

        public string UserName
        {
            get
            {
                return Config.AppSettings.Settings["UserName"].Value;
            }
        }

        public string Password
        {
            get
            {
                return Config.AppSettings.Settings["Password"].Value;
            }
        }

        public string ScreenShotFolder
        {
            get
            {
                return Config.AppSettings.Settings["ScreenShotFolder"].Value;
            }
        }

        public string ChromeDriverPath
        {
            get
            {
                return Config.AppSettings.Settings["ChromeDriverPath"].Value;
            }
        }

        public string UseSeleniumGrid
        {
            get
            {
                return Config.AppSettings.Settings["UseSeleniumGrid"].Value;
            }
        }

        public string HubIP
        {
            get
            {
                return Config.AppSettings.Settings["HubIP"].Value;
            }
        }

        public string HubPort
        {
            get
            {
                return Config.AppSettings.Settings["HubPort"].Value;
            }
        }


        public string FireFoxBinary
        {
            get
            {
                return Config.AppSettings.Settings["FireFoxBinary"].Value;
            }
        }

        public string ElementLookupTimeOut
        {
            get
            {
                return Config.AppSettings.Settings["ElementLookupTimeOut"].Value;
            }
        }

        public string MaxTimeOut
        {
            get
            {
                return Config.AppSettings.Settings["MaxTimeOut"].Value;
            }
        }

        public string PageLoadTimeOut
        {
            get
            {
                return Config.AppSettings.Settings["PageLoadTimeOut"].Value;
            }
        }

        public string MinTimeOut
        {
            get
            {
                return Config.AppSettings.Settings["MinTimeOut"].Value;
            }
        }


        public string BOTimeOut
        {
            get
            {
                return Config.AppSettings.Settings["BOTimeOut"].Value;
            }
        }

        public string ClientCallTimeOut
        {
            get
            {
                return Config.AppSettings.Settings["ClientCallTimeOut"].Value;
            }
        }

        public string TenantAddress
        {
            get
            {
                return Config.AppSettings.Settings["TenantAddress"].Value;
            }
        }

        public string TenantPassword
        {
            get
            {
                return Config.AppSettings.Settings["TenantPassword"].Value;
            }
        }

        public string IEDriverPath
        {
            get
            {
                return Config.AppSettings.Settings["IEDriverPath"].Value;
            }
        }

        public string BuildInfo
        {
            get
            {
                return Config.AppSettings.Settings["BuildInfo"].Value;
            }
        }

        public string OutgoingHost
        {
            get
            {
                return Config.AppSettings.Settings["OutgoingHost"].Value;
            }
        }

        public string OutgoingPort
        {
            get
            {
                return Config.AppSettings.Settings["OutgoingPort"].Value;
            }
        }

        public string IncomingHostPop3
        {
            get
            {
                return Config.AppSettings.Settings["IncomingHostPop3"].Value;
            }
        }

        public string IncomingHostIMAP
        {
            get
            {
                return Config.AppSettings.Settings["IncomingHostIMAP"].Value;
            }
        }

        public string IncomingPortPop3
        {
            get
            {
                return Config.AppSettings.Settings["IncomingPortPop3"].Value;
            }
        }

        public string IncomingPortIMAP
        {
            get
            {
                return Config.AppSettings.Settings["IncomingPortIMAP"].Value;
            }
        }

        public string ExchangeWebServiceHost
        {
            get
            {
                return Config.AppSettings.Settings["ExchangeWebServiceHost"].Value;
            }
        }

        public string FromUserName
        {
            get
            {
                return Config.AppSettings.Settings["FromUserName"].Value;
            }
        }

        public string FromPassword
        {
            get
            {
                return Config.AppSettings.Settings["FromPassword"].Value;
            }
        }

        public string ConfigUrl
        {
            get
            {
                return Config.AppSettings.Settings["ConfigUrl"].Value;
            }
        }

        public string MetadataRevision
        {
            get
            {
                return Config.AppSettings.Settings["MetadataRevision"].Value;
            }
        }

        public string ITAMDB
        {
            get
            {
                return Config.AppSettings.Settings["ITAMDB"].Value;
            }
        }
    }
}
