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
        [XmlArrayItem(typeof(GpoCheck), ElementName = "gpo")]
        [XmlArrayItem(typeof(PowerShellCheck), ElementName = "powershell")]
        [XmlArrayItem(typeof(SecurityCheck), ElementName = "security")]
        [XmlArrayItem(typeof(SecurityCheckAccount), ElementName = "securityaccount")]
        public List<AbstractCheck> Checks { get => checks; set => checks = value; }

        protected override ExecutionResult internalExecute()
        {
            bool result = true;
            int success = 0;

            // provedeni vsech testu
            foreach (AbstractCheck check in this.Checks)
            {
                check.Execute();
                if (check.Result.IsSuccessful)
                {
                    success++;
                }
                result = result && check.Result.IsSuccessful;
            }
            string details = System.String.Format("{0}/{1}", success, checks.Count);
            return new ExecutionResult(result, details);
        }

    }
}
