using kobenos.classes.configuration;
using System.Collections.Generic;

namespace kobenos.classes.test
{
    /**
     * Reprezentuje jeden bezpečnostní test.
     */
    class Test
    {
        public TestConfiguration config;

        public List<Check> checks = new List<Check>();

        public Test(TestConfiguration config)
        {
            this.config = config;
            foreach (TestConfiguration checkConfig in config.checks)
            {
                checks.Add(new Check(checkConfig));
            }
        }
    }
}
