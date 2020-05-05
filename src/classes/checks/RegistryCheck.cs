using Microsoft.Win32;
using System;
using System.Xml.Serialization;

namespace kobenos.classes
{
    /// <summary>
    /// Zkontroluje hodnotu z registrů.
    /// </summary>
    public class RegistryCheck : AbstractCheck
    {
        [XmlAttribute]
        public string key;

        [XmlAttribute]
        public string value;

        [XmlArray("eval")]
        [XmlArrayItem(typeof(FirstValueRegExEvaluation), ElementName = "first")]
        [XmlArrayItem(typeof(MinValuesCountEvaluation), ElementName = "min")]
        public Evaluations Evaluations;

        static object GetRegistryValue(string key, string value)
        {
            return Registry.GetValue(key, value, null);
        }

        protected override ExecutionResult internalExecute()
        {
            object regValue = GetRegistryValue(key, value);
            EvaluationInputValues values = new EvaluationInputValues();
            if (regValue != null)
            {
                if (regValue is byte[]) {
                    byte[] bytes = (byte[])regValue;
                    foreach (byte b in bytes)
                    {
                        values.Add(b.ToString());
                    }
                } else {
                    values.Add(regValue.ToString());
                }
            }            
            return new ExecutionResult(this.Evaluations.Evaluate(values));
        }
    }
}