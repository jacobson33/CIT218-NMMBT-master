using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace NMMBTrails.Models
{
    [XmlRoot("Trails")]
    public class Trails
    {
        [XmlElement("Trail")]
        public List<Trail> trails;
    }
}