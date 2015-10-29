using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgetfulJohny_CodeWars
{
    public static class Mailbox
    {
        public static string Pass(string mail)
        {
            if (String.IsNullOrEmpty(mail))
            {
                return null;
            }

            string mailWithoutEnd = ClearEnd(mail);
            string mailWithSwappedCasing = SwapCasing(mailWithoutEnd);
            string numbersInMail = GetNumbers(mailWithSwappedCasing);
            string lettersInMail = GetLetters(mailWithSwappedCasing);

            string password = numbersInMail + lettersInMail;

            return password;
        }

        //Remove all the symbols after the @ sign
        public static string ClearEnd(string mail)
        {
            string[] parsedMail = mail.Split(new Char[] {'@'});
            return parsedMail[0];
        }

        //Change the casing of all letters
        public static string SwapCasing(string mail)
        {
            Char[] mailToParse = mail.ToCharArray();

            for (int i = 0; i < mailToParse.Length; i++)
            {
                if (Char.IsLower(mailToParse[i]))
                {
                    mailToParse[i] = Char.ToUpper(mailToParse[i]);
                }
                else if (Char.IsUpper(mailToParse[i]))
                {
                    mailToParse[i] = Char.ToLower(mailToParse[i]);
                }
            }

            string parsedMail = new String(mailToParse);

            return parsedMail;
        }

        public static string GetNumbers(string mail)
        {
            string parsedMail = "";

            byte[] ASCIIValues = Encoding.ASCII.GetBytes(mail);
            foreach (byte b in ASCIIValues)
            {
                if (b >= 48 && b <= 57) 
                {
                    parsedMail += Char.ConvertFromUtf32(b);
                }
            }

            return parsedMail;
        }

        public static string GetLetters(string mail)
        {
            string parsedMail = "";

            byte[] ASCIIValues = Encoding.ASCII.GetBytes(mail);
            foreach (byte b in ASCIIValues)
            {
                if ((b >= 65 && b <= 90) || (b >= 97 && b <= 122))
                {
                    parsedMail += Char.ConvertFromUtf32(b);
                }
            }

            return parsedMail;
        }
    }
}

//Johny has to create many mailboxes. He knows all of the email addresses, but forgot all the passwords; But Johny remembers that he hides his passwords within the email address and can be revealed using the following steps:

//1)all symbols after @ must be removed

//2)register of all leters must be changed(uppercase goes to lower and vise versa)

//3)all digits must be moved to the front of the password

//Your work is to help Johny recover all his passwords!

//Example ----> Pass("1johny2@mail.ru")=="12JOHNY"

//Note: if mail is empty return null