using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FastMoneyBookmaker.Helpers
{
    class HashHelper
    {
        public string Hash { get; set; }
        public string Salt { get; set; }
        public HashHelper(string password)
        {
            var saltBytes = new byte[32];
            new Random().NextBytes(saltBytes);
            Salt = Convert.ToBase64String(saltBytes);
            string passwordAndSalt = String.Concat(password, Salt);
            Hash = ConvertByteArrayToString( SHA256.Create()
                         .ComputeHash(ConvertStrinToByteArray(passwordAndSalt)));
        }
        public byte[] ConvertStrinToByteArray(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
        public string ConvertByteArrayToString(byte[] array)
        {
            return array.ToString();
        }
    }
}
