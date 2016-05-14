using RayanShafagh.SecurityProvider.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayanShafagh.SecurityProvider
{
    public class HashPack
    {
        public byte[] HashBytes { get; private set; }

        public byte[] SaltBytes { get; private set; }

        public string HashString { get; private set; }

        public string SaltString { get; private set; }

        public HashAlgorithm Algorithm { get; private set; }

        public HashPack(byte[] hashBytes, byte[] saltBytes,HashAlgorithm algorithm)
        {
            this.HashBytes = hashBytes;
            this.SaltBytes = saltBytes;
            this.Algorithm = algorithm;
            this.HashString = Hash.ByteToUnicodeString(hashBytes);
            this.SaltString = Hash.ByteToUnicodeString(saltBytes);
        }

        public HashPack(byte[] HashAndSaltBytes, HashAlgorithm algorithm)
            : this(Hash.GetHashBytes(HashAndSaltBytes, algorithm),
                  Hash.GetSaltBytes(HashAndSaltBytes, algorithm),
                  algorithm)
        { }

    }
}
