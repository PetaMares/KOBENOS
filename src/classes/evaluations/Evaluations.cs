using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace kobenos.classes
{
    /**
     * Kolekce "vyhodnoceni" - kontrola ocekavanych povolenych hodnot.
     */
     [XmlRoot("eval")]
    public class Evaluations : List<AbstractEvaluation>
    {
        public EvaluationResult Evaluate(List<IEvaluationObject> values)
        {
            // provedeni vsech vyhodnoceni
            foreach (AbstractEvaluation evaluation in this)
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
