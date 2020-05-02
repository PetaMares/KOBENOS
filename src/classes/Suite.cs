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
        public List<AbstractCheck> Checks { get => checks; set => checks = value; }

        protected override ExecutionResult internalExecute()
        {
            bool result = true;

            // provedeni vsech testu
            foreach (AbstractCheck check in this.Checks)
            {
                check.execute();
                result = result && check.Result.IsSuccessful;
            }
            return new ExecutionResult(result);
        }

    }
}
