using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayanShafagh.SecurityProvider.Encryption
{
    public class StringPack
    {
        public string InputData { get; private set; }
        public string Key { get; private set; }

        public StringPack(string inputData,string key)
        {
            this.InputData = inputData;
            this.Key = key;
        }
    }
}
