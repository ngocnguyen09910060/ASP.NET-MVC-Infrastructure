﻿using ProjectManagement.Web.Filters;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagement.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ApplicationHandleErrorAttribute());
        }
    }
}