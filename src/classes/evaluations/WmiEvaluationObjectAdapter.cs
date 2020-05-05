using System;
using System.Collections.Generic;
using System.Management;
using System.Text;
using System.Windows.Media.Media3D;

namespace kobenos.classes
{
    class WmiEvaluationObjectAdapter : IEvaluationObject
    {
        private ManagementObject actualObject;

        public WmiEvaluationObjectAdapter(ManagementObject actualObject)
        {
            this.actualObject = actualObject;
        }

        public string GetProperty(string name)
        {
            object value = this.actualObject.GetPropertyValue(name);
            return value != null ? value.ToString() : null;
        }
    }
}
