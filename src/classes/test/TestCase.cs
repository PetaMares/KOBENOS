using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace kobenos.category.test
{
    public class TestCase
    {
        public string name;
        public string scope;
        public string query;
        public string expectedProperty;
        public List<Regex> expectedValues;

        /// <summary>
        /// Zadefinovani testu
        /// </summary>
        /// <param name="node">Node s popisem testu</param>
        public TestCase(XmlNode node)
        {
            expectedValues = new List<Regex>();
            name = node.Attributes["name"].Value;
            scope = node.SelectSingleNode("scope").InnerText;
            query = node.SelectSingleNode("query").InnerText;
            XmlNode expected = node.SelectSingleNode("expected");
            expectedProperty = expected.Attributes["property"].Value;
            foreach (XmlNode xmlValue in expected.SelectNodes("value"))
            {
                expectedValues.Add(new Regex(xmlValue.InnerText));
            }
        }

        /// <summary>
        /// Provedeni testu
        /// </summary>
        /// <param name="queryObj">Vysledek dotazu do WMI</param>
        /// <returns></returns>
        public bool check(ManagementObject queryObj)
        {
            //		"Testing".Dump();
            string value = queryObj.GetPropertyValue(expectedProperty)/*[expectedProperty]*/.ToString();
            //			value.Dump();
            return expectedValues.Any(x => x.Match(value).Success);
        }
    }
}
