using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayanShafagh.SecurityProvider.Encryption
{
    public class EnctyptionEventArgs:EventArgs
    {
        public string Data { get; private set; }
        public bool IsFilePath { get; private set; }

        public EnctyptionEventArgs(string data,bool isFilePath = false)
        {
            this.Data = data;
            this.IsFilePath = isFilePath;
        }

    }
}
