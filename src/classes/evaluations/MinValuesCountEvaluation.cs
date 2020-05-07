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
            string message = result ? "OK" : String.Format("Chyba bezpečnostního nastavení. Cesta k parametru v počítači nebyla nalezena- nebyla tedy správně nastavena bezpečnostní doporučení. Pokud se tato vlastnost v systému správně nastaví, konfigurační soubor ji dokáže najít a překontrolovat. Values count is {0}, but expected minimal count is {1}.", values.Count, this.count);
            return new EvaluationResult(result, message);
        }

    }
}
