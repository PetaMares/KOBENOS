using System;
using System.Collections.Generic;
using System.Text;

namespace kobenos.category
{
    abstract class AbstractNode : INode
    {
        protected string id;
        public string name { get; set; }
        protected string description;

        public abstract bool execute();
        public abstract bool fixSetting();

        public string getDescription()
        {
            return description;
        }

        public string getId()
        {
            return id;
        }

        public string getName()
        {
            return name;
        }

        public abstract bool? getResult();
    }
}
