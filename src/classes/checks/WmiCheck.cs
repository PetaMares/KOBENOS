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

            string actualValues = "";
            bool result = false;
            string details = "";

            foreach (ManagementObject queryResult in queryResults)
            {
                string actualValue = queryResult.GetPropertyValue(this.expected.property).ToString();
                actualValues += actualValue + ",";
                bool thisResult = actualValue.Equals(this.expected.value);
                string detail = thisResult ? "" : String.Format("Actual value: {0}, expected value: {1}", actualValue, this.expected.value);
                result = result || thisResult;
                details += detail;
            }

            return new ExecutionResult(result, details);
        }
            
    }
}
