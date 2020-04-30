using System;
using System.Collections.Generic;
using System.Text;

namespace kobenos.classes.test
{
    interface ICheck
    {
        public string getName();

        public CheckResult execute();
    }
}
