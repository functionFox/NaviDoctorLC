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
            Hub,
            [StringValue("AquaGround")]
            AquaGround,
            [StringValue("WoodGround")]
            WoodGround,
            [StringValue("HeatGround")]
            HeatGround,
            [StringValue("ElecGround")]
            ElecGround,
            [StringValue("AquaShadow")]
            AquaShadow,
            [StringValue("WoodShadow")]
            WoodShadow,
            [StringValue("HeatShadow")]
            HeatShadow,
            [StringValue("ElecShadow")]
            ElecShadow,
            [StringValue("AquaBug")]
            AquaBug,
            [StringValue("WoodBug")]
            WoodBug,
            [StringValue("HeatBug")]
            HeatBug,
            [StringValue("ElecBug")]
            ElecBug
        }
        public Value Name { get; set; }
        public bool? Add { get; set; }
        public bool? Equip { get; set; }
        public int? Version { get; set; }
        public GameTitle.Title? VersionExclusive { get; set; }

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
            new Style{Name = Value.AquaGuts, Version = 1},
            new Style{Name = Value.WoodGuts, Version = 1},
            new Style{Name = Value.HeatGuts, Version = 1},
            new Style{Name = Value.ElecGuts, Version = 1},
            new Style{Name = Value.AquaCust, Version = 1},
            new Style{Name = Value.WoodCust, Version = 1},
            new Style{Name = Value.HeatCust, Version = 1},
            new Style{Name = Value.ElecCust, Version = 1},
            new Style{Name = Value.AquaTeam, Version = 1},
            new Style{Name = Value.WoodTeam, Version = 1},
            new Style{Name = Value.HeatTeam, Version = 1},
            new Style{Name = Value.ElecTeam, Version = 1},
            new Style{Name = Value.AquaShield, Version = 1},
            new Style{Name = Value.WoodShield, Version = 1},
            new Style{Name = Value.HeatShield, Version = 1},
            new Style{Name = Value.ElecShield, Version = 1},
            new Style{Name = Value.Hub, Version = 1}
        };


        public static List<Style> BN3 = new List<Style>
        {
            new Style{Name = Value.Normal},
            new Style{Name = Value.AquaGuts, Version = 1},
            new Style{Name = Value.WoodGuts, Version = 1},
            new Style{Name = Value.HeatGuts, Version = 1},
            new Style{Name = Value.ElecGuts, Version = 1},
            new Style{Name = Value.AquaCust, Version = 1},
            new Style{Name = Value.WoodCust, Version = 1},
            new Style{Name = Value.HeatCust, Version = 1},
            new Style{Name = Value.ElecCust, Version = 1},
            new Style{Name = Value.AquaTeam, Version = 1},
            new Style{Name = Value.WoodTeam, Version = 1},
            new Style{Name = Value.HeatTeam, Version = 1},
            new Style{Name = Value.ElecTeam, Version = 1},
            new Style{Name = Value.AquaShield, Version = 1},
            new Style{Name = Value.WoodShield, Version = 1},
            new Style{Name = Value.HeatShield, Version = 1},
            new Style{Name = Value.ElecShield, Version = 1},
            new Style{Name = Value.AquaGround, Version = 1, VersionExclusive = GameTitle.Title.MegaManBattleNetwork3White},
            new Style{Name = Value.WoodGround, Version = 1, VersionExclusive = GameTitle.Title.MegaManBattleNetwork3White},
            new Style{Name = Value.HeatGround, Version = 1, VersionExclusive = GameTitle.Title.MegaManBattleNetwork3White},
            new Style{Name = Value.ElecGround, Version = 1, VersionExclusive = GameTitle.Title.MegaManBattleNetwork3White},
            new Style{Name = Value.AquaShadow, Version = 1, VersionExclusive = GameTitle.Title.MegaManBattleNetwork3Blue},
            new Style{Name = Value.WoodShadow, Version = 1, VersionExclusive = GameTitle.Title.MegaManBattleNetwork3Blue},
            new Style{Name = Value.HeatShadow, Version = 1, VersionExclusive = GameTitle.Title.MegaManBattleNetwork3Blue},
            new Style{Name = Value.ElecShadow, Version = 1, VersionExclusive = GameTitle.Title.MegaManBattleNetwork3Blue},
            new Style{Name = Value.AquaBug, Version = 1},
            new Style{Name = Value.WoodBug, Version = 1},
            new Style{Name = Value.HeatBug, Version = 1},
            new Style{Name = Value.ElecBug, Version = 1},
        };

        public static List<Style> ResetStyleList(List<Style> styleList)
        {
            foreach (var style in styleList)
            {
                style.Version = 1;
                style.Equip = false;
                style.Add = false;
            }

            return styleList;
        }
    }

}
