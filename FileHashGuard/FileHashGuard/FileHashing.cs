using System;
using System.IO;
using System.Security.Cryptography;

/*
 *  By Vallejo Juan Marcos
 *
 *  * */

namespace FileHashGuard
{
    internal enum EncryptionMethod
    {
        SHA256,
        MD5
    }
    public static class FileHashing
    {
        private static string _hash;
        private static string _path;

        public static string Hash { get => _path; }
        public static string Path { get => _path; }

        /// <summary>
        /// Generates a new hash.
        /// </summary>
        /// <param name="filePath">To encrypt file path.</param>
        /// <param name="encryptionMethod">Encryption method</param>
        /// <returns></returns>
        private static string EncodeFile(string filePath, EncryptionMethod encryptionMethod)
        {
            try
            {
                switch (encryptionMethod)
                {
                    case EncryptionMethod.SHA256:

                        using (SHA256 Sha256 = SHA256.Create())
                        using (FileStream stream = File.OpenRead(Path))
                            _hash = Sha256.ComputeHash(stream).ToString();

                        break;
                    case EncryptionMethod.MD5:

                        using (var md5 = MD5.Create())
                        using (var stream = File.OpenRead(Path))
                            _hash = md5.ComputeHash(stream).ToString();

                        break;
                }
                return _hash;
            }
            catch (Exception)
            {
                throw new Exception("Error encrypting the specified file.");
            }
        }
    }
}
