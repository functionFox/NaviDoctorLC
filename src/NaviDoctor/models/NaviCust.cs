using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaviDoctor.models
{
    public class NaviCust
    {
        public int HpUp { get; set; }
        public int BaseHP { get; set; }
        public int BonusHP { get; set; }
        public int CustSize { get; set; }
        public int AtkBonus { get; set; }
        public int SpdBonus { get; set; }
        public int ChrgBonus { get; set; }
        public int CShotBonus { get; set; }
        public byte[,] GridPos { get; set; }
        public int ModHP { get; set; } = 0;
        public byte ModCode { get; set; }
        public int RegMem { get; set; }
        public byte BonusRegMem { get; set; }
        public byte MegaLimit { get; set; }
        public byte ModMega { get; set; } = 0;
        public byte GigaLimit { get; set; }
        public byte ModGiga { get; set; } = 0;
        public byte CustomSize { get; set; }
        public byte ModCustom { get; set; } = 0;
        public bool IsBugged { get; set; } = false;
        public bool IsGuts { get; set; } = false;
        public bool IsCust { get; set; } = false;
        public bool IsTeam { get; set; } = false;
        public List<byte> Bugs { get; set; }
        public List<byte> NcpInv { get; set; }
        public List<byte[]> NcpGrid { get; set; }
        public List<byte> Effects { get; set; }
        public List<byte> Compression { get; set; }
        public List<string> ColorsList { get; set; } = new List<string> { "White", "Pink", "Yellow" };
        public List<NCPListing> NcpMapList { get; set; }
        public List<PictureBox> ColorBox { get; set; }
        public List<PictureBox> PictureBoxList { get; set; }
        public Dictionary<int, string> GridIndex { get; set; } = new Dictionary<int, string>();
        public Dictionary<int, string> ModCodeDict { get; set; } = new Dictionary<int, string>()
        {
            { 0x00, "None" }, { 0x1E, "HP+100" }, { 0x1F, "HP+150" }, { 0x20, "HP+200" }, { 0x21, "HP+250" }, { 0x22, "HP+300" },
            { 0x23, "HP+350" }, { 0x24, "HP+400" }, { 0x25, "HP+450" }, { 0x26, "HP+500" }, { 0x27, "HP+550" }, { 0x28, "HP+600" },
            { 0x29, "HP+650" }, { 0x2A, "HP+700" }, { 0x2B, "Equip Super Armor" }, { 0x2C, "Equip Break Buster" },
            { 0x2D, "Equip Break Charge" }, { 0x2E, "Equip Shadow Shoes" }, { 0x2F, "Equip Float Shoes" }, { 0x30, "Equip Air Shoes" },
            { 0x31, "Equip UnderShirt" }, { 0x32, "Equip Block (B+Left)" }, { 0x33, "Equip Shield (B+Left)" },
            { 0x34, "Equip Reflect (B+Left)" }, { 0x35, "Equip Anti-Damage (B+Left)" }, { 0x36, "MegaChip +1" }, { 0x37, "MegaChip +2" },
            { 0x38, "Activate FastGauge" }, { 0x39, "Activate SneakRun" }, { 0x3A, "Activate Humor" }, { 0x3B, "HP+800" },
            { 0x3C, "HP+900" }, { 0x3D, "HP+1000" }, { 0x3E, "MegaChip +3" }, { 0x3F, "MegaChip +4" }, { 0x40, "MegaChip +5" },
            { 0x41, "GigaChip +1" }, { 0xA1, "Error A1: SuprArmr" }, { 0xA2, "Error A2: BrakBstr" }, { 0xA3, "Error A3: BrakChrg" },
            { 0xB1, "Error B1: SetGreen" }, { 0xB2, "Error B2: SetIce" }, { 0xB3, "Error B3: SetLava" }, { 0xB4, "Error B4: SetSand" },
            { 0xB5, "Error B5: SetMetal" }, { 0xB6, "Error B6: SetHoly" }, { 0xC1, "Error C1: Custom1" }, { 0xC2, "Error C2: Custom2" },
            { 0xE1, "Error E1: MegFldr1" }, { 0xE2, "Error E2: MegFldr2" }, { 0xF1, "Error F1: Block" }, { 0xF2, "Error F2: Shield" },
            { 0xF3, "Error F3: Reflect" }, { 0x100, "Error H1: ShdwShoe" }, { 0x101, "Error H2: FlotShoe" }, { 0x103, "Error H3: AntiDmg" },
            { 0x104, "Error G2G: GigFldr1 (Normal/Bug Style)" }, { 0x105, "Error G2S: GigFldr1 (Guts/Shield/Shadow Style)" },
            { 0x106, "Error G2C: GigFldr1 (Custom/Team/Ground Style)" }, { 0x107, "Error D2G: DarkLcns (Normal Style)" },
            { 0x108, "Error D2S: DarkLcns (Guts/Shield/Shadow Style)" }, { 0x109, "Error D2C: DarkLcns (Custom/Team/Ground Style)" },
            { 0x10A, "Error S2G: HubBatc (Normal/Bug Style)" }, { 0x10B, "Error S2S: HubBatc (Guts/Shield/Shadow Style)" },
            { 0x10C, "Error S2C: HubBatc (Custom/Team/Ground Style)" }
        };
    }
}
