using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classical_Ciphers
{
    class ROT13 : Caesar
    {
        public ROT13()
        {
            shiftValue = 13;
        }
    }
}
