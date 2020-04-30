using kobenos.category.test;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace kobenos.category.configuration
{
    class LoadConfiguration
    {
        public void ReadCSV(string fileName, IEnumerable<ITest> tests)
        {
            string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"));

            foreach (string line in lines)
            {
                string[] data = line.Split(';');
                ITest node = findTest(tests, data[0]);
                if(node!=null)
                {
                    node.setConfiguration(data[1], data[2]);
                }
            }
        }

        private ITest findTest(IEnumerable<ITest> tests, string testId)
        {
            foreach(ITest test in tests)
            {
                if(testId == test.getId())
                {
                    return test;
                }
            }
            return null;
        }
    }
}
