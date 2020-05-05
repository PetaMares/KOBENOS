using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace kobenos.classes
{
    /// <summary>
    /// Abstraktni trida, od ktere jsou odvozena vsechna vyhodnoceni dotazu na WMI.
    /// </summary>
    public abstract class AbstractObjectEvaluation
    {
        
        public abstract EvaluationResult Evaluate(EvaluationInputValues values);

    }
}
