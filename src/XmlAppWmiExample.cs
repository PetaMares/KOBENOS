using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Management;

// pro podporu System.Management je nutne vlozit do projektu referenci na System.Management framework

namespace XmlApp1
{
    /// <summary>
    /// Trida popisujici testovaci priklad
    /// </summary>
    public class TestCase
    {
        public string name;
        public string scope;
        public string query;
        public string expectedProperty;
        public List<string> expectedValues;

        /// <summary>
        /// Zadefinovani testu
        /// </summary>
        /// <param name="node">Node s popisem testu</param>
        public TestCase(XmlNode node)
        {
            expectedValues = new List<string>();
            name = node.Attributes["name"].Value;
            scope = node.SelectSingleNode("scope").InnerText;
            query = node.SelectSingleNode("query").InnerText;
            XmlNode expected = node.SelectSingleNode("expected");
            expectedProperty = expected.Attributes["property"].Value;
            foreach (XmlNode xmlValue in expected.SelectNodes("value"))
            {
                expectedValues.Add(xmlValue.InnerText);
            }
        }

        /// <summary>
        /// Provedeni testu
        /// </summary>
        /// <param name="queryObj">Vysledek dotazu do WMI</param>
        /// <returns></returns>
        public bool check(ManagementObject queryObj)
        {
            string value = queryObj[expectedProperty].ToString();
            if (expectedValues.IndexOf(value) == -1) return false;
            else return true;
        }
    }

    /// <summary>
    /// Trida pro cteni konfiguracniho XML
    /// </summary>
    public class TestConfig
    {
        List<TestCase> testCases;        // seznam testu
        public XmlDocument xmlCfg;       // konfiguracni XML
        public XmlTextReader xmlReader;  // reader

        public TestConfig()  { }

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

    /// <summary>
    /// Priklad provedeni testu
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Prohledavac WMI
            ManagementObjectSearcher searcher = new ManagementObjectSearcher();

            // konfigurace testu
            TestConfig tstcfg = new TestConfig();

            // nacteni testovacich pripadu
            List<TestCase> testCases = tstcfg.ReadTestConfig("config.xml");

            // provedeni vsech testu
            foreach (TestCase test in testCases)
            {
                searcher = new ManagementObjectSearcher(test.scope, test.query);
                // var result = searcher.Get();
                // if(result.Count() == 0) selhat();
                foreach(ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine(queryObj.ToString());
                    
                    if (test.check(queryObj) == false)
                    {
                        Console.WriteLine("Test neprosel");
                        break;
                    }
                }
            }
        }
    }
}
