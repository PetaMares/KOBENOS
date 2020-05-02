using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace kobenos.category.test
{
    abstract class Result { 

        private bool? executionResult;

        public string getName
        {
            get
            {
                if(executionResult == null)
                {
                    return "Nespuštěný";
                }
                else if(result==true)
                {
                    return "Vyhověl";
                }
                else
                {
                    return "Nevyhověl";
                }
            }
        }

        public string StateColor
        {
            get
            {
                if (result == null)
                {
                    return "#DDDD00"; // Color.Yellow;
                }
                else if (result==true)
                {
                    return "#00DD00";// Color.Green;
                }
                else
                {
                    return "#DD0000";// Color.Red;
                }
            }
        }

        public override bool? getResult()
        {
            return Result;
        }

        public abstract void setConfiguration(string key, string value);
    }
}
