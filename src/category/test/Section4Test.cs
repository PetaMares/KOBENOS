﻿using System;
using System.Collections.Generic;
using System.Text;

namespace kobenos.category.test
{
    class Section4Test: AbstractTest
    {
        public Section4Test(string id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        public override bool execute()
        {
            Result = false;
            return false;
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