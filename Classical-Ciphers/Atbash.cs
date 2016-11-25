using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classical_Ciphers
{
    class Atbash
    {
        // Processed data.
        public byte[] data;

        // Default constructor.
        public Atbash()
        {

        }

        // Encode using the Atbash Cipher.
        public void encode(byte[] inputData)
        {
            char c;
            char[] charData;
            int charCase;
            int newChar;

            charData = Encoding.UTF8.GetChars(inputData);
            data = new byte[inputData.Length];

            for (int i = 0; i < inputData.Length; i++)
            {
                c = charData[i];
                charCase = checkAlpha(c);

                // Handle Upper-case character.
                if (charCase == 1)
                {
                    newChar = 90 - (c - 65);
                }
                // Handle Lower-case character.
                else if (charCase == 2)
                {
                    newChar = 122 - (c - 97);
                }
                // Not an alphabet, do not perform shift.
                else
                {
                    newChar = c;
                }

                data[i] = (byte)(newChar & 0X000000FF);
            }
        }

        // Decode using the Atbash Cipher.
        public void decode(byte[] inputData)
        {
            char c;
            char[] charData;
            int charCase;
            int newChar;

            charData = Encoding.UTF8.GetChars(inputData);
            data = new byte[inputData.Length];

            for (int i = 0; i < inputData.Length; i++)
            {
                c = charData[i];
                charCase = checkAlpha(c);

                // Handle Upper-case character.
                if (charCase == 1)
                {
                    newChar = (90 - c) + 65;
                }
                // Handle Lower-case character.
                else if (charCase == 2)
                {
                    newChar = (122 - c) + 97;
                }
                // Not an alphabet, do not perform shift.
                else
                {
                    newChar = c;
                }

                data[i] = (byte)(newChar & 0X000000FF);
            }
        }

        // Check if ASCII character is an alphabet.
        public int checkAlpha(char alpha)
        {
            // Upper-case character.
            // 'A' = 65, 'Z' = 90
            if ((alpha >= 65) && (alpha <= 90))
            {
                return 1;
            }

            // Lower-case character.
            // 'a' = 97, 'z' = 122
            else if ((alpha >= 97) && (alpha <= 122))
            {
                return 2;
            }

            return 0;
        }
    }
}
