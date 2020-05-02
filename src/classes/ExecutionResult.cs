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

        public string Color
        {
            get
            {
                if (executionResult == null)
                {
                    return "#DDDD00"; // Color.Yellow;
                }
                else if (executionResult == true)
                {
                    return "#00CD00";// Color.Green;
                }
                else
                {
                    return "#DD0000";// Color.Red;
                }
            }
        }

        public string Details { get => details; set => details = value; }
    }

}
