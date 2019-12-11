﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace w1626661
{
    class PasswordEncryption
    {
        private const string AesIV256 = @"!QAZ2WSX#EDC4RFV";
        private const string AesKey256 = @"5TGB&YHN7UJM(IK<5TGB&YHN7UJM(IK<";

        public static string encryptPassword(string pw)
        {

            AesCryptoServiceProvider aesCryption = new AesCryptoServiceProvider();
            aesCryption.BlockSize = 128;
            aesCryption.KeySize = 256;
            aesCryption.IV = Encoding.UTF8.GetBytes(AesIV256);
            aesCryption.Key = Encoding.UTF8.GetBytes(AesKey256);
            aesCryption.Mode = CipherMode.CBC;
            aesCryption.Padding = PaddingMode.PKCS7;
            byte[] src = Encoding.Unicode.GetBytes(pw);

            // encryption
            using (ICryptoTransform encrypt = aesCryption.CreateEncryptor())
            {
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

                // Convert byte array to Base64 strings
                return Convert.ToBase64String(dest);
            }
        }

        public static string decryptPassword(string text)
        {
            // AesCryptoServiceProvider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.IV = Encoding.UTF8.GetBytes(AesIV256);
            aes.Key = Encoding.UTF8.GetBytes(AesKey256);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Convert Base64 strings to byte array
            byte[] src = System.Convert.FromBase64String(text);

            // decryption
            using (ICryptoTransform decrypt = aes.CreateDecryptor())
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                return Encoding.Unicode.GetString(dest);
            }
        }
    }
}