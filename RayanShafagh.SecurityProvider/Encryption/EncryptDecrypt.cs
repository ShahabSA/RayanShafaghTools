using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Threading;

namespace RayanShafagh.SecurityProvider.Encryption
{
    /// <summary>
    /// provides static methods for encrypting & decrypting files & strings using a key string
    /// and instance member to support encryption over threading 
    /// NOTE: if event handler for ProcessComplete event of current instance is not set, 
    ///       calling instance methods will result in process failure event or throwing exception...
    /// </summary>
    public class EncryptDecrypt
    {
        #region Static Members

        /// <summary>
        /// Decrypts file using key string
        /// </summary>
        /// <param name="sourceFile">A System.String which represents full path to source file</param>
        /// <param name="destinationFile">A System.String which represents full path to destinition file</param>
        /// <param name="key">A System.String which represents key used for decryption</param>
        /// <returns>A System.Boolean which indicates if file has been decrypted successfully</returns>
        public static bool FileDecrypt(string sourceFile, string destinationFile, string key)
        {
            try
            {
                //----- Create file streams.
                var sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
                var destinationStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write);

                //----- Convert key string to 32-byte key array.
                byte[] keyBytes = Encoding.UTF8.GetBytes(GetHashMD5(key));

                //----- Create initialization vector.
                byte[] IV = new byte[] { 50, 199, 10, 159, 132, 55, 236, 189,
                        51, 243, 244, 91, 17, 136, 39, 230};

                //----- Create a Rijndael engine.
                var rijndael = new RijndaelManaged();

                //----- Create the cryptography transform.
                ICryptoTransform cryptoTransform = rijndael.CreateDecryptor(keyBytes, IV);

                //----- Bytes will be processed by  CryptoStream.
                var cryptoStream = new CryptoStream(destinationStream, cryptoTransform, CryptoStreamMode.Write);

                //----- Process bytes from one file into the other.
                const int BlockSize = 4096;
                byte[] buffer = new byte[BlockSize];
                int bytesRead;
                do
                {
                    bytesRead = sourceStream.Read(buffer, 0, BlockSize);
                    if (bytesRead == 0) break;
                    cryptoStream.Write(buffer, 0, bytesRead);
                } while (true);

                //----- Close the streams.
                cryptoStream.Close();
                sourceStream.Close();
                destinationStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Encrypts file using key string
        /// </summary>
        /// <param name="sourceFile">A System.String which represents full path to source file</param>
        /// <param name="destinationFile">A System.String which represents full path to destinition file</param>
        /// <param name="key">A System.String which represents key used for encryption</param>
        /// <returns>A System.Boolean which indicates if file has been encrypted successfully</returns>
        public static bool FileEncrypt(string sourceFile, string destinationFile, string key)
        {
            try
            {
                //----- Create file streams.
                var sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
                var destinationStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write);

                //----- Convert key string to 32-byte key array.
                var keyBytes = Encoding.UTF8.GetBytes(GetHashMD5(key));

                //----- Create initialization vector.
                var IV = new byte[] { 50, 199, 10, 159, 132, 55, 236, 189, 51, 243, 244, 91, 17, 136, 39, 230 };

                //----- Create a Rijndael engine.
                var rijndael = new RijndaelManaged();

                //----- Create the  cryptography transform.
                ICryptoTransform cryptoTransform = rijndael.CreateEncryptor(keyBytes, IV);

                //----- Bytes will be processed by CryptoStream.
                var cryptoStream = new CryptoStream(destinationStream, cryptoTransform, CryptoStreamMode.Write);

                //----- Process bytes from one file into the other.
                const int BlockSize = 4096;
                byte[] buffer = new byte[BlockSize];
                int bytesRead;
                do
                {
                    bytesRead = sourceStream.Read(buffer, 0, BlockSize);
                    if (bytesRead == 0) break;
                    cryptoStream.Write(buffer, 0, bytesRead);

                } while (true);


                //----- Close the streams.
                cryptoStream.Close();
                sourceStream.Close();
                destinationStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// returns hash value for input string using MD5Managed
        /// </summary>
        /// <param name="plainText">A System.String which represents data to hash</param>
        /// <returns>A System.String which represents hash value of input string</returns>
        public static string GetHashMD5(string plainText)
        {
            //----- Generate a hash. return an empty string
            //      if there are any problems.
            byte[] plainBytes;
            MD5CryptoServiceProvider hashEngine;
            byte[] hashBytes;
            string hashText;

            try
            {
                //----- Convert the plain text to a byte array.
                plainBytes = Encoding.UTF8.GetBytes(plainText);

                //----- Select one of the hash engines.
                hashEngine = new MD5CryptoServiceProvider();

                //----- Get the hash of the plain text bytes.
                hashBytes = hashEngine.ComputeHash(plainBytes);

                //----- Convert the hash bytes to a hexadecimal string.
                hashText = BitConverter.ToString(hashBytes).Replace("-", "");
                return hashText;
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// Generates SHA1 Hash value for input string and returns Hash value as System.String
        /// </summary>
        /// <param name="input">A System.String which represents data to be hashed</param>
        /// <returns>SHA1 Hash of input as System.String</returns>
        public static string GetSHA1Hash(string input)
        {
            var encrypter = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            using (var sw = new StringWriter())
            {
                foreach (byte b in encrypter.ComputeHash(Encoding.UTF8.GetBytes(input)))
                    sw.Write(b.ToString("x2"));
                return sw.ToString();
            }
        }


        /// <summary>
        /// Encrypts a unicode text using a key string, or returns null if process fails
        /// </summary>
        /// <param name="plainText">A System.String which represents input text to be encrypted</param>
        /// <param name="key">A System.String which represents key used for input data encryption</param>
        /// <returns>A System.String which represents encrypted form on of input data</returns>
        public static string StringEncrypt(string plainText, string key)
        {
            //----- Encrypt some text. return an empty string
            //      if there are any problems.
            string keyText = key;
            try
            {   //----- Remove any possible null characters.
                string workText = plainText.Replace("\0", "");

                //----- Convert plain text to byte array.
                byte[] workBytes = Encoding.UTF8.GetBytes(plainText);

                //----- Convert key string to 32-byte key array.
                byte[] keyBytes = Encoding.UTF8.GetBytes(GetHashMD5(keyText));

                //----- Create initialization vector.
                byte[] IV = new byte[] { 50, 199, 10, 159, 132, 55, 236, 189, 51, 243, 244, 91, 17, 136, 39, 230 };

                //----- Create the Rijndael engine.
                var rijndael = new RijndaelManaged();

                //----- Bytes will flow through a memory stream.
                var memoryStream = new MemoryStream();

                //----- Create the  cryptography transform.
                ICryptoTransform cryptoTransform = rijndael.CreateEncryptor(keyBytes, IV);

                //----- Bytes will be processed by CryptoStream.
                var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);

                //----- Move the bytes through the processing stream.
                cryptoStream.Write(workBytes, 0, workBytes.Length);
                cryptoStream.FlushFinalBlock();

                //----- Convert binary data to a viewable string.
                string encrypted = Convert.ToBase64String(memoryStream.ToArray());

                //----- Close the streams.
                memoryStream.Close();
                cryptoStream.Close();

                //----- return the encrypted string result.
                return encrypted;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Decrypts a unicode text using a key string, or returns null if process fails
        /// </summary>
        /// <param name="encryptedText">A System.String which represents encrypted input text to be decrypted</param>
        /// <param name="key">A System.String which represents key used for input data encryption</param>
        /// <returns>A System.String which represents decrypted form on of input data</returns>
        public static string StringDecrypt(string encryptedText, string key)
        {
            //----- Decrypt a previously encrypted string. The key
            //      must match the one used to encrypt the string.
            //      return an empty string on error.
            string keyText = key;
            try
            {
                //----- Convert encrypted string to a byte array.
                byte[] workBytes = Convert.FromBase64String(encryptedText);

                //----- Convert key string to 32-byte key array.
                byte[] keyBytes = Encoding.UTF8.GetBytes(GetHashMD5(keyText));

                //----- Create initialization vector.
                byte[] IV = new byte[] { 50, 199, 10, 159, 132, 55, 236, 189, 51, 243, 244, 91, 17, 136, 39, 230 };

                //----- Decrypted bytes will be stored in
                //      a temporary array.
                byte[] tempBytes = new byte[workBytes.Length - 1];

                //----- Create the Rijndael engine.
                var rijndael = new RijndaelManaged();

                //----- Bytes will flow through a memory stream.
                var memoryStream = new MemoryStream(workBytes);

                //----- Create the  cryptography transform.
                ICryptoTransform cryptoTransform = rijndael.CreateDecryptor(keyBytes, IV);

                //----- Bytes will be processed by CryptoStream.
                var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read);

                //----- Move the bytes through the processing stream.
                cryptoStream.Read(tempBytes, 0, tempBytes.Length);

                //----- Close the streams.
                memoryStream.Close();
                cryptoStream.Close();

                //----- Convert the decrypted bytes to a string.
                string plainText = Encoding.UTF8.GetString(tempBytes);

                //----- return the decrypted string result.
                return plainText.Replace("\0", "");
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        //this part is designed for Threading support
        #region Instance Members

        public event ProcessCompletedDelegate ProcessCompleted;

        public event ProcessFailedDelegate ProcessFailed;


        /// <summary>
        /// Decrypts a file using a key string and saves result into given destination file path and raises ProcessCompleted event to notify process completion
        /// </summary>
        /// <param name="inputFilePack">A System.Object which wraps a FilePack instance that contains paths to source & destination files and key string for encryption/decryption</param>
        public void FileDecrypt(object inputFilePack)
        {
            CheckProcessCompletedEventHandler();

            lock (this)
            {

                string sourceFile, destinationFile, key;

                try
                {
                    var data = (FilePack)inputFilePack;
                    sourceFile = data.SourceFilePath;
                    destinationFile = data.DestinitionFilePath;
                    key = data.Key;
                }
                catch (Exception ex)
                {

                    if (ProcessFailed != null)
                    {
                        ProcessFailed(this, new UnhandledExceptionEventArgs(ex, false));
                        return;
                    }
                    else
                    {
                        throw new InvalidCastException("input data is not an instance of FilePack class");
                    }
                }


                try
                {
                    //----- Create file streams.
                    var sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
                    var destinationStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write);

                    //----- Convert key string to 32-byte key array.
                    byte[] keyBytes = Encoding.UTF8.GetBytes(GetHashMD5(key));

                    //----- Create initialization vector.
                    byte[] IV = new byte[] { 50, 199, 10, 159, 132, 55, 236, 189,
                        51, 243, 244, 91, 17, 136, 39, 230};

                    //----- Create a Rijndael engine.
                    var rijndael = new RijndaelManaged();

                    //----- Create the cryptography transform.
                    ICryptoTransform cryptoTransform = rijndael.CreateDecryptor(keyBytes, IV);

                    //----- Bytes will be processed by  CryptoStream.
                    var cryptoStream = new CryptoStream(destinationStream, cryptoTransform, CryptoStreamMode.Write);

                    //----- Process bytes from one file into the other.
                    const int BlockSize = 4096;
                    byte[] buffer = new byte[BlockSize];
                    int bytesRead;
                    do
                    {
                        bytesRead = sourceStream.Read(buffer, 0, BlockSize);
                        if (bytesRead == 0) break;
                        cryptoStream.Write(buffer, 0, bytesRead);
                    } while (true);

                    //----- Close the streams.
                    cryptoStream.Close();
                    sourceStream.Close();
                    destinationStream.Close();

                    ProcessCompleted(this, new EnctyptionEventArgs(destinationFile, true));

                }
                catch (Exception ex)
                {

                    if (ProcessFailed != null)
                    {
                        ProcessFailed(this, new UnhandledExceptionEventArgs(ex, false));
                    }
                    else
                    {
                        throw new InvalidOperationException("File encryption failed, please see inner exception", ex);
                    }

                }
            }
        }

        /// <summary>
        /// Encrypts a file using a key string and saves result into given destination file path and raises ProcessCompleted event to notify process completion
        /// </summary>
        /// <param name="inputFilePack">A System.Object which wraps a FilePack instance that contains paths to source & destination files and key string for encryption/decryption</param>
        public void FileEncrypt(object inputFilePack)
        {
            CheckProcessCompletedEventHandler();

            lock (this)
            {
                string sourceFile, destinationFile, key;


                try
                {
                    var data = (FilePack)inputFilePack;
                    sourceFile = data.SourceFilePath;
                    destinationFile = data.DestinitionFilePath;
                    key = data.Key;
                }
                catch (Exception ex)
                {
                    if (ProcessFailed != null)
                    {
                        ProcessFailed(this, new UnhandledExceptionEventArgs(ex, false));
                        return;
                    }
                    else
                    {
                        throw new InvalidCastException("input data is not an instance of FilePack class");
                    }
                }

                try
                {
                    //----- Create file streams.
                    var sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
                    var destinationStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write);

                    //----- Convert key string to 32-byte key array.
                    var keyBytes = Encoding.UTF8.GetBytes(GetHashMD5(key));

                    //----- Create initialization vector.
                    var IV = new byte[] { 50, 199, 10, 159, 132, 55, 236, 189, 51, 243, 244, 91, 17, 136, 39, 230 };

                    //----- Create a Rijndael engine.
                    var rijndael = new RijndaelManaged();

                    //----- Create the  cryptography transform.
                    ICryptoTransform cryptoTransform = rijndael.CreateEncryptor(keyBytes, IV);

                    //----- Bytes will be processed by CryptoStream.
                    var cryptoStream = new CryptoStream(destinationStream, cryptoTransform, CryptoStreamMode.Write);

                    //----- Process bytes from one file into the other.
                    const int BlockSize = 4096;
                    byte[] buffer = new byte[BlockSize];
                    int bytesRead;
                    do
                    {
                        bytesRead = sourceStream.Read(buffer, 0, BlockSize);
                        if (bytesRead == 0) break;
                        cryptoStream.Write(buffer, 0, bytesRead);

                    } while (true);


                    //----- Close the streams.
                    cryptoStream.Close();
                    sourceStream.Close();
                    destinationStream.Close();

                    ProcessCompleted(this, new EnctyptionEventArgs(destinationFile, true));

                }
                catch (Exception ex)
                {

                    if (ProcessFailed != null)
                    {
                        ProcessFailed(this, new UnhandledExceptionEventArgs(ex, false));
                    }
                    else
                    {
                        throw new InvalidOperationException("File decryption failed, please see inner exception", ex);
                    }
                }
            }
        }

        /// <summary>
        /// Hashes an input text using a MD5Managed and raises ProcessCompleted event to notify process completion
        /// </summary>
        /// <param name="inputText">A System.Object which wraps a System.String instance that contains orignal text to be hashed</param>
        public void GetHashMD5(object inputText)
        {
            CheckProcessCompletedEventHandler();

            lock (this)
            {
                if (inputText.GetType() != typeof(string))
                {
                    throw new InvalidCastException("input data is not an instance of System.String.");
                }

                string plainText = inputText.ToString();

                //----- Generate a hash. return an empty string
                //      if there are any problems.
                byte[] plainBytes;
                MD5CryptoServiceProvider hashEngine;
                byte[] hashBytes;
                string hashText;

                try
                {
                    //----- Convert the plain text to a byte array.
                    plainBytes = Encoding.UTF8.GetBytes(plainText);

                    //----- Select one of the hash engines.
                    hashEngine = new MD5CryptoServiceProvider();

                    //----- Get the hash of the plain text bytes.
                    hashBytes = hashEngine.ComputeHash(plainBytes);

                    //----- Convert the hash bytes to a hexadecimal string.
                    hashText = BitConverter.ToString(hashBytes).Replace("-", "");

                    ProcessCompleted(this, new EnctyptionEventArgs(hashText));

                }
                catch (Exception)
                {
                    ProcessCompleted(this, new EnctyptionEventArgs(null));
                }
            }
        }

        /// <summary>
        /// Encrypts a unicode text and raises ProcessCompleted event to notify process completion
        /// </summary>
        /// <param name="inputStringPack">A System.Object which wraps a StringPack instance that contains original string and key string for encryption/decryption</param>
        public void StringEncrypt(object inputStringPack)
        {
            CheckProcessCompletedEventHandler();

            lock (this)
            {
                string keyText, plainText;
                try
                {
                    var data = (StringPack)inputStringPack;
                    keyText = data.Key;
                    plainText = data.InputData;
                }
                catch (Exception ex)
                {
                    if (ProcessFailed != null)
                    {
                        ProcessFailed(this, new UnhandledExceptionEventArgs(ex, false));
                        return;
                    }
                    else
                    {
                        throw new InvalidCastException("input data is not an instance of StringPack class");
                    }
                }
                //----- Encrypt some text. return an empty string
                //      if there are any problems.

                try
                {   //----- Remove any possible null characters.
                    string workText = plainText.Replace("\0", "");

                    //----- Convert plain text to byte array.
                    byte[] workBytes = Encoding.UTF8.GetBytes(plainText);

                    //----- Convert key string to 32-byte key array.
                    byte[] keyBytes = Encoding.UTF8.GetBytes(GetHashMD5(keyText));

                    //----- Create initialization vector.
                    byte[] IV = new byte[] { 50, 199, 10, 159, 132, 55, 236, 189, 51, 243, 244, 91, 17, 136, 39, 230 };

                    //----- Create the Rijndael engine.
                    var rijndael = new RijndaelManaged();

                    //----- Bytes will flow through a memory stream.
                    var memoryStream = new MemoryStream();

                    //----- Create the  cryptography transform.
                    ICryptoTransform cryptoTransform = rijndael.CreateEncryptor(keyBytes, IV);

                    //----- Bytes will be processed by CryptoStream.
                    var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);

                    //----- Move the bytes through the processing stream.
                    cryptoStream.Write(workBytes, 0, workBytes.Length);
                    cryptoStream.FlushFinalBlock();

                    //----- Convert binary data to a viewable string.
                    string encrypted = Convert.ToBase64String(memoryStream.ToArray());

                    //----- Close the streams.
                    memoryStream.Close();
                    cryptoStream.Close();

                    //----- return the encrypted string result.
                    ProcessCompleted(this, new EnctyptionEventArgs(encrypted));
                }
                catch (Exception)
                {
                    ProcessCompleted(this, new EnctyptionEventArgs(null));
                }
            }
        }

        /// <summary>
        /// Decrypts a unicode text and raises ProcessCompleted event to notify process completion
        /// </summary>
        /// <param name="inputStringPack">A System.Object which wraps a StringPack instance that contains original string and key string for encryption/decryption</param>
        public void StringDecrypt(object inputStringPack)
        {
            CheckProcessCompletedEventHandler();

            lock (this)
            {
                string keyText, encryptedText;
                try
                {
                    var data = (StringPack)inputStringPack;
                    keyText = data.Key;
                    encryptedText = data.InputData;
                }
                catch (Exception ex)
                {
                    if (ProcessFailed != null)
                    {
                        ProcessFailed(this, new UnhandledExceptionEventArgs(ex, false));
                        return;
                    }
                    else
                    {
                        throw new InvalidCastException("input data is not an instance of StringPack class");
                    }
                }
                //----- Decrypt a previously encrypted string. The key
                //      must match the one used to encrypt the string.
                //      return an empty string on error.
                try
                {
                    //----- Convert encrypted string to a byte array.
                    byte[] workBytes = Convert.FromBase64String(encryptedText);

                    //----- Convert key string to 32-byte key array.
                    byte[] keyBytes = Encoding.UTF8.GetBytes(GetHashMD5(keyText));

                    //----- Create initialization vector.
                    byte[] IV = new byte[] { 50, 199, 10, 159, 132, 55, 236, 189, 51, 243, 244, 91, 17, 136, 39, 230 };

                    //----- Decrypted bytes will be stored in
                    //      a temporary array.
                    byte[] tempBytes = new byte[workBytes.Length - 1];

                    //----- Create the Rijndael engine.
                    var rijndael = new RijndaelManaged();

                    //----- Bytes will flow through a memory stream.
                    var memoryStream = new MemoryStream(workBytes);

                    //----- Create the  cryptography transform.
                    ICryptoTransform cryptoTransform = rijndael.CreateDecryptor(keyBytes, IV);

                    //----- Bytes will be processed by CryptoStream.
                    var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read);

                    //----- Move the bytes through the processing stream.
                    cryptoStream.Read(tempBytes, 0, tempBytes.Length);

                    //----- Close the streams.
                    memoryStream.Close();
                    cryptoStream.Close();

                    //----- Convert the decrypted bytes to a string.
                    string plainText = Encoding.UTF8.GetString(tempBytes);

                    //----- return the decrypted string result.
                    ProcessCompleted(this, new EnctyptionEventArgs(plainText.Replace("\0", "")));
                }
                catch (Exception)
                {
                    ProcessCompleted(this, new EnctyptionEventArgs(null));
                }
            }
        }

        private void CheckProcessCompletedEventHandler()
        {
            if (ProcessCompleted == null)
            {
                throw new InvalidOperationException("Event handler for ProcessCompleted event should be set in order to start encryption or decryption process");
            }
        }

        #endregion
    }
}
