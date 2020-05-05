using System;
using System.Collections.Generic;
using System.Text;

namespace kobenos.classes
{
    /**
     * Vysledek kontroly ocekavanych hodnot.
     */
    public class EvaluationResult
    {
        private readonly bool isCompliant;

        private readonly string message;

        public EvaluationResult(bool isCompliant, string message)
        {
            this.isCompliant = isCompliant;
            this.message = message;
        }

        public bool IsCompliant
        {
            get
            {
                return this.isCompliant;
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }
        }
    }
}
