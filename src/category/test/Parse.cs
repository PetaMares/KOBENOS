using System;
using System.Collections.Generic;
using System.Text;

namespace kobenos.category.test
{
    public class Parse
    {
        bool SysAcc = false;
        bool EvAu = false;
        bool RegVal = false;

        public List<string> listSystemAccess = new List<string>();
        public List<string> listEventAudit = new List<string>();
        public List<string> listRegistryValues = new List<string>();

        public bool MinimumPasswordAge = false;
        public bool MaximumPasswordAge = false;
        public bool MinimumPasswordLength = false;

        List<string> EventAudit = new List<string>{
            "AuditSystemEvents",
            "AuditLogonEvents",
            "AuditObjectAccess",
            "AuditPrivilegeUse",
            "AuditPolicyChange",
            "AuditAccountManage",
            "AuditProcessTracking",
            "AuditDSAccess",
            "AuditAccountLogon"
        };
        public void ReadText()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\siman\Desktop\blabla.txt");

            foreach (string line in lines)
            {
                if (line.Contains("[System Access]"))
                {
                    SysAcc = true;
                }
                if (line.Contains("[Event Audit]"))
                {
                    SysAcc = false;
                    EvAu = true;
                }
                if (line.Contains("[Registry Values]"))
                {
                    SysAcc = false;
                    EvAu = false;
                    RegVal = true;
                }
                

                if(SysAcc)
                {
                    listSystemAccess.Add(line);
                }
                if (EvAu)
                {
                    listEventAudit.Add(line);
                }
                if (RegVal)
                {
                    listRegistryValues.Add(line);
                }
            }
        }

        public Dictionary<string, string> SplitLine(List<string> ListValues)
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            foreach (var item in ListValues)
            {
                var test = item.Split('=');
                if (test.Length > 1)
                {
                    keyValues.Add(test[0].Trim(), test[1].Trim());
                }
            }
            return keyValues;
        }

        public void ParseText(List<string> ReadedText, List<string> ListForCompare)
        {
            var dic = SplitLine(ReadedText);
            bool result = false;
            SystemAccess system = new SystemAccess();
            
            foreach (var item in dic)
            {
                if (ListForCompare.Contains(item.Key) == true)
                {
                    switch (item.Key)
                    {
                        case "MinimumPasswordAge":
                            MinimumPasswordAge = system.MinimumPasswordAge(item.Value);
                            break;
                        case "MaximumPasswordAge":
                            MaximumPasswordAge = system.MaximumPasswordAge(item.Value);
                            break;
                        case "MinimumPasswordLength":
                            MinimumPasswordLength = system.MinimumPasswordLength(item.Value);
                            break;
                        default:
                            break;
                    }
                    //var val = item.Value;
                }
                else
                {
                    //var badVal = item.Value;
                }
            }
        }

        public void ParseTextSystemAccess(List<string> listReadedKeys, List<string> listKeys)
        { 
        }

            public void Execute()
        {
            //ps script na vytažení potřebných věcí a uložení do souboru

            //přečtení hodnot z uloženého sobuoru
            ReadText();
            //jednotlivé parsování částí soboru podle sekcí ze souboru
            //ParseText(listSystemAccess, SystemAccess);
            ParseText(listEventAudit, EventAudit);
            //ParseText(listRegistryValues, );
        }
    }
}
