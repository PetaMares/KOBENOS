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

        [XmlArray("eval")]
        [XmlArrayItem(typeof(FirstValueRegExWmiEvaluation), ElementName = "first")]
        [XmlArrayItem(typeof(MinValuesCountWmiEvaluation), ElementName = "min")]
        public WmiEvaluations Evaluations;

        protected override ExecutionResult internalExecute()
        {
            // Prohledavac WMI
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(this.scope, this.query);
            ManagementObjectCollection queryResults = searcher.Get();

            return new ExecutionResult(this.Evaluations.Evaluate(queryResults));
        }
            
    }
}
