using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ImageGallery
{
    public static class Crypto
    {
        /// <summary>
        /// Для кодировки строки в Base64String типа
        /// </summary>
        /// <param name="value">Строка пароли</param>
        /// <returns>Кодированная строка</returns>
        public static string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value))
                );
        }
    }
}