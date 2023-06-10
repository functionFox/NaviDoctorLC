using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaviDoctor
{
    public class Style
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public static List<Style> BN1 = new List<Style>
        {
            new Style{Name = "Normal"},
            new Style{Name = "Aqua"},
            new Style{Name = "Wood"},
            new Style{Name = "Heat"}
        };

        public static List<Style> BN2 = new List<Style>
        {
            new Style{Name = "Normal"},
            new Style{Name = "Aqua", Type = "Guts"},
            new Style{Name = "Wood", Type = "Guts"},
            new Style{Name = "Heat", Type = "Guts"},
            new Style{Name = "Elec", Type = "Guts"},
            new Style{Name = "Aqua", Type = "Cust"},
            new Style{Name = "Wood", Type = "Cust"},
            new Style{Name = "Heat", Type = "Cust"},
            new Style{Name = "Elec", Type = "Cust"},
            new Style{Name = "Aqua", Type = "Team"},
            new Style{Name = "Wood", Type = "Team"},
            new Style{Name = "Heat", Type = "Team"},
            new Style{Name = "Elec", Type = "Team"},
            new Style{Name = "Aqua", Type = "Shield"},
            new Style{Name = "Wood", Type = "Shield"},
            new Style{Name = "Heat", Type = "Shield"},
            new Style{Name = "Elec", Type = "Shield"},
            new Style{Name = "Hub"}
        };
    }

}
