<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Management.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Management</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Xml</Namespace>
</Query>

void Main(string[] args)
        {
            // Prohledavac WMI
            ManagementObjectSearcher searcher = new ManagementObjectSearcher();

            // konfigurace testu
            TestConfig tstcfg = new TestConfig();

            // nacteni testovacich pripadu
            List<TestCase> testCases = tstcfg.ReadTestConfig(Path.Combine(@"C:\Users\Petr\Desktop\program","config.xml"));

            // provedeni vsech testu
            foreach (TestCase test in testCases)
            {
                searcher = new ManagementObjectSearcher(test.scope, test.query);
                // var result = searcher.Get();
                // if(result.Count() == 0) selhat();
//			searcher.Get().Dump();
//			return;
				
                foreach(ManagementObject queryObj in searcher.Get())
                {
//                    Console.WriteLine(queryObj.ToString());
                    
                    if (test.check(queryObj) == false)
                    {
                        Console.WriteLine($"Test {test.name} neprosel");
                    }
					else
					 {
                        Console.WriteLine($"Test {test.name} prosel");						
                    }
                }
            }
        }
 
 
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