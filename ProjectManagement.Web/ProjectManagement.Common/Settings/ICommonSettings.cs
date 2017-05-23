using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Common.Settings
{
    /// <summary>
    /// Interface of common settings.
    /// </summary>
    public interface ICommonSettings
    {
        bool EnableCaching { get; }
        int DefaultCacheExpirationInMin { get; }
        string LogFilePath { get; }
    }
}
