using System;
using System.Security.Cryptography;
using System.Text;

namespace LibraryManagement.Utils
{
   public static class StringExtension
   {
      public static string Base64Decode(this string strBase64EncodedData)
      {
         return Encoding.UTF8.GetString(Convert.FromBase64String(strBase64EncodedData));
      }

      public static string Base64Encode(this string plainText)
      {
         return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
      }

      /// <summary>
      /// Mã hóa chuỗi theo MD5
      /// </summary>
      /// <param name="plainText">Chuỗi cần mã hóa</param>
      /// <returns>Chuỗi đã mã hóa theo MD5 có 32 ký tự</returns>
      public static string ToMD5Hash(this string plainText)
      {
         StringBuilder hash = new StringBuilder();
         MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
         byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(plainText));

         for (int i = 0; i < bytes.Length; i++)
         {
            hash.Append(bytes[i].ToString("x2"));
         }
         return hash.ToString();
      }

      /// <summary>
      /// Gọi hàm <see cref="string.Trim()"/>, kiểm tra null trước khi gọi
      /// </summary>
      /// <param name="str"></param>
      /// <returns></returns>
      public static string TrimCheck(this string str)
      {
         if (string.IsNullOrEmpty(str)) { return ""; }
         else { return str.Trim(); }
      }

      public static string RemoveNonDigit(this string str)
      {
         if (string.IsNullOrEmpty(str)) { return ""; }
         else
         {
            for (int i = str.Length - 1; i >= 0; i--)
            {
               if (!char.IsDigit(str, i)) { str = str.Remove(i, 1); }
            }
            return str;
         }
      }
   }
}
