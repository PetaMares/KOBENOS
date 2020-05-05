using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace kobenos.classes
{

    /// <summary>
    /// Zkontroluje hodnotu prvni polozky v kolekci vysledku pomoci regularnich vyrazu.
    /// </summary>
    [XmlRoot("first")]    
    public class FirstValueRegExEvaluation : MinValuesCountEvaluation
    {

        [XmlAttribute]
        public string value;

        public FirstValueRegExEvaluation() : base(1)
        {

        }

        public override EvaluationResult Evaluate(EvaluationInputValues values)
        {
            EvaluationResult evalCountResult = base.Evaluate(values);
            if (evalCountResult.IsCompliant)
            {
                string actualValue = values[0];
                Regex regex = new Regex(this.value, RegexOptions.Compiled);
                bool result = regex.IsMatch(actualValue);
                string message = result ? "OK" : String.Format("Value {0} doesn't match regular expression {1}.", actualValue, this.value);
                return new EvaluationResult(result, message);
            } else
            {
                return evalCountResult;
            }
        }
    }
}
