using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayanShafagh.Windows.Forms
{
    public static class Utility
    {
        public static IEnumerable<Control> GetAllControls(Control control, Type type, bool OfType = true)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControls(ctrl, type, OfType))
                                      .Concat(controls)
                                      .Where(c => ((c.GetType() == type) ^ OfType));
        }

        public static IEnumerable<Control> GetAllControls(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControls(ctrl))
                                      .Concat(controls);
        }

        public static IEnumerable<Control> GetAllControls(Control.ControlCollection controls)
        {
            var result = controls.Cast<Control>();

            return result.SelectMany(ctrl => GetAllControls(ctrl))
                                      .Concat(result);
        }

		public static IEnumerable<Control> FilterControls(IEnumerable<Control> controls, IEnumerable<Type> typesTpExclude)
        {
            var result = from a in controls
                         where !typesTpExclude.Contains(a.GetType())
                         select a;
            return result;
        }


    }
}
