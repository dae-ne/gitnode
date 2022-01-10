using System;
using System.Security.Cryptography;
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
            return text;
            // var cipher = CreateCipher(_options.Value.PrivateKey);
            // var iv = Convert.ToBase64String(cipher.IV);
            // cipher.IV = Convert.FromBase64String(iv);
            // var cryptTransform = cipher.CreateEncryptor();
            // var plaintext = Encoding.UTF8.GetBytes(text);
            // var cipherText = cryptTransform.TransformFinalBlock(plaintext, 0, plaintext.Length);
            // return Convert.ToBase64String(cipherText);
        }  
  
        public string Decrypt(string text)
        {
            return text;
            // var cipher = CreateCipher(_options.Value.PrivateKey);
            // var iv = Convert.ToBase64String(cipher.IV);
            // cipher.IV = Convert.FromBase64String(iv);
            // var cryptTransform = cipher.CreateDecryptor();
            // var encryptedBytes = Convert.FromBase64String(text);
            // var plainBytes = cryptTransform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            // return Encoding.UTF8.GetString(plainBytes);
        }

        private static Aes CreateCipher(string keyBase64)
        {
            var cipher = Aes.Create();
            cipher.Mode = CipherMode.CBC;
            cipher.Padding = PaddingMode.ISO10126;
            cipher.Key = Convert.FromBase64String(keyBase64);
            return cipher;
        }
    }
}