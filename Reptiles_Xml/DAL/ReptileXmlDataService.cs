using System;
using System.Collections.Generic;
using System.Web;
using Reptiles_Xml.Models;
using System.IO;
using System.Xml.Serialization;

namespace Reptiles_Xml.DAL
{
    public class ReptileXmlDataService : IReptileDataServices, IDisposable
    {
        public List<Reptile> Read()
        {
            // a Reptiles model is defined to pass a type to the XmlSerializer object
            Reptiles reptilesObject;

            // initialize a FileStream object for reading
            string xmlFilePath = HttpContext.Current.Application["dataFilePath"].ToString();
            StreamReader sReader = new StreamReader(xmlFilePath);

            // initialize an XML serializer object
            XmlSerializer deserializer = new XmlSerializer(typeof(Reptiles));

            using (sReader)
            {
                // deserialize the XML data set into a generic object
                object xmlObject = deserializer.Deserialize(sReader);

                // cast the generic object to the list class
                reptilesObject = (Reptiles)xmlObject;
            }

            return reptilesObject.reptiles;
        }

        public void Write(List<Reptile> reptiles)
        {
            // initialize a FileStream object for reading
            string xmlFilePath = HttpContext.Current.Application["dataFilePath"].ToString();
            StreamWriter sWriter = new StreamWriter(xmlFilePath, false);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Reptile>), new XmlRootAttribute("Reptiles"));

            using (sWriter)
            {
                serializer.Serialize(sWriter, reptiles);
            }
        }

        public void Dispose()
        {
            // set resources to be cleaned up
        }
    }
}