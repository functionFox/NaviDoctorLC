using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NaviDoctor.extensions
{
    public static class GetEnumString
    {
        public static string GetString(this Enum value)
        {
            Type type = value.GetType();

            FieldInfo fieldInfo = type.GetField(value.ToString());

            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }
    }
}
