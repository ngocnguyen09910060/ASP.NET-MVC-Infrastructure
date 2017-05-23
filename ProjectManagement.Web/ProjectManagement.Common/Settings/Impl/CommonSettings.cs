using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Common.Settings.Impl
{
    public class CommonSettings : ICommonSettings
    {
        public bool EnableCaching
        {
            get
            {
                bool enableCaching;
                if (bool.TryParse(ConfigurationManager.AppSettings["EnableCaching"], out enableCaching))
                    return enableCaching;

                return true;
            }
        }

        public int DefaultCacheExpirationInMin
        {
            get
            {
                int defaultCacheExInMin;
                if (int.TryParse(ConfigurationManager.AppSettings["EnableCaching"], out defaultCacheExInMin))
                    return defaultCacheExInMin;

                return 5;
            }
        }

        public string LogFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["LogFilePath"];
            }
        }
    }
}
