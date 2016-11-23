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
        private int shiftValue = 3;

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
        public void encode()
        {

        }

        // Decode method.
        public void decode()
        {

        }
    }
}
