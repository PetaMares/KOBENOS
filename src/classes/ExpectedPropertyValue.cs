using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace kobenos.classes
{
    [XmlRoot("expected")]
    public class ExpectedPropertyValue
    {
        [XmlAttribute]
        public string property;

        [XmlAttribute]
        public string value;
    }
}
