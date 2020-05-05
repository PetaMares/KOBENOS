using System;
using System.Collections.Generic;
using System.Text;

namespace kobenos.classes
{
    /// <summary>
    /// Abstraktni trida, od ktere jsou odvozena vsechna vyhodnoceni vyslednych hodnot.
    /// </summary>
    public abstract class AbstractEvaluation
    {
        
        public abstract EvaluationResult Evaluate(EvaluationInputValues values);

    }
}
