using NaviDoctor.extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaviDoctor.models
{
    public class Style
    {
        public enum Value
        {
            [StringValue("Normal")]
            Normal,
            [StringValue("Aqua")]
            Aqua,
            [StringValue("Wood")]
            Wood,
            [StringValue("Heat")]
            Heat,
            [StringValue("AquaGuts")]
            AquaGuts,
            [StringValue("WoodGuts")]
            WoodGuts,
            [StringValue("HeatGuts")]
            HeatGuts,
            [StringValue("ElecGuts")]
            ElecGuts,
            [StringValue("AquaCust")]
            AquaCust,
            [StringValue("WoodCust")]
            WoodCust,
            [StringValue("HeatCust")]
            HeatCust,
            [StringValue("ElecCust")]
            ElecCust,
            [StringValue("AquaTeam")]
            AquaTeam,
            [StringValue("WoodTeam")]
            WoodTeam,
            [StringValue("HeatTeam")]
            HeatTeam,
            [StringValue("ElecTeam")]
            ElecTeam,
            [StringValue("AquaShield")]
            AquaShield,
            [StringValue("WoodShield")]
            WoodShield,
            [StringValue("HeatShield")]
            HeatShield,
            [StringValue("ElecShield")]
            ElecShield,
            [StringValue("Hub")]
            Hub
        }
        public Value Name { get; set; }
        public bool? Add { get; set; }
        public bool? Equip { get; set; }

        public static List<Style> BN1 = new List<Style>
        {
            new Style{Name = Value.Normal},
            new Style{Name = Value.Aqua},
            new Style{Name = Value.Wood},
            new Style{Name = Value.Heat}
        };

        public static List<Style> BN2 = new List<Style>
        {
            new Style{Name = Value.Normal},
            new Style{Name = Value.AquaGuts},
            new Style{Name = Value.WoodGuts},
            new Style{Name = Value.HeatGuts},
            new Style{Name = Value.ElecGuts},
            new Style{Name = Value.AquaCust},
            new Style{Name = Value.WoodCust},
            new Style{Name = Value.HeatCust},
            new Style{Name = Value.ElecCust},
            new Style{Name = Value.AquaTeam},
            new Style{Name = Value.WoodTeam},
            new Style{Name = Value.HeatTeam},
            new Style{Name = Value.ElecTeam},
            new Style{Name = Value.AquaShield},
            new Style{Name = Value.WoodShield},
            new Style{Name = Value.HeatShield},
            new Style{Name = Value.ElecShield},
            new Style{Name = Value.Hub}
        };
    }

}
