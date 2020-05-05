using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Text;
using System.Xml.Serialization;

namespace kobenos.classes
{

    [XmlRoot("gpo")]
    public class GpoCheck: AbstractCheck
    {

        public string location;

        public string policy;

        [XmlArray("eval")]
        [XmlArrayItem(typeof(FirstValueRegExEvaluation), ElementName = "first")]
        [XmlArrayItem(typeof(MinValuesCountEvaluation), ElementName = "min")]
        public Evaluations Evaluations;

        protected override ExecutionResult internalExecute()
        {
            EvaluationInputValues values = new EvaluationInputValues();
            return new ExecutionResult(this.Evaluations.Evaluate(values));
        }
            
    }
}
