using System;
using System.Security.Cryptography;
using System.Text;

namespace KYC.MVC
{
    public class Helpers
    {
        public static Byte[] sha256_hash(String value) 
        {
            //StringBuilder Sb = new StringBuilder();
            
            using (SHA256 hash = SHA256Managed.Create()) 
            {
                Encoding enc = Encoding.UTF8;
                return hash.ComputeHash(enc.GetBytes(value));
                //Byte[] result = hash.ComputeHash(enc.GetBytes(value));
                
                // foreach (Byte b in result)
                //   Sb.Append(b.ToString("x2"));
            }
                
            //return Sb.ToString();
        }
    }
}
