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
        public byte CShotPower { get; set; }
        public int Zenny { get; set; }
        public int PlayTime { get; set; }
        public int CheckSum { get; set; }
        public int SteamID { get; set; }
        public byte HPUp { get; set; }
        public int RegMem { get; set; }      // Not used in BN1
        public int RegChip1 { get; set; }    // Not used in BN1
        public int RegChip2 { get; set; }    // Not used in BN1
        public int RegChip3 { get; set; }    // BN2 Only
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
        public byte Style2 { get; set; }  // Not used in BN3+
        public byte Style3 { get; set; }  // Not used in BN2+
        public List<int> StyleTypes { get; set; } = new List<int>(); // Not used in BN1, BN4+
        public byte Folders { get; set; } // Not used in BN1. Designates how many folders the player has unlocked.
        public List<Tuple<int, int>> FolderData { get; set; } = new List<Tuple<int, int>>();
        public List<Tuple<int, int>> Folder2Data { get; set; } = new List<Tuple<int, int>>(); // Not used in BN1
        public List<Tuple<int, int>> Folder3Data { get; set; } = new List<Tuple<int, int>>(); // Not used in BN1
        public List<byte> BattleChips { get; set; } = new List<byte>();
        public List<byte> NaviChips { get; set; } = new List<byte>();
        public List<byte> SecretChips { get; set; } = new List<byte>(); // Not used in BN1
        public List<byte> LibraryData { get; set; } = new List<byte>();
        public List<byte> PALibraryData { get; set; } = new List<byte>(); // Not used in BN1
        public List<byte> RegUpList { get; set; } = new List<byte>();
        public byte CustSize { get; set; } // BN3+
        public bool isCustBugged { get; set; } // BN3+
        public List<byte> NCPInventory { get; set; } = new List<byte>();   // BN3+
        public List<byte> Compression { get; set; } = new List<byte>();    // BN3+
        public List<byte[]> NCPGrid { get; set; } = new List<byte[]>();  // BN3+
        public byte[,] GridPosData { get; set; } = new byte[5,5]; // BN3+
        public List<byte> CustEffects { get; set; } = new List<byte>(); // BN3+
        public List<byte> CustBugs { get; set; } = new List<byte>(); // BN3+
        public byte ModCode { get; set; } // BN3 only
        public byte MegaLimit { get; set; } // BN3+
        public byte GigaLimit { get; set; } // BN3+
        public short BonusHP { get; set; } // BN3+, HP Bonus from NaviCust
    }
}
