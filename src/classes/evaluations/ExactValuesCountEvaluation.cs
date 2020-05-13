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

        public override EvaluationResult Evaluate(List<IEvaluationObject> values)
        {
            bool result = values.Count == this.count;
            string message = result ? "OK" : String.Format("Chyba bezpečnostního nastavení- nebyla tedy správně nastavena bezpečnostní doporučení. Pokud se tato vlastnost v systému správně nastaví, konfigurační soubor ji dokáže najít a překontrolovat. Values count is {0}, but expected count is {1}.", values.Count, this.count);
            return new EvaluationResult(result, message);
        }

    }
}
