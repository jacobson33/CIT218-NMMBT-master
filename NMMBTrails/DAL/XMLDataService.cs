using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml.Serialization;
using NMMBTrails.Models;

namespace NMMBTrails.DAL
{
    public class XMLDataService : ITrailDataService, IDisposable
    {
       public List<Trail> Read()
        {
            // a Breweries model is defined to pass a type to the XmlSerializer object 
            Trails trailsObject;

            // initialize a FileStream object for reading
            string xmlFilePath = HttpContext.Current.Application["dataFilePath"].ToString();
            StreamReader sReader = new StreamReader(xmlFilePath);

            // initialize an XML seriailizer object
            XmlSerializer deserializer = new XmlSerializer(typeof(Trails));

            using (sReader)
            {
                // deserialize the XML data set into a generic object
                object xmlObject = deserializer.Deserialize(sReader);

                // cast the generic object to the list class
                trailsObject = (Trails)xmlObject;
            }

            return trailsObject.trails;
        }

        public void Write(List<Trail> trails)
        {
            // initialize a FileStream object for reading
            string xmlFilePath = HttpContext.Current.Application["dataFilePath"].ToString();
            StreamWriter sWriter = new StreamWriter(xmlFilePath, false);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Trail>), new XmlRootAttribute("Trails"));

            using (sWriter)
            {
                serializer.Serialize(sWriter, trails);
            }
        }

        public void Dispose()
        {
            // set resources to be cleaned up
        }
    }
}
