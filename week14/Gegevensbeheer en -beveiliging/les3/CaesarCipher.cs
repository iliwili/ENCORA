using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace les3
{
    class CaesarCipher
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een tekst in: ");
            string strInput = Console.ReadLine();

            Console.Write("Geef verschuiving in: ");
            string strVer = Console.ReadLine();

            int intVer;

            while (!int.TryParse(strVer, out intVer))
            {
                Console.Write("Foute input. Probeer nog eens: ");
                strVer = Console.ReadLine();
            }

            string encrpted = Encrypt(strInput, intVer);
            string deEncrypt = Decrypt(encrpted, intVer);

            Console.WriteLine($"Encrypted: {encrpted}");
            Console.WriteLine($"Decrypted: {deEncrypt}");
        }

        static string Encrypt(string s, int offset)
        {
            while (offset < 0) offset += 26;

            char[] buffer = s.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {

                char letter = buffer[i];

                letter = (char)(letter + offset);


                if (letter > 'z')
                {
                    letter = (char)(letter - 26);
                }
                else if (letter < 'a')
                {
                    letter = (char)(letter + 26);
                }

                buffer[i] = letter;
            }

            return new string(buffer);
        }

        static string Decrypt(string s, int offset)
        {
            while (offset < 0) offset -= 26;

            char[] buffer = s.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {

                char letter = buffer[i];

                letter = (char)(letter - offset);

                if (letter > 'z')
                {
                    letter = (char)(letter - 26);
                }
                else if (letter < 'a')
                {
                    letter = (char)(letter - 26);
                }

                buffer[i] = letter;
            }

            return new string(buffer);
        }
    }
}
