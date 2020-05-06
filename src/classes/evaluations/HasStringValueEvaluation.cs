using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace kobenos.classes
{
    [XmlRoot("hasString")]
    public class HasStringValueEvaluation : AbstractEvaluation
    {
        [XmlAttribute]
        public string value;

        public override EvaluationResult Evaluate(EvaluationInputValues values)
        {
            bool result = values
                .OfType<StringEvaluationObjectAdapter>()
                .Select(evalValue => evalValue.GetProperty(default))
                .Any(strValue => strValue == value);
            return new EvaluationResult(
                result,
                result ? "OK" : $"Value '{value}' was not present");
        }
    }
}
