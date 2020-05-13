using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Drawing2D;
using System.Management.Automation;
using System.Text;
using System.Xml.Serialization;

namespace kobenos.classes
{

    [XmlRoot("security")]
    public class SecurityCheck : SimpleCheck
    {
        protected override ExecutionResult internalExecute()
        {
            var values = new List<IEvaluationObject>();
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                string command = "secedit /export /cfg temp.ini; Get-Content -Path .\\temp.ini;";
                PowerShellInstance.AddScript(command);
                Collection<PSObject> PSOutput = PowerShellInstance.Invoke();
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (PSObject outputItem in PSOutput)
                {
                    if (outputItem != null)
                    {
                        string line = outputItem.BaseObject.ToString();
                        string[] pair = line.Split('=');
                        if (pair.Length > 1) {
                            dictionary.Add(pair[0].Trim(), pair[1].Trim());
                        }
                    }
                }
                values.Add(new DictionaryEvaluationObjectAdapter(dictionary));
            }            
            return new ExecutionResult(this.Evaluations.Evaluate(values));
        }
    }
}
