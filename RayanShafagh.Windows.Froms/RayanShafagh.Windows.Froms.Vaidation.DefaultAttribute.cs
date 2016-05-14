using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayanShafagh.Windows.Froms.Vaidation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DefaultAttribute<T>  : Attribute
    {
        
        public T Value { get; private set; }

        public DefaultAttribute(T value)
        {
            this.Value = value;
        }
    }
}
