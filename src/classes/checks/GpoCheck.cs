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

        protected override ExecutionResult internalExecute()
        {
            EvaluationInputValues values = new EvaluationInputValues();
            return new ExecutionResult(this.Evaluations.Evaluate(values));
        }
            
    }
}
