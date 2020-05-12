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
    [XmlRoot("num")]
    public class NumericEvaluation : MinValuesCountEvaluation
    {

        [XmlAttribute]
        public string property;

        [XmlAttribute]
        public string value;

        public NumericEvaluation() : base(1)
        {

        }

        public override EvaluationResult Evaluate(List<IEvaluationObject> values)
        {
            var evalCountResult = base.Evaluate(values);
            if (evalCountResult.IsCompliant)
            {
                if (int.TryParse(values[0].GetProperty(this.property), out int actualValue))
                {
                    /*
                     * mozne hodnoty
                     * <12
                     * <=12
                     * >12
                     * >=12
                     * =12
                     * <>12
                     */
                    Regex regex = new Regex("(?<operator>(<|<=|>|>=|=|<>))(?<value>\\d+)", RegexOptions.Compiled);
                    Match m = regex.Match(value.Replace(" ", ""));

                    if (m.Success)
                    {
                        int targetValue = int.Parse(m.Groups["value"].Value);
                        bool result = false;

                        switch (m.Groups["operator"].Value)
                        {
                            case "<":
                                result = actualValue < targetValue;
                                break;
                            case "<=":
                                result = actualValue <= targetValue;
                                break;
                            case ">":
                                result = actualValue > targetValue;
                                break;
                            case ">=":
                                result = actualValue >= targetValue;
                                break;
                            case "=":
                                result = actualValue == targetValue;
                                break;
                            case "<>":
                                result = actualValue != targetValue;
                                break;
                            default:
                                break;
                        }

                        string message = result ? "OK" : String.Format("Současná hodnota nastavená v systému: '{0}' neodpovídá doporučené hodnotě v konfiguračním souboru: '{1}'.", actualValue, this.value);
                        return new EvaluationResult(result, message);
                    }
                    else
                        return new EvaluationResult(false, String.Format("Spatne zadana podminka ve value                    tavena bezpečnostní doporučení. Pokud se tato vlastnost v systému správně nastaví, konfigurační soubor ji dokáže najít a překontrolovat.", this.property));
                }
                else
                {
                    return new EvaluationResult(false, String.Format("Tato vlastnost: '{0}' nebyla v systému nalezena- nebyla tedy správně nastavena bezpečnostní doporučení. Pokud se tato vlastnost v systému správně nastaví, konfigurační soubor ji dokáže najít a překontrolovat.", this.property));
                }
            }
            else
            {
                return evalCountResult;
            }
        }
    }
}
