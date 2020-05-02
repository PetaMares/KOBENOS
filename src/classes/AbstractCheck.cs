using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace kobenos.classes
{
    public abstract class AbstractCheck
    {
        [XmlAttribute]
        public string name;

        protected ExecutionResult lastResult = new ExecutionResult();

        protected abstract ExecutionResult internalExecute();

        public ExecutionResult execute()
        {
            this.lastResult = this.internalExecute();
            return this.lastResult;
        }

        public ExecutionResult result
        {
            get
            {
                return lastResult;
            }
        }
    }
}
