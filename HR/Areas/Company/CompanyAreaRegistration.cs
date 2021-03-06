﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Areas.Company
{
    public class CompanyAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Company";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Company_default",
                "Company/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}