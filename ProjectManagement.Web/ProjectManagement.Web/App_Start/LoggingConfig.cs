using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Formatters;
using ProjectManagement.Common.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Web;

namespace ProjectManagement.Web.App_Start
{
    public class LoggingConfig
    {
        public static void RegisterLoggingSources(IEnumerable<EventSource> logSources, ICommonSettings settings)
        {
            var logListener = new ObservableEventListener();

            foreach (var logSource in logSources)
            {
                logListener.EnableEvents(
                  logSource, EventLevel.LogAlways, Keywords.All);
            }

            logListener.LogToFlatFile(
                    fileName: settings.LogFilePath,
                    formatter: new EventTextFormatter());
        }
    }
}