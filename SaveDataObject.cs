using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaviDoctor
{
    public class SaveDataObject
    {
        public string GameName { get; set; }
        public short CurrHP { get; set; }
        public short MaxHP { get; set; }
        public byte AttackPower { get; set; }
        public byte RapidPower { get; set; }
        public byte ChargePower { get; set; }
        public int Zenny { get; set; }
        public int PlayTime { get; set; }
        public int CheckSum { get; set; }
        public int SteamID { get; set; }
        public byte HPUp { get; set; }
        public int BugFrags { get; set; }
        public List<Tuple<byte, byte>> FolderData { get; set; } = new List<Tuple<byte, byte>>();
        public List<byte> BattleChips { get; set; } = new List<byte>();
        public List<byte> NaviChips { get; set; } = new List<byte>();
        public List<byte> LibraryData { get; set; } = new List<byte>();
    }
}
