using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayanShafagh.Windows.Froms.Vaidation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class RangeAttribute : Attribute
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public RangeAttribute(int min, int max)
        {
            this.Max = max;
            this.Min = min;
        }
    }
}
