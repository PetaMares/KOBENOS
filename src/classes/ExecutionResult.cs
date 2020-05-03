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

        public ExecutionResult(bool? executionResult, string details)
        {
            this.executionResult = executionResult;
            this.details = details;
        }

        public ExecutionResult(bool? executionResult)
        {
            this.executionResult = executionResult;
            this.details = "";
        }

        public ExecutionResult()
        {
            this.executionResult = null;
            this.details = "";
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
