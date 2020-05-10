using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Drawing2D;
using System.Management.Automation;
using System.Text;
using System.Xml.Serialization;

namespace kobenos.classes
{

    [XmlRoot("securityaccount")]
    public class SecurityCheckAccount : AbstractCheck
    {
        public string accountName;

        protected override ExecutionResult internalExecute()
        {
            var values = new List<IEvaluationObject>();
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                string command = "$adsi = [ADSI]\"WinNT://$env:COMPUTERNAME\"; $adsi.Children | where {$_.SchemaClassName -eq 'user'} | where {$_.Name -eq '" + accountName + "'} | Foreach-Object {$_.Groups() | Foreach-Object {$_.GetType().InvokeMember(\"Name\", 'GetProperty', $null, $_, $null)} }";
                PowerShellInstance.AddScript(command);
                
                Collection<PSObject> PSOutput = PowerShellInstance.Invoke();
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (PSObject outputItem in PSOutput)
                {
                    values.Add(new StringEvaluationObjectAdapter(outputItem.BaseObject.ToString()));
                }
            }
            return new ExecutionResult(this.Evaluations.Evaluate(values));
        }
    }
}

