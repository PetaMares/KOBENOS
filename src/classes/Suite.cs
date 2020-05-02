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
        [XmlArrayItem(typeof(WmiCheck), ElementName = "wmi")]
        [XmlArrayItem(typeof(Suite), ElementName = "suite")]
        public List<AbstractCheck> checks = new List<AbstractCheck>();

        protected override ExecutionResult internalExecute()
        {
            bool result = true;

            // provedeni vsech testu
            foreach (AbstractCheck check in this.checks)
            {
                check.execute();
                result = result && check.result.isSuccessful;
            }
            return new ExecutionResult(result);
        }

    }
}
