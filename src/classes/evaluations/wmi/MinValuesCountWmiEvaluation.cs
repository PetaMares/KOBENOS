using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace kobenos.classes
{
    /// <summary>
    /// Zkontroluje, zda je hodnot alespon minimalni pocet.
    /// </summary>
    public class MinValuesCountWmiEvaluation : AbstractWmiEvaluation
    {
        private readonly int count;

        public MinValuesCountWmiEvaluation(int count) {
            this.count = count;
        }

        public override EvaluationResult Evaluate(ManagementObjectCollection values)
        {
            bool result = values.Count >= this.count;
            string message = result ? "OK" : String.Format("Result object count is {0}, but expected minimal count is {1}.", values.Count, this.count);
            return new EvaluationResult(result, message);
        }

    }
}
