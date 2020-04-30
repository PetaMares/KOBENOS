using kobenos.category.test;
using System;
using System.Collections.Generic;
using System.Text;

namespace kobenos.category
{
    interface ICategory : INode
    {
        IList<AbstractTest> getTests();

        void addTest(AbstractTest test);
    }
}
