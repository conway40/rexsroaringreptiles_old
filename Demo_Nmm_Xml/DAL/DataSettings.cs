using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Nmm_Xml.DAL
{
    public class DataSettings
    {
        public string dataFilePath = HttpContext.Current.Server.MapPath("~/App_Data/NMMDb.xml");
    }
}