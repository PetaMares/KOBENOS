using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace kobenos.classes
{
    /// <summary>
    /// Zkontroluje, zda je hodnot spravny pocet.
    /// </summary>
    [XmlRoot("exactCount")]
    public class ExactValuesCountEvaluation : AbstractEvaluation
    {
        [XmlAttribute]
        public int count;

        public override EvaluationResult Evaluate(EvaluationInputValues values)
        {
            bool result = values.Count == this.count;
            string message = result ? "OK" : String.Format("Values count is {0}, but expected count is {1}.", values.Count, this.count);
            return new EvaluationResult(result, message);
        }

    }
}
