using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace kobenos.category.test
{
    public class TestConfig
    {
        List<TestCase> testCases;        // seznam testu
        public XmlDocument xmlCfg;       // konfiguracni XML
        public XmlTextReader xmlReader;  // reader

        public TestConfig() { }

        /// <summary>
        /// Nacteni konfigurace z XML
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public List<TestCase> ReadTestConfig(string filename)
        {
            // Seznam testu
            List<TestCase> testCases = new List<TestCase>();

            // Nacti XML dokument
            XmlDocument xmlCfg = new XmlDocument();
            try
            {
                XmlTextReader xmlReader = new XmlTextReader(filename);
                xmlCfg.Load(xmlReader);
            }
            catch (Exception e)
            {
                Console.WriteLine("Chyba config.xml nejde otevrit");
                Console.WriteLine(e.Message);
                return null;
            }

            // Kontrola dokumentu
            /* Celkem zbytecne - jiz se kontroluje pri nahravani v objektu xmlCfg */
            if (xmlCfg.ChildNodes[0].InnerText.Equals("version=\"1.0\" encoding=\"UTF-8\"", StringComparison.Ordinal) == false)
            {
                Console.WriteLine("Neznám verze nebo kódování");
                return null;
            }

            if (xmlCfg.ChildNodes[1].Name.Equals("tests", StringComparison.Ordinal) == false)
            {
                Console.WriteLine("Neplatny format configuracniho souboru");
                return null;
            }

            // parsovani testu
            XmlNodeList xmlTestCases = xmlCfg.ChildNodes[1].SelectNodes("testcase");
            foreach (XmlNode xmlTestCase in xmlTestCases)
            {
                testCases.Add(new TestCase(xmlTestCase));
            }

            return testCases;
        }
    }
}
