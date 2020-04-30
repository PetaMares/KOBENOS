using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace kobenos.category.test
{
    abstract class AbstractTest : AbstractNode, ITest
    {
        private bool? result;

        public bool? Result { get => result; set => result = value; }

        public string State
        {
            get
            {
                if(result == null)
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
