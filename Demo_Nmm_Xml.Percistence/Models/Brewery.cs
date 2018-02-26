using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Nmm_Xml.Models
{
    public class Brewery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get;  set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string URL { get; set; }

    }
}