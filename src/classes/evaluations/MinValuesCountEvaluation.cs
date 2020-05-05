using System;
using System.Collections.Generic;
using System.Text;

namespace kobenos.classes
{
    /// <summary>
    /// Zkontroluje, zda je hodnot alespon minimalni pocet.
    /// </summary>
    public class MinValuesCountEvaluation : AbstractEvaluation
    {
        private readonly int count;

        public MinValuesCountEvaluation(int count) {
            this.count = count;
        }

        public override EvaluationResult Evaluate(EvaluationInputValues values)
        {
            bool result = values.Count >= this.count;
            string message = result ? "OK" : String.Format("Values count is {0}, but expected minimal count is {1}.", values.Count, this.count);
            return new EvaluationResult(result, message);
        }

    }
}
