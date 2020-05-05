using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace kobenos.classes
{

    /// <summary>
    /// Zkontroluje hodnotu prvni polozky v kolekci vysledku
    /// </summary>
    [XmlRoot("first")]    
    public class FirstValueRegExWmiEvaluation : MinValuesCountWmiEvaluation
    {
        [XmlAttribute]
        public string property;

        [XmlAttribute]
        public string value;

        public FirstValueRegExWmiEvaluation() : base(1)
        {

        }

        public override EvaluationResult Evaluate(ManagementObjectCollection values)
        {
            EvaluationResult evalCountResult = base.Evaluate(values);
            if (evalCountResult.IsCompliant)
            {
                ManagementObject actualObject = values.OfType<ManagementObject>().FirstOrDefault();
                string actualValue = actualObject.GetPropertyValue(this.property).ToString();
                Regex regex = new Regex(this.value, RegexOptions.Compiled);
                bool result = regex.IsMatch(actualValue);
                string message = result ? "OK" : String.Format("Value of property {0} is '{1}' and that doesn't match regular expression '{2}'.", this.property, actualValue, this.value);
                return new EvaluationResult(result, message);
            }
            else
            {
                return evalCountResult;
            }
        }
    }
}
