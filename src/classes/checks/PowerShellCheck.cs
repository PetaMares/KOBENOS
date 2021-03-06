﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Management;
using System.Management.Automation;
using System.Text;
using System.Xml.Serialization;

namespace kobenos.classes
{

    [XmlRoot("powershell")]
    public class PowerShellCheck: SimpleCheck
    {

        public string command;

        protected override ExecutionResult internalExecute()
        {
            var values = new List<IEvaluationObject>();
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {               
                PowerShellInstance.AddScript(this.command);
                Collection<PSObject> PSOutput = PowerShellInstance.Invoke();
                foreach (PSObject outputItem in PSOutput)
                {
                    if (outputItem != null)
                    {
                        values.Add(new StringEvaluationObjectAdapter(outputItem.BaseObject.ToString()));
                    }
                }
            }
            return new ExecutionResult(this.Evaluations.Evaluate(values));
        }
            
    }
}
