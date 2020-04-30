using kobenos.category.configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace kobenos.category
{
    interface INode
    {
        string getId();
        string getName();
        string getDescription();
        bool execute();
        bool fixSetting();
        bool? getResult();
    }
}
