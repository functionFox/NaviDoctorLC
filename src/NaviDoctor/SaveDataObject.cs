using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NaviDoctor.models;

namespace NaviDoctor
{
    public class SaveDataObject
    {
        public GameTitle.Title GameName { get; set; }
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
        public int RegMem { get; set; }      // Not used in BN1
        public int RegChip1 { get; set; }
        public int RegChip2 { get; set; }
        public int RegChip3 { get; set; }
        public int SubChipMax { get; set; }  // Not used in BN1
        public int SubMiniEnrg { get; set; } // Not used in BN1
        public int SubFullEnrg { get; set; } // Not used in BN1
        public int SubSneakRun { get; set; } // Not used in BN1
        public int SubUntrap { get; set; }   // Not used in BN1
        public int SubLocEnemy { get; set; } // Not used in BN1
        public int SubUnlocker { get; set; } // Not used in BN1
        public int BugFrags { get; set; }    // Not used in BN1
        public byte EqStyle { get; set; } // Not used in BN4+
        public byte Style1 { get; set; }  // Not used in BN4+
        public byte Style2 { get; set; }  // Not used in BN4+
        public byte Style3 { get; set; }  // Not used in BN4+
        public List<int> StyleTypes { get; set; } = new List<int>();
        public byte Folders { get; set; } // Not used in BN1. Designates how many folders the player has unlocked.
        public List<Tuple<int, int>> FolderData { get; set; } = new List<Tuple<int, int>>();
        public List<Tuple<int, int>> Folder2Data { get; set; } = new List<Tuple<int, int>>(); // Not used in BN1
        public List<Tuple<int, int>> Folder3Data { get; set; } = new List<Tuple<int, int>>(); // Not used in BN1
        public List<byte> BattleChips { get; set; } = new List<byte>();
        public List<byte> NaviChips { get; set; } = new List<byte>();
        public List<byte> SecretChips { get; set; } = new List<byte>(); // Not used in BN1
        public List<byte> LibraryData { get; set; } = new List<byte>();
        public List<byte> PALibraryData { get; set; } = new List<byte>(); // Not used in BN1
    }
}
