using System;
using System.Collections.Generic;
using System.Text;

namespace kobenos.category.test
{
    interface ITest : INode
    {
        void setConfiguration(string key, string value);
    }
}
