using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayanShafagh.Windows.Forms
{
    internal class NameDialogResultPack
    {
        public string Name { get; private set; }
        public DialogResult Result { get; private set; }
        public NameDialogResultPack(string name, DialogResult result)
        {
            Name = name;
            Result = result;
        }
    }
}
