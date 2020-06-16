using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Helpers
{
    class PasswordManager
    {
        public string GeneratePasswordHash(string password, out string salt)
        {
            salt = GenerateSalt();
            string passAndSalt = password.Trim() + salt;

            string hash = GetStringHash(passAndSalt.Trim());
            return hash.Trim();
        }

        public bool IsPasswordMatch(string password, string hash, string salt)
        {
            hash.Trim();
            string passAndSalt = password.Trim() + salt;
            string newPassHash = GetStringHash(passAndSalt.Trim());

            if(newPassHash == hash.Trim())
            {
                bool areSame = true;
                return areSame;
            }
            else
            {
                bool areSame = false;
                return areSame;
            }
             

            
            
        } 
# region PrivateMethods
        private string GenerateSalt()
        {
            string salt = "tovaesolza6totodrugotonerabori";
            return salt;
        }

        private string GetStringHash(string passAndSalt)
        {
            SHA256 sha256 = SHA256CryptoServiceProvider.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(passAndSalt);
            byte[] hash = sha256.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();

        }
#endregion
    }
}
