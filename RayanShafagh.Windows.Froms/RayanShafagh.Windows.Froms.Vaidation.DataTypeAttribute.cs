using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayanShafagh.Windows.Froms.Vaidation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DataTypeAttribute : Attribute
    {
        public Type TargetType { get; private set; }
        public DataTypeAttribute(Type targetType)
        {
            this.TargetType = targetType;
        }
    }
}
