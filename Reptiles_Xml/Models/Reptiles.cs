using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Reptiles_Xml.Models
{
    [XmlRoot("Reptiles")]
    public class Reptiles
    {
        [XmlElement("Reptile")]
        public List<Reptile> reptiles;
    }
}