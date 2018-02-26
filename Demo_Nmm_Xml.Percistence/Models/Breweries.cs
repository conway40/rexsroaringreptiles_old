using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Demo_Nmm_Xml.Models
{
    [XmlRoot("Breweries")]
    public class Breweries
    {
        [XmlElement("Brewery")]
        public List<Brewery> breweries;
    }
}