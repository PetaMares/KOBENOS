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

        protected override ExecutionResult internalExecute()
        {
            // Prohledavac WMI
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(this.scope, this.query);
            ManagementObjectCollection queryResults = searcher.Get();

            EvaluationInputValues values = new EvaluationInputValues();
            foreach (ManagementObject queryResult in queryResults)
            {
                values.Add(new WmiEvaluationObjectAdapter(queryResult));
            }

            return new ExecutionResult(this.Evaluations.Evaluate(values));
        }
            
    }
}
