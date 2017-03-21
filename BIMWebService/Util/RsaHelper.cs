using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BIMWebService.Util
{
    public static class RsaHelper
    {
        private static readonly int Keysize = 1024*2;

        public static Dictionary<string, string> CreateKeyPair()
        {
            var keyPair = new Dictionary<string, string>();
            var provider = new RSACryptoServiceProvider(Keysize);
            keyPair.Add("public", provider.ToXmlString(false));
            keyPair.Add("private", provider.ToXmlString(true));
            return keyPair;
        }

        public static string Encrypt(string publicKey, string data)
        {
            using (var rsaProvider = new RSACryptoServiceProvider(Keysize))
            {
                rsaProvider.FromXmlString(publicKey);
                var mainData = Encoding.UTF8.GetBytes(data);
                string encryptData = null;
                //分段加密
                var encryptBlockSize = rsaProvider.KeySize/8 - 11; //加密块最大长度限制
                if (mainData.Length <= encryptBlockSize)
                {
                    encryptData = Convert.ToBase64String(rsaProvider.Encrypt(mainData, false));
                }
                else
                {
                    using (var mainDataStream = new MemoryStream(mainData))
                    using (var encryptDataStream = new MemoryStream())
                    {
                        var buffer = new byte[encryptBlockSize];
                        var blockSize = mainDataStream.Read(buffer, 0, encryptBlockSize);
                        while (blockSize > 0)
                        {
                            var tempMainData = new byte[blockSize];
                            Array.Copy(buffer, 0, tempMainData, 0, blockSize);
                            var encryptStr = rsaProvider.Encrypt(tempMainData, false);
                            encryptDataStream.Write(encryptStr, 0, encryptStr.Length);
                            blockSize = mainDataStream.Read(buffer, 0, encryptBlockSize);
                        }
                        encryptData = Convert.ToBase64String(encryptDataStream.ToArray(),
                            Base64FormattingOptions.None);
                    }
                }
                return encryptData;
            }
        }

        public static string Decrypt(string privateKey, string data)
        {
            using (var rsaProvider = new RSACryptoServiceProvider(Keysize))
            {
                rsaProvider.FromXmlString(privateKey);
                string decryptData = null;
                var dncrypteBlockSize = rsaProvider.KeySize/8;
                var resultData = Convert.FromBase64String(data);
                if (resultData.Length <= dncrypteBlockSize)
                {
                    decryptData = Encoding.UTF8.GetString(rsaProvider.Decrypt(resultData, false));
                }
                else
                {
                    using (var resultDataStream = new MemoryStream(resultData))
                    using (var decryptDataStream = new MemoryStream())
                    {
                        var buffer = new byte[dncrypteBlockSize];
                        var blockSize = resultDataStream.Read(buffer, 0, dncrypteBlockSize);
                        while (blockSize > 0)
                        {
                            var tempResultData = new byte[blockSize];
                            Array.Copy(buffer, 0, tempResultData, 0, blockSize);
                            var decrypt = rsaProvider.Decrypt(tempResultData, false);
                            decryptDataStream.Write(decrypt, 0, decrypt.Length);
                            blockSize = resultDataStream.Read(buffer, 0, dncrypteBlockSize);
                        }
                        decryptData = Encoding.UTF8.GetString(decryptDataStream.ToArray());
                    }
                }
                return decryptData;
            }
        }
    }
}