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
        public HashHelper()
        {
            
         
        }
        public static string CalculeHashSHA256(string pass ,string salt )
        {
            string passWithSalt = ConcatPassWithSalt(pass, salt);
            return ConvertByteArrayToString(SHA256.Create()
                         .ComputeHash(ConvertStrinToByteArray(passWithSalt)));
        }
        public static string ConcatPassWithSalt( string pass,string salt)
        {
            return String.Concat(pass, salt);
        }
        public  static string GenerateSalt32()
        {
            byte[] saltBytes = new byte[32];
            new Random().NextBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }
        public static byte[] ConvertStrinToByteArray(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
        public  static string ConvertByteArrayToString(byte[] array)
        {
            return Encoding.Default.GetString(array);
        }
        public  bool IsEqual(string hash)
        {
            return Hash == hash;
        }
    }
}
