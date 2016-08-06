using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task1.helpers
{
    public class BaseController : Controller
    {
        public RegexHelper regexHelper = new RegexHelper();
    }
}