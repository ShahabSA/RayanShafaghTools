using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RayanShafagh.SecurityProvider.Encryption
{


    /// <summary>
    /// Static class which provides methods and logic for Hash & Salt functionality.
    /// This class is provided by Rayan Shafagh Software Group 2015
    /// Author :        Shahab Sari Aslani
    /// Modified Date:  july 29, 2015
    /// </summary>
    public static class Hash
    {

        /// <summary>
        /// Generates random salt byte array, with random length between 15 and 20 characters
        /// </summary>
        /// <returns>System.Array which represents byte array containing random salt value</returns>
        public static byte[] GenerateSalt()
        {
            const int MinSize = 15;
            const int MaxSize = 20;


            return GenerateSalt(MinSize, MaxSize);
        }

        /// <summary>
        /// Generates random salt byte array, with random character length between MinSize and MaxSize provided as input parameter values
        /// </summary>
        /// <param name="MinSize">A System.Int32 which indicates minimum size (length) of output salt array</param>
        /// <param name="MaxSize">A System.Int32 which indicates maximum size (length) of output salt array</param>
        /// <returns>A System.Array which indicates byte array containing random salt value</returns>
        public static byte[] GenerateSalt(int MinSize, int MaxSize)
        {
            byte[] salt = null;
            Random r = new Random();
            salt = new byte[r.Next(MinSize, MaxSize)];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(salt);
            return salt;
        }

        /// <summary>
        /// Generates hash value of input byte array
        /// </summary>
        /// <param name="PlainBytes">A System.Array which indicates input byte array which hash is to be computed</param>
        /// <param name="Algorithm">A SecurityProvider.HashAlgorithm which indicates HashAlgorithm value to indicate desired hash algorithm to be used</param>
        /// <returns>A System.Array which indicates byte array containing computed hash value of input byte array</returns>
        public static byte[] ComputeHash(byte[] PlainBytes, HashAlgorithm Algorithm)
        {

            System.Security.Cryptography.HashAlgorithm hash = null;
            switch (Algorithm)
            {
                case HashAlgorithm.SHA1:
                    hash = new SHA1Managed();
                    break;
                case HashAlgorithm.SHA256:
                    hash = new SHA256Managed();
                    break;
                case HashAlgorithm.SHA384:
                    hash = new SHA384Managed();
                    break;
                case HashAlgorithm.SHA512:
                    hash = new SHA512Managed();
                    break;
                case HashAlgorithm.MD5:
                    hash = new MD5CryptoServiceProvider();
                    break;
                default:
                    hash = new SHA512Managed();
                    break;
            }
            byte[] HashedBytes = hash.ComputeHash(PlainBytes);
            return HashedBytes;
        }

        /// <summary>
        /// This method computes hash value based on given algorithm for given plain text using given input salt bytes, if input salt byte is null, it generates a random salt byte with random length between 15 and 20 byes...
        /// </summary>
        /// <param name="PlainText">A System.String which indicates plain text to be hashed</param>
        /// <param name="SaltByte">A System.Array which indicates input salt byte. if null value supplied, it generates a random salt byte array with ramdom length between 6 and 10 bytes.</param>
        /// <param name="Algorithm">A SecurityProvider.HashAlgorithm HashAlgorithm value to indicate desired hash algorithm to be used</param>
        /// <returns>A RayanShafagh.SecurityProvider.HashPack which contains hash bytes, hash string, salt bytes, salt string and HashAlgorithm used for hashing</returns>
        public static HashPack ComputeHash(string PlainText, byte[] SaltByte, HashAlgorithm Algorithm)
        {
            if (SaltByte == null)
            {
                SaltByte = GenerateSalt();
            }
            byte[] PlainBytes = UnicodeStringToByte(PlainText);
            byte[] PlainAndSaltBytes = new byte[PlainBytes.Length + SaltByte.Length];

            PlainBytes.CopyTo(PlainAndSaltBytes, 0);
            SaltByte.CopyTo(PlainAndSaltBytes, PlainBytes.Length);

            byte[] Hash = ComputeHash(PlainAndSaltBytes, Algorithm);
            byte[] HashSalt = new byte[Hash.Length + SaltByte.Length];
            Hash.CopyTo(HashSalt, 0);
            SaltByte.CopyTo(HashSalt, Hash.Length);
            //return HashSalt;
            return new HashPack(HashSalt, Algorithm);
        }

        /// <summary>
        /// This method computes hash value based on given algorithm for given plain text, it also generates a random saly byte with random size...
        /// </summary>
        /// <param name="PlainText">A System.String which indicates plain text to be hashed</param>
        /// <param name="SlatMinSize">A System.Int32 which indicates minimum salt size in bytes</param>
        /// <param name="SaltMaxSize">A System.Int32 which indicates maximum salt size in bytes</param>
        /// <param name="Algorithm">A SecurityProvider.HashAlgorithm which indicates HashAlgorithm value to indicate desired hash algorithm to be used</param>
        /// <returns>A RayanShafagh.SecurityProvider.HashPack which contains hash bytes, hash string, salt bytes, salt string and HashAlgorithm used for hashing</returns>
        public static HashPack ComputeHash(string PlainText, int SlatMinSize, int SaltMaxSize, HashAlgorithm Algorithm)
        {

            byte[] SaltByte = GenerateSalt(SlatMinSize, SaltMaxSize);

            byte[] PlainBytes = UnicodeStringToByte(PlainText);
            byte[] PlainAndSaltBytes = new byte[PlainBytes.Length + SaltByte.Length];

            PlainBytes.CopyTo(PlainAndSaltBytes, 0);
            SaltByte.CopyTo(PlainAndSaltBytes, PlainBytes.Length);

            byte[] Hash = ComputeHash(PlainAndSaltBytes, Algorithm);
            byte[] HashSalt = new byte[Hash.Length + SaltByte.Length];
            Hash.CopyTo(HashSalt, 0);
            SaltByte.CopyTo(HashSalt, Hash.Length);
            //return HashSalt;
            return new HashPack(HashSalt, Algorithm);
        }

        /// <summary>
        /// Extracts hash byte from hash + salt byte based on hash algorithm
        /// </summary>
        /// <param name="HashAndSlatByte">A System.Array which indicates array of bytes which is a mixture of password hash bytes + salt bytes</param>
        /// <param name="Algorithm">A SecurityProvider.HashAlgorithm which indicates HashAlgorithm value to indicate desired hash algorithm to be used</param>
        /// <returns>A System.Array which indicates byte array which contains hash byte of computed hash + salt</returns>
        public static byte[] GetHashBytes(byte[] HashAndSlatByte, HashAlgorithm Algorithm)
        {
            int hashSize = ((int)Algorithm) / 8;
            byte[] HashBytes = new byte[hashSize];
            for (int i = 0; i < HashBytes.Length; i++)
            {
                HashBytes[i] = HashAndSlatByte[i];
            }
            return HashBytes;
        }

        /// <summary>
        /// Extracts salt byte from hash + salt byte based on hash algorithm
        /// </summary>
        /// <param name="HashAndSlatByte">A System.Array which indicates array of bytes which is a mixture of password hash bytes + salt bytes</param>
        /// <param name="Algorithm">A SecurityProvider.HashAlgorithm which indicates HashAlgorithm value to indicate desired hash algorithm to be used</param>
        /// <returns>A System.Array which indicates byte array which contains salt byte of computed hash + salt</returns>
        public static byte[] GetSaltBytes(byte[] HashAndSlatByte, HashAlgorithm Algorithm)
        {
            int hashSize = ((int)Algorithm) / 8;
            byte[] SaltBytes = new byte[HashAndSlatByte.Length - hashSize];
            for (int i = 0; i < HashAndSlatByte.Length - hashSize; i++)
            {
                SaltBytes[i] = HashAndSlatByte[hashSize + i];
            }
            return SaltBytes;
        }

        /// <summary>
        /// Converts string to unicode byte array
        /// </summary>
        /// <param name="Text">A System.String which indicates input string to be converted</param>
        /// <returns>A System.Byte which indicates converted byte array which contains usnicode byte values based on input string</returns>
        public static byte[] UnicodeStringToByte(string Text)
        {
            UnicodeEncoding enc = new UnicodeEncoding();
            return enc.GetBytes(Text);
            //return Encoding.Unicode.GetBytes(Text);
        }

        /// <summary>
        /// Converts byte array to unicode string
        /// </summary>
        /// <param name="Bytes">A System.Array which indicates input array to be converted</param>
        /// <returns>A System.String which indicates unicode string based on input byte array values</returns>
        public static string ByteToUnicodeString(byte[] Bytes)
        {
            UnicodeEncoding enc = new UnicodeEncoding();
            return enc.GetString(Bytes);
            //return Encoding.Unicode.GetString(Bytes);
        }

    }

}
