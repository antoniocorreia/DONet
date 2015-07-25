using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace D.O.Net.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            if (System.Web.HttpContext.Current.ApplicationInstance.Request.Url.Segments.Count() > 1)
            {
                ViewBag.VirtualPath = string.Concat(System.Web.HttpContext.Current.ApplicationInstance.Request.Url.Segments[0],
                    System.Web.HttpContext.Current.ApplicationInstance.Request.Url.Segments[1]);
            }
        }
	}
}