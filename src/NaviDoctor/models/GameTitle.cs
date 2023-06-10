using NaviDoctor.extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NaviDoctor
{
    public static class GameTitle
    {
        public enum Title
        {
            [StringValue("Mega Man Battle Network")]
            MegaManBattleNetwork,
            [StringValue("Mega Man Battle Network 2")]
            MegaManBattleNetwork2,
            [StringValue("Mega Man Battle Network 3: White")]
            MegaManBattleNetwork3White,
            [StringValue("Mega Man Battle Network 3: Blue")]
            MegaManBattleNetwork3Blue,
            [StringValue("Mega Man Battle Network 4: Red Sun")]
            MegaManBattleNetwork4RedSun,
            [StringValue("Mega Man Battle Network 4: Blue Moon")]
            MegaManBattleNetwork4BlueMoon,
            [StringValue("Mega Man Battle Network 5: Team Protoman")]
            MegaManBattleNetwork5TeamProtoman,
            [StringValue("Mega Man Battle Network 5: Team Colonel")]
            MegaManBattleNetwork5TeamColonel,
            [StringValue("Mega Man Battle Network 6: Cybeast Gregar")]
            MegaManBattleNetwork6CybeastGregar,
            [StringValue("Mega Man Battle Network 6: Cybeast Falzar")]
            MegaManBattleNetwork6CybeastFalzar
        }

        public static string GetGameTitle(this Enum value)
        {
            Type type = value.GetType();

            FieldInfo fieldInfo = type.GetField(value.ToString());

            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }
    }


}
