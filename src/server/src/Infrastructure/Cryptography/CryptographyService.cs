using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using GitNode.Application.Common.Interfaces;
using GitNode.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace GitNode.Infrastructure.Cryptography
{
    internal class CryptographyService : ICryptography
    {
        private readonly IOptions<CryptographyOptions> _options;

        public CryptographyService(IOptions<CryptographyOptions> options)
        {
            _options = options;
        }
        
        public string Encrypt(string text)
        {
            var iv = new byte[16];
            byte[] array;
            
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(_options.Value.PrivateKey);
                aes.IV = iv;
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                
                using (var ms = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(text);
                        }

                        array = ms.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }  
  
        public string Decrypt(string text)
        {
            var iv = new byte[16];
            var buffer = Convert.FromBase64String(text);

            using var aes = Aes.Create();
            
            aes.Key = Encoding.UTF8.GetBytes(_options.Value.PrivateKey);
            aes.IV = iv;
            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using var ms = new MemoryStream(buffer);
            using var cryptoStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cryptoStream);
            
            return sr.ReadToEnd();
        }
    }
}
