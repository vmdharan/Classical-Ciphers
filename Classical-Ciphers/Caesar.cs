using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classical_Ciphers
{
    // Implement the Caesar Cipher.
    class Caesar
    {
        // Default shift value for the Caesar Cipher.
        protected int shiftValue = 3;

        // Processed data.
        public byte[] data;

        // Default constructor.
        public Caesar()
        {
            // No shift value provided, so use the default shift value.
        }

        // Alternative constructor, when a specific shift value is provided.
        public Caesar(int shift)
        {
            // Do sanity checking of the shift value, and clamp it to the English 
            // alphabet length of 26.
            if(shift > 25)
            {
                shiftValue = 25;
            }
            else if(shift < 0)
            {
                shiftValue = 0;
            }
            else
            {
                // Save the shift value to use with the Cipher.
                shiftValue = shift;
            }
        }

        // Encode method.
        public void encode(byte[] inputData)
        {
            char c;
            char[] charData;
            int charCase;
            int newChar;

            charData = Encoding.UTF8.GetChars(inputData);
            data = new byte[inputData.Length];

            for(int i=0; i<inputData.Length; i++)
            {
                c = charData[i];
                charCase = checkAlpha(c);
                
                // Handle Upper-case character.
                if(charCase == 1)
                {
                    newChar = c + shiftValue;
                    if(newChar > 90)
                    {
                        newChar -= 26;
                    }
                }
                // Handle Lower-case character.
                else if(charCase == 2)
                {
                    newChar = c + shiftValue;
                    if (newChar > 122)
                    {
                        newChar -= 26;
                    }
                }
                // Not an alphabet, do not perform shift.
                else
                {
                    newChar = c;
                }

                data[i] = (byte) (newChar & 0X000000FF);
            }
        }

        // Decode method.
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
                    newChar = c - shiftValue;
                    if (newChar < 65)
                    {
                        newChar += 26;
                    }
                }
                // Handle Lower-case character.
                else if (charCase == 2)
                {
                    newChar = c - shiftValue;
                    if (newChar < 97)
                    {
                        newChar += 26;
                    }
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
            if((alpha >= 65) && (alpha <= 90))
            {
                return 1;
            }

            // Lower-case character.
            // 'a' = 97, 'z' = 122
            else if((alpha >= 97) && (alpha <= 122))
            {
                return 2;
            }

            return 0;
        }
    }
}
