using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Web;

namespace ProjectManagement.Web.Logging
{
    internal class WebEventSource : EventSource
    {
        public class Keywords
        {
            public const EventKeywords Data = (EventKeywords)1;
            public const EventKeywords Diagnostic = (EventKeywords)2;
            public const EventKeywords Perf = (EventKeywords)4;
        }

        public class Tasks
        {
            public const EventTask Data = (EventTask)1;
        }

        private static readonly Lazy<WebEventSource> Instance =
        new Lazy<WebEventSource>(() => new WebEventSource());

        private WebEventSource() { }

        public static WebEventSource Log { get { return Instance.Value; } }

        [Event(1, Message = "Application Failure: {0}",
        Level = EventLevel.Critical, Keywords = Keywords.Diagnostic)]
        public void Failure(string message)
        {
            this.WriteEvent(1, message);
        }
    }
}