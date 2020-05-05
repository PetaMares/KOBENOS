using System;
using System.Collections.Generic;
using System.Management;
using System.Text;
using System.Xml.Serialization;

namespace kobenos.classes
{
    /**
     * Kolekce "vyhodnoceni" - kontrola ocekavanych povolenych hodnot.
     */
     [XmlRoot("eval")]
    public class WmiEvaluations : List<AbstractWmiEvaluation>
    {

        public EvaluationResult Evaluate(ManagementObjectCollection values)
        {
            // provedeni vsech vyhodnoceni
            foreach (AbstractWmiEvaluation evaluation in this)
            {
                EvaluationResult result = evaluation.Evaluate(values);
                if (!result.IsCompliant)
                {
                    // pri prvnim neuspechu ukoncit a vratit neuspesny vysledek
                    return result;
                }
            }
            
            return new EvaluationResult(true, "OK");
        }
    }
}
