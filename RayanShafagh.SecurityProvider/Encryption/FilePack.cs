using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayanShafagh.SecurityProvider.Encryption
{
    public class FilePack
    {
        public string SourceFilePath { get; private set; }
        public string DestinitionFilePath { get; private set; }
        public string Key { get; private set; }

        public FilePack( string sourceFilePath,string destinitionFilePath,string key)
        {
            this.SourceFilePath = sourceFilePath;
            this.DestinitionFilePath = destinitionFilePath;
            this.Key = key;
        }
    }
}
