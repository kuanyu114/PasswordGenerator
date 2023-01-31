using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Policy;
using System.Security.Cryptography;

namespace PasswordGenerator
{
    public class GeneratorPassword
    {
        /// <summary>
        /// 產生密碼包含大小寫,符號,數字
        /// </summary>
        /// <param name="length">密碼長度</param>
        /// <returns></returns>
        public string CreatePassword (int length)
        {
            string[] symbols = new string[] {"~","!","@","#","$","%","^","&","*","?" };
            var random = new Random();
            int randomNum= random.Next(symbols.Length);
            int replaceNum = random.Next(1,length);
            int replaceWord = random.Next(97,122);
            string password = "basePassword"+DateTime.Now.Ticks.ToString();
           
            using (SHA256 mySHA256 = SHA256.Create())
            {
                var byteArray = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(password));
                password = Convert.ToHexString(byteArray);
            }
            
            password = password.Insert(0, Convert.ToChar(replaceWord).ToString()).Remove(1, 1);
            password = password.Remove(replaceNum,1).Insert(replaceNum, symbols[randomNum]);
            
            return password.Substring(0,length);
        }
       
    }
}
