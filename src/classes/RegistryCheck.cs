using Microsoft.Win32;
using System;
using System.Xml.Serialization;

namespace kobenos.classes
{
    public class RegistryCheck : AbstractCheck
    {
        [XmlAttribute]
        public string key;

        [XmlAttribute]
        public string value;

        [XmlAttribute]
        public string expected;

        static object GetRegistryValue(string key, string value)
        {
            return Registry.GetValue(key, value, null);
        }

        static string GetRegistryStringValue(string key, string value)
        {
            object regValue = GetRegistryValue(key, value);
            return regValue == null ? "" : (regValue is byte[]) ? ((byte[])regValue)[0].ToString() : regValue.ToString();
        }

        static byte GetRegistryByteValue(string key, string value)
        {
            object regValue = GetRegistryValue(key, value);
            return regValue == null ? (byte)0 : ((byte[])regValue)[0];
        }

        protected override ExecutionResult internalExecute()
        {
            string actualValue = GetRegistryStringValue(this.key, this.value);
            bool result = actualValue.Equals(this.expected);
            string detail = result ? "" : String.Format("Actual value: {0}, expected value: {1}", actualValue, expected);
            return new ExecutionResult(result, detail);
        }
    }
}