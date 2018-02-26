using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reptiles_Xml.Models
{
    public class Reptile
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string LifeSpan { get; set; }
        public string Environment { get; set; }
        public string ExperienceLevel { get; set; }
        public double Price { get; set; }
    }
}