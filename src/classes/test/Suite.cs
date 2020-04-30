using kobenos.classes.configuration;
using System.Collections.Generic;
using System.Text;

namespace kobenos.classes.test
{
    /**
     * Reprezentuje celou sadu testů, která se spouští jako celek.
     */
    class Suite
    {
        public SuiteConfiguration config;

        public List<Test> tests = new List<Test>();

        public Suite(SuiteConfiguration config)
        {
            this.config = config;
            foreach (TestConfiguration testConfig in config.tests) {
                tests.Add(new Test(testConfig));
            }
        }

        public SuiteResult execute()
        {

        }

    }
}
