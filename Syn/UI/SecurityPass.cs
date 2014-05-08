using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
namespace UI
{
    public static class SecurityPass
    {
        public static string getMd5(string input)
        {
            //Tạo 1 instance md5
            MD5 md5Hash = MD5.Create();
            // chuyển sang kiểu mảng byte
            byte[] data = md5Hash.ComputeHash(Encoding.Default.GetBytes(input));
            // tạo 1 StringBuiler để lưu lại các byte và tạo 1 string
            StringBuilder sString = new StringBuilder();
            // duyệt qua mảng byte và chuyển qua dạng hexa
            for (int i = 0; i < data.Length; i++)
            {
                sString.Append(data[i].ToString("x2"));
            }
            return sString.ToString();
        }
       public static bool verifyMd5Hash(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = getMd5(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
