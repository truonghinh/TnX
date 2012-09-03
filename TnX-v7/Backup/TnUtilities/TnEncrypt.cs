using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Security.Cryptography;

namespace TnUtilities
{
    public class TnEncrypt:IEncrypt
    {
        RegistryKey regKey = Registry.CurrentUser;
        
        #region IEncrypt Members

        string IEncrypt.Encrypt(string toEncrypt, string key, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            
        }

        string IEncrypt.Decrypt(string toDecrypt, string key, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        void IEncrypt.CreateRegistryKey(string path)
        {
            regKey.CreateSubKey(path);//--->Software\\tn\\user
        }

        void IEncrypt.PutEncryptIntoRegKey(string key_name, string encrypt_value)
        {
            regKey.SetValue(key_name, encrypt_value);
        }

        string IEncrypt.GetEncryptFromRegKey(string key_name)
        {
            return (String)regKey.GetValue(key_name, "noname");
        }

        RegistryKey IEncrypt.GetCurentRegKey()
        {
            return this.regKey;
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            regKey.Close();
        }

        #endregion

    }
}
