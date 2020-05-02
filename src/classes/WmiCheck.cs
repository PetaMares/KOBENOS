using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Text;
using System.Xml.Serialization;

namespace kobenos.classes
{

    [XmlRoot("wmi")]
    public class WmiCheck: AbstractCheck
    {

        public string scope;

        public string query;

        public ExpectedPropertyValue expected;

        protected override ExecutionResult internalExecute()
        {
            // Prohledavac WMI
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(this.scope, this.query);
            ManagementObjectCollection queryResults = searcher.Get();

            bool result = false;
            string details = "";

            foreach (ManagementObject queryResult in queryResults)
            {
                result = result || queryResult.GetPropertyValue(this.expected.property).Equals(this.expected.value);
                details = queryResult.ToString();
            }

            return new ExecutionResult(result, details);
        }
            
    }
}
