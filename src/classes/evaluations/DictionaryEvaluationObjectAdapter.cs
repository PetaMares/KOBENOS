using System;
using System.Collections.Generic;
using System.Text;

namespace kobenos.classes
{
    class DictionaryEvaluationObjectAdapter : IEvaluationObject
    {
        private Dictionary<string, string> dictionary;

        public DictionaryEvaluationObjectAdapter(Dictionary<string, string> dictionary)
        {
            this.dictionary = dictionary;
        }

        public string GetProperty(string name)
        {
            return this.dictionary[name];
        }
    }
}
