using System;
using System.Collections.Generic;
using System.Text;

namespace kobenos.category.test
{
    class Section31Test: AbstractTest
    {
        public Section31Test(string id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        public override bool execute()
        {
            return true;
            //throw new NotImplementedException();
        }

        public override bool fixSetting()
        {
            return true;
            //throw new NotImplementedException();
        }

        public override void setConfiguration(string key, string value)
        {
            //throw new NotImplementedException();
        }
    }
}
