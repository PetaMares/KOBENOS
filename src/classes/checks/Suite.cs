using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace kobenos.classes
{
    /**
     * Reprezentuje celou sadu testů, která se spouští jako celek.
     */
    [XmlRoot("suite")]
    public class Suite : AbstractCheck
    {

        private List<AbstractCheck> checks = new List<AbstractCheck>();

        [XmlArray("checks")]
        [XmlArrayItem(typeof(Suite), ElementName = "suite")]
        [XmlArrayItem(typeof(WmiCheck), ElementName = "wmi")]        
        [XmlArrayItem(typeof(RegistryCheck), ElementName = "registry")]
        [XmlArrayItem(typeof(PowerShellCheck), ElementName = "powershell")]
        [XmlArrayItem(typeof(SecurityCheck), ElementName = "security")]
        [XmlArrayItem(typeof(SecurityCheckAccount), ElementName = "securityaccount")]
        public List<AbstractCheck> Checks { get => checks; set => checks = value; }
               
        protected override ExecutionResult internalExecute()
        {
            List<AbstractCheck> list = this.GetAllChecksToExecute();
            bool result = true;
            int success = 0;

            // provedeni vsech testu
            foreach (AbstractCheck check in list)
            {
                check.Execute();
                if (check.Result.IsSuccessful)
                {
                    success++;
                }
                result = result && check.Result.IsSuccessful;
            }
            string details = System.String.Format("Úspěšné testy: {0}/{1}", success, list.Count);
            return new ExecutionResult(result, details);
        }

        /// <summary>
        /// aktualizuje vysledek spusteni - to je nutne, pokud jsou podrizene testy spusteny jinak, nez pomoci internal Execute
        /// </summary>
        public void UpdateExecutionResult()
        {
            bool result = true;
            int success = 0;
            int total = 0;

            foreach (AbstractCheck check in this.Checks)
            {
                total += check.GetAllChecksToExecute().Count;

                if (check is Suite)
                {
                    Suite suite = (Suite)check;
                    suite.UpdateExecutionResult();
                    success += suite.Result.SuccessfulChecks;
                } else if (check.Result.IsSuccessful)
                {
                    success++;
                }
                result = result && check.Result.IsSuccessful;

                StartTime =
                    StartTime == default(DateTime)
                    ? check.StartTime
                    : (StartTime < check.StartTime ? StartTime : check.StartTime);
                EndTime = EndTime > check.EndTime ? EndTime : check.EndTime;
            }
            string details = System.String.Format("Úspěšné testy: {0}/{1}", success, total);
            this.lastResult = new ExecutionResult(result, details, success);
        }

        public override List<AbstractCheck> GetAllChecksToExecute()
        {
            List<AbstractCheck> list = new List<AbstractCheck>();
            foreach (AbstractCheck check in this.Checks)
            {
                list.AddRange(check.GetAllChecksToExecute());
            }
            return list;           
        }
    }
}
