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
        [XmlArrayItem(typeof(OSVersionCheck), ElementName = "os")]
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
