using System.Windows.Media;

namespace kobenos.classes
{
    /**
     * Reprezentuje vysledek spustitelne kontroly.
     */
    public class ExecutionResult
    {

        private bool? executionResult;

        private string details;

        private int successfulChecks;

        public ExecutionResult(EvaluationResult evalResult)
        {
            this.executionResult = evalResult.IsCompliant;
            this.details = evalResult.Message;
            this.successfulChecks = evalResult.IsCompliant ? 1 : 0;
        }

        public ExecutionResult(bool? executionResult, string details)
        {
            this.executionResult = executionResult;
            this.details = details;
            this.successfulChecks = executionResult == true ? 1 : 0;
        }

        public ExecutionResult(bool? executionResult, string details, int successfulChecks)
        {
            this.executionResult = executionResult;
            this.details = details;
            this.successfulChecks = successfulChecks;
        }

        public ExecutionResult(bool? executionResult)
        {
            this.executionResult = executionResult;
            this.details = "";
            this.successfulChecks = executionResult == true ? 1 : 0;
        }

        public ExecutionResult()
        {
            this.executionResult = null;
            this.details = "";
            this.successfulChecks = 0;
        }

        public bool IsExecuted
        {
            get
            {
                return this.executionResult != null;
            }
        }

        public bool IsSuccessful
        {
            get
            {
                return this.executionResult == true;
            }
        }

        public int SuccessfulChecks
        {
            get
            {
                return this.successfulChecks;
            }
        }

        public string Name
        {
            get
            {
                if (executionResult == null)
                {
                    return "Nespuštěný";
                }
                else if (executionResult == true)
                {
                    return "Vyhověl";
                }
                else
                {
                    return "Nevyhověl";
                }
            }
        }

        public Brush Color
        {
            get
            {
                if (executionResult == null)
                {
                    return Brushes.Orange;
                }
                else if (executionResult == true)
                {
                    return Brushes.DarkGreen;
                }
                else
                {
                    return Brushes.Red;
                }
            }
        }

        public string Details { get => details; set => details = value; }
    }

}
