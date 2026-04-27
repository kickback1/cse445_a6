using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5DLL
{
    public class HashHelper
    {
        // this takes a string and returns its SHA256 hash
        public static string GetHash(string input)
        {
            // create SHA256 object
            SHA256 sha = SHA256.Create();

            // turn input into bytes and hash it
            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(input));


            StringBuilder sb = new StringBuilder();


            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            // return the final hash string
            return sb.ToString();
        }
    }
}