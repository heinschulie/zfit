using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Cryptography;

namespace Zephry
{
    /// <summary>
    ///   Scrabble class.
    /// </summary>
    /// <remarks>
    ///   namespace Zephry.
    /// </remarks>
    public static class Scrabble
    {
        #region Mixit
        /// <summary>
        ///   Scrabbles the specified a string.
        /// </summary>
        /// <param name="aString">A string.</param>
        /// <param name="aKey">A key.</param>
        /// <param name="aIV">A IV.</param>
        /// <returns></returns>
        public static byte[] Mixit(string aString, byte[] aKey, byte[] aIV)
        {
            if (aString == null || aString.Length <= 0)
                throw new ArgumentNullException("aString");
            if (aKey == null || aKey.Length <= 0)
                throw new ArgumentNullException("aKey");
            if (aIV == null || aIV.Length <= 0)
                throw new ArgumentNullException("aIV");

            byte[] _mixed;

            using (var vRijndael = Rijndael.Create())
            {
                vRijndael.Key = aKey;
                vRijndael.IV = aIV;

                using (var vICryptoTransform = vRijndael.CreateEncryptor(vRijndael.Key, vRijndael.IV))
                {
                    using (var vMemoryStream = new MemoryStream())
                    {
                        using (var vCryptoStream = new CryptoStream(vMemoryStream, vICryptoTransform, CryptoStreamMode.Write))
                        {
                            using (var vStreamWriter = new StreamWriter(vCryptoStream))
                            {
                                vStreamWriter.Write(aString);
                            }
                            _mixed = vMemoryStream.ToArray();
                        }
                    }
                }
            }
            return _mixed;
        }
        #endregion

        #region Fixit
        /// <summary>
        ///   Unscrabbles the specified a byte array.
        /// </summary>
        /// <param name="aByteArray">A byte array.</param>
        /// <param name="aKey">A key.</param>
        /// <param name="aIV">A IV.</param>
        /// <returns></returns>
        public static string Fixit(byte[] aByteArray, byte[] aKey, byte[] aIV)
        {
            if (aByteArray == null || aByteArray.Length <= 0)
                throw new ArgumentNullException("aByteArray");
            if (aKey == null || aKey.Length <= 0)
                throw new ArgumentNullException("aKey");
            if (aIV == null || aIV.Length <= 0)
                throw new ArgumentNullException("aIV");

            string _fixed = null;

            using (var vRijndael = Rijndael.Create())
            {
                vRijndael.Key = aKey;
                vRijndael.IV = aIV;

                using (var vICryptoTransform = vRijndael.CreateDecryptor(vRijndael.Key, vRijndael.IV))
                {
                    using (var vMemoryStream = new MemoryStream(aByteArray))
                    {
                        using (var vCryptoStream = new CryptoStream(vMemoryStream, vICryptoTransform, CryptoStreamMode.Read))
                        {
                            using (var vStreamReader = new StreamReader(vCryptoStream))
                            {
                                _fixed = vStreamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            return _fixed;
        }
        #endregion
    }
}
