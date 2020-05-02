using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace kobenos.classes
{
    /**
     * Reprezentuje vysledek spustitelne kontroly.
     */
    public class ExecutionResult
    {

        private bool? executionResult;

        public string details;

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

        public bool isExecuted
        {
            get
            {
                return this.executionResult != null;
            }
        }

        public bool isSuccessful
        {
            get
            {
                return this.executionResult == true;
            }
        }

        public string name
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

        public string color
        {
            get
            {
                if (executionResult == null)
                {
                    return "#DDDD00"; // Color.Yellow;
                }
                else if (executionResult == true)
                {
                    return "#00DD00";// Color.Green;
                }
                else
                {
                    return "#DD0000";// Color.Red;
                }
            }
        }

    }

}
