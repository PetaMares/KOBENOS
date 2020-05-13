using System;
using System.Collections.Generic;
using System.Text;

namespace kobenos.classes
{
    public abstract class SimpleCheck : AbstractCheck
    {
        public override List<AbstractCheck> GetAllChecksToExecute() {
            List<AbstractCheck> list = new List<AbstractCheck>();
            list.Add(this);
            return list;
        }
        
    }
}
