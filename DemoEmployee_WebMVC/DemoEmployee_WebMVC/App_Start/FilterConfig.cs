﻿using System.Web;
using System.Web.Mvc;

namespace DemoEmployee_WebMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
