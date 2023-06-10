using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaviDoctor.extensions
{
    public static class BooleanExtensions
    {
        public static byte ToByte(this bool? value)
        {
            return value.Value ? (byte)1 : (byte)0;
        }
    }
}
