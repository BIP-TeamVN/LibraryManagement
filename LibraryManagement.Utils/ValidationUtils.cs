using System;
using System.Linq;
using System.Net.Mail;

namespace LibraryManagement.Utils
{
   public class ValidationUtils
   {
      public static bool IsEmail(string emailaddress)
      {
         try
         {
            MailAddress m = new MailAddress(emailaddress);
            return true;
         }
         catch (FormatException)
         {
            return false;
         }
      }

      /// <summary>
      /// Kiểm tra số điện thoại
      /// </summary>
      /// <param name="str">Chuỗi cần kiểm tra</param>
      /// <param name="phoneNumberLength">Chiều dài số điện thoại</param>
      /// <param name="escapeCharacter">Các ký tự ngoài số có thể xuất hiện trong số điện thoại</param>
      /// <returns></returns>
      public static bool IsPhoneNumber(string str, int phoneNumberLength = 10, char[] escapeCharacter = null)
      {
         if (string.IsNullOrEmpty(str) || str.Length != phoneNumberLength) { return false; }

         if (escapeCharacter != null)
         {
            for (int i = 0; i < str.Length; i++)
            {
               if (!char.IsDigit(str, i) && !escapeCharacter.Contains(str[i])) { return false; }
            }
         }
         else
         {
            for (int i = 0; i < str.Length; i++)
            {
               if (!char.IsDigit(str, i)) { return false; }
            }
         }

         return true;
      }
   }
}
