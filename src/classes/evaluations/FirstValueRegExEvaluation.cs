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
        public string property;

        [XmlAttribute]
        public string value;

        public FirstValueRegExEvaluation() : base(1)
        {

        }

        public override EvaluationResult Evaluate(List<IEvaluationObject> values)
        {
            var evalCountResult = base.Evaluate(values);
            if (evalCountResult.IsCompliant)
            {
                string actualValue = values[0].GetProperty(this.property);
                if (actualValue != null)
                {
                    Regex regex = new Regex(this.value, RegexOptions.Compiled);
                    bool result = regex.IsMatch(actualValue);
                    string message = result ? "OK" : String.Format("Současná hodnota nastavená v systému: '{0}' neodpovídá doporučené hodnotě v konfiguračním souboru: '{1}'.", actualValue, this.value);
                    return new EvaluationResult(result, message);
                }
                else 
                {
                    return new EvaluationResult(false, String.Format("Tato vlastnost: '{0}' nebyla v systému nalezena- nebyla tedy správně nastavena bezpečnostní doporučení. Pokud se tato vlastnost v systému správně nastaví, konfigurační soubor ji dokáže najít a překontrolovat.", this.property));
                }
            } else
            {
                return evalCountResult;
            }
        }
    }
}
