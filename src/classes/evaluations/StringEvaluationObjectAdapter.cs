using System;
using System.Collections.Generic;
using System.Text;

namespace kobenos.classes
{
    class StringEvaluationObjectAdapter : IEvaluationObject
    {
        private string value;

        public StringEvaluationObjectAdapter(string value)
        {
            this.value = value;
        }

        public string GetProperty(string name)
        {
            return this.value;
        }
    }
}
