using ProjectManagement.Web.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Web.Filters
{
    public class ApplicationHandleErrorAttribute : System.Web.Http.Filters.ExceptionFilterAttribute, System.Web.Mvc.IExceptionFilter
    {
        public void OnException(System.Web.Mvc.ExceptionContext filterContext)
        {
            WebEventSource.Log.Failure(filterContext.Exception.Message);
        }

        public override void OnException(System.Web.Http.Filters.HttpActionExecutedContext context)
        {
            WebEventSource.Log.Failure(context.Exception.Message);
        }
    }
}