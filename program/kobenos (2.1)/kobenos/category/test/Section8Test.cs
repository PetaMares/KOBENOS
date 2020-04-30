using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Text;

namespace kobenos.category.test
{
    class Section8Test: AbstractTest
    {
        public Section8Test(string id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        public override bool execute()
        {
            // Prohledavac WMI
            ManagementObjectSearcher searcher = new ManagementObjectSearcher();

            // konfigurace testu
            TestConfig tstcfg = new TestConfig();

            // nacteni testovacich pripadu
            List<TestCase> testCases = tstcfg.ReadTestConfig(Path.GetFullPath(kobenos.welcomePage.nameFile));//.Combine(@"C:\Users\siman\Desktop\prilohy", "config.xml"));

            // provedeni vsech testu
            foreach (TestCase test in testCases)
            {
                searcher = new ManagementObjectSearcher(test.scope, test.query);
                // var result = searcher.Get();
                // if(result.Count() == 0) selhat();
                //			searcher.Get().Dump();
                //			return;

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    //                    Console.WriteLine(queryObj.ToString());

                    if (test.check(queryObj) == false)
                    {
                        Console.WriteLine($"Test {test.name} neprosel");
                    }
                    else
                    {
                        Console.WriteLine($"Test {test.name} prosel");
                        Result = true;
                    }
                }
            }

            return true;
            //throw new NotImplementedException();
        }

        public override bool fixSetting()
        {
            return true;
            //throw new NotImplementedException();
        }

        public override void setConfiguration(string key, string value)
        {
            //throw new NotImplementedException();
        }
    }
}
