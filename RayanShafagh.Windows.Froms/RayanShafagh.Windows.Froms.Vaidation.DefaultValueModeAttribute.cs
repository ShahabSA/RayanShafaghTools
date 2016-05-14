using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayanShafagh.Windows.Froms.Vaidation
{
    public class DefaultValueModeAttribute:Attribute
    {
        public DefaultValueMode Mode { get; private set; }

        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
        public DefaultValueModeAttribute(DefaultValueMode mode)
        {
            this.Mode = mode;
        }
    }
}
