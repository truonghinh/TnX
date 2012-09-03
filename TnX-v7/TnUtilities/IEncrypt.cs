using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace TnUtilities
{
    public interface IEncrypt:IDisposable
    {
        string Encrypt(string toEncrypt, string key, bool useHashing);
        string Decrypt(string toDecrypt, string key, bool useHashing);
        void CreateRegistryKey(string path);
        void PutEncryptIntoRegKey(string key_name, string encrypt_value);
        string GetEncryptFromRegKey(string key_name);
        RegistryKey GetCurentRegKey();
    }
}
