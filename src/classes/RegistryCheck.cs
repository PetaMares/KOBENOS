﻿using Microsoft.Win32;

namespace kobenos.classes
{
    public class RegistryCheck : AbstractCheck
    {
        public string key;
        public string value;
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
            bool result = GetRegistryStringValue(this.key, this.value).Equals(this.expected);
            return new ExecutionResult(result);
        }
    }
}