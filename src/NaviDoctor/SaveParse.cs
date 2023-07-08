using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NaviDoctor.models;

namespace NaviDoctor
{
    public class SaveParse
    {
        private GameTitle.Title GameName;
        private int ChecksumOffset;
        private int SteamOffset;
        private int AttackOffset;
        private int RapidOffset;
        private int ChargeOffset;
        private int CShotPowerOffset;
        private int EqStyleOffset;
        private int CurrHPOffset;
        private int MaxHPOffset;
        private int HPRedundancy1;
        private int HPRedundancy2;
        private int ZennyOffset;
        private int BugfragOffset;
        private int SubMaxOffset;
        private int SubMiniOffset;
        private int SubFullOffset;
        private int SubSneakOffset;
        private int SubUntrapOffset;
        private int SubLocEnOffset;
        private int SubUnlockerOffset;
        private int TimeOffset;
        private int HPUpOffset;
        private int CustSizeOffset;
        private int CustInvOffset;
        private int CompressOffset;
        private int GridPartsOffset;
        private int CustGridOffset;
        private int ModOffset;
        private int LimitsOffset;
        private int StyleOffset;
        private int RegMemOffset;
        private int RegChip1Offset;
        private int RegChip2Offset;
        private int RegChip3Offset;
        private int FoldersOffset;
        private int FolderOffsetStart;
        private int FolderOffsetEnd;
        private int Folder2OffsetStart;
        private int Folder2OffsetEnd;
        private int Folder3OffsetStart;
        private int Folder3OffsetEnd;
        private int BattleOffsetStart;
        private int BattleOffsetEnd;
        private int NaviOffsetStart;
        private int NaviOffsetEnd;
        private int SecretOffsetStart;
        private int SecretOffsetEnd;
        private int LibraryOffsetStart;
        private int LibraryOffsetEnd;
        private int PALibStart;
        private int PALibEnd;
        private int LibChecksumOffset;
        public string saveFilePath;
        private byte[] saveData;

        public SaveParse(string filePath)
        {
            saveFilePath = filePath;
            ReadSaveFile();
        }

        private void ReadSaveFile()
        {
            try
            {
                saveData = File.ReadAllBytes(saveFilePath);
                if (saveData.Length == 8909)
                {
                    GameName = GameTitle.Title.MegaManBattleNetwork;
                    AttackOffset = 0x0014;
                    RapidOffset = 0x0015;
                    ChargeOffset = 0x0016;
                    EqStyleOffset = 0x0017;
                    CurrHPOffset = 0x001C;
                    MaxHPOffset = 0x001E;
                    ZennyOffset = 0x0074;
                    TimeOffset = 0x0098;
                    ChecksumOffset = 0x00A0;
                    SteamOffset = 0x00BC;
                    HPUpOffset = 0x0100;
                    StyleOffset = 0x0104;
                    FolderOffsetStart = 0x0120;
                    FolderOffsetEnd = 0x015B;
                    BattleOffsetStart = 0x0170;
                    BattleOffsetEnd = 0x0A94;
                    NaviOffsetStart = 0x0AA0;
                    NaviOffsetEnd = 0x1050;
                    LibraryOffsetStart = 0x1080;
                    LibraryOffsetEnd = 0x1098;
                }
                else if (saveData.Length == 14976)
                {
                    GameName = GameTitle.Title.MegaManBattleNetwork2;
                    EqStyleOffset = 0x0001;
                    RegMemOffset = 0x0017;
                    RegChip1Offset = 0x001D;
                    RegChip2Offset = 0x001E;
                    RegChip3Offset = 0x001F;
                    CurrHPOffset = 0x0020;
                    MaxHPOffset = 0x0022;
                    HPRedundancy1 = 0x008C; // BN2 has two HP redundancies.
                    HPRedundancy2 = 0x008E;
                    ZennyOffset = 0x0074;
                    FoldersOffset = 0x0082;
                    AttackOffset = 0x0084;
                    RapidOffset = 0x0085;
                    ChargeOffset = 0x0086;
                    TimeOffset = 0x00A0;
                    ChecksumOffset = 0x00A8;
                    SteamOffset = 0x0104;
                    BugfragOffset = 0x0155;
                    HPUpOffset = 0x0170;
                    SubMaxOffset = 0x0175;
                    SubMiniOffset = 0x0180;
                    SubFullOffset = 0x0181;
                    SubSneakOffset = 0x0182;
                    SubUntrapOffset = 0x0183;
                    SubLocEnOffset = 0x0184;
                    SubUnlockerOffset = 0x0185;
                    StyleOffset = 0x0190;
                    FolderOffsetStart = 0x01B0;
                    FolderOffsetEnd = 0x0227;
                    Folder2OffsetStart = 0x0228;
                    Folder2OffsetEnd = 0x029F;
                    Folder3OffsetStart = 0x02A0;
                    Folder3OffsetEnd = 0x0317;
                    BattleOffsetStart = 0x032A;
                    BattleOffsetEnd = 0x10AF;
                    NaviOffsetStart = 0x10BC;
                    NaviOffsetEnd = 0x14B1;
                    SecretOffsetStart = 0x14BE;
                    SecretOffsetEnd = 0x162B;
                    LibraryOffsetStart = 0x1690;
                    LibraryOffsetEnd = 0x16B1;
                    PALibStart = 0x16CC;
                    PALibEnd = 0x16CF;
                }
                else if (saveData.Length == 22456)
                {
                    if (saveData[0x00D1] == 0x57) // BN3 Version check
                    {
                        GameName = GameTitle.Title.MegaManBattleNetwork3White;
                    }
                    else if (saveData[0x00D1] == 0x42)
                    {
                        GameName = GameTitle.Title.MegaManBattleNetwork3Blue;
                    }
                    else
                    {
                        throw new Exception("Invalid save file data.\nPlease load a valid Battle\nNetwork 3 save file.");
                    }
                    EqStyleOffset = 0x0001;
                    StyleOffset = 0x0014;
                    RegMemOffset = 0x0017;
                    RegChip1Offset = 0x001D;
                    RegChip2Offset = 0x001F;
                    CurrHPOffset = 0x0020;
                    MaxHPOffset = 0x0022;
                    ZennyOffset = 0x0074;
                    BugfragOffset = 0x0078;
                    FoldersOffset = 0x0086;
                    HPRedundancy1 = 0x0094; // Temporary HP tracker
                    TimeOffset = 0x00A0;
                    ChecksumOffset = 0x00A8;
                    SteamOffset = 0x00E0;
                    HPUpOffset = 0x0150;
                    CustSizeOffset = 0x0151;
                    SubMaxOffset = 0x0155;
                    SubMiniOffset = 0x0160;
                    SubFullOffset = 0x0161;
                    SubSneakOffset = 0x0162;
                    SubUntrapOffset = 0x0163;
                    SubLocEnOffset = 0x0164;
                    SubUnlockerOffset = 0x0165;
                    CustInvOffset = 0x01B7;
                    FolderOffsetStart = 0x0290;
                    FolderOffsetEnd = 0x0307;
                    Folder2OffsetStart = 0x0308; // Xtra Folder
                    Folder2OffsetEnd = 0x037F;
                    Folder3OffsetStart = 0x0380; // Folder 2
                    Folder3OffsetEnd = 0x03F7; // Trust me, it makes sense.
                    BattleOffsetStart = 0x0412;
                    BattleOffsetEnd = 0x1215;
                    NaviOffsetStart = 0x1222; // Mega and Giga chips
                    NaviOffsetEnd = 0x1A01;
                    CompressOffset = 0x1D60;
                    LibraryOffsetStart = 0x1D80; // All Standard, Mega, and Giga chips
                    LibraryOffsetEnd = 0x1DA7;
                    PALibStart = 0x1DA8;
                    PALibEnd = 0x1DAB;
                    GridPartsOffset = 0x4D40;
                    CustGridOffset = 0x4E10;
                    ModOffset = 0x4E50;
                    AttackOffset = 0x4E68;
                    RapidOffset = 0x4E69;
                    ChargeOffset = 0x4E6A;
                    CShotPowerOffset = 0x4E6D;
                    LimitsOffset = 0x4E74;
                    HPRedundancy2 = 0x4E8C; // Max HP divided by five
                    LibChecksumOffset = 0x5430;
                }
                else
                {
                    throw new Exception("Invalid save file size.");
                }
            }
            catch
            {
                throw;
            }
        }

        public SaveDataObject ExtractSaveData()
        {
            SaveDataObject saveDataObject = new SaveDataObject();

            saveDataObject.GameName = GameName;

            saveDataObject.AttackPower = saveData[AttackOffset];
            saveDataObject.RapidPower = saveData[RapidOffset];
            saveDataObject.ChargePower = saveData[ChargeOffset];
            saveDataObject.EqStyle = saveData[EqStyleOffset]; // I know this is armor for BN1, not styles but it's close enough.

            saveDataObject.CurrHP = BitConverter.ToInt16(saveData, CurrHPOffset);
            saveDataObject.MaxHP = BitConverter.ToInt16(saveData, MaxHPOffset);

            saveDataObject.Zenny = BitConverter.ToInt32(saveData, ZennyOffset);

            saveDataObject.PlayTime = BitConverter.ToInt32(saveData, TimeOffset);

            saveDataObject.CheckSum = BitConverter.ToInt32(saveData, ChecksumOffset);
            saveDataObject.SteamID = BitConverter.ToInt32(saveData, SteamOffset);

            saveDataObject.HPUp = saveData[HPUpOffset];
            saveDataObject.Folders = 1; // BN1 only has one folder. Just set it by default.

            for (int i = LibraryOffsetStart; i <= LibraryOffsetEnd; i++)
            {
                saveDataObject.LibraryData.Add(saveData[i]);
            }

            if (saveDataObject.GameName != GameTitle.Title.MegaManBattleNetwork)
            // BN1 is the only game without a PA Library, BugFrags, and a Folder count greater than 1.
            {
                saveDataObject.Folders = saveData[FoldersOffset];
                for (int i = PALibStart; i <= PALibEnd; i++)
                {
                    saveDataObject.PALibraryData.Add(saveData[i]);
                }
                saveDataObject.RegMem = saveData[RegMemOffset]; // BN1 also is the only game without RegMem and RegChips 1 and 2
                saveDataObject.RegChip1 = saveData[RegChip1Offset];
                saveDataObject.RegChip2 = saveData[RegChip2Offset];
                saveDataObject.SubChipMax = saveData[SubMaxOffset]; // And subchips
                saveDataObject.SubFullEnrg = saveData[SubFullOffset];
                saveDataObject.SubLocEnemy = saveData[SubLocEnOffset];
                saveDataObject.SubMiniEnrg = saveData[SubMiniOffset];
                saveDataObject.SubSneakRun = saveData[SubSneakOffset];
                saveDataObject.SubUnlocker = saveData[SubUnlockerOffset];
                saveDataObject.SubUntrap = saveData[SubUntrapOffset];

                for (int i = FolderOffsetStart; i <= Folder3OffsetEnd; i += 4) // BN2+ has 3 Folders
                {
                    int chipID = BitConverter.ToInt16(saveData, i);
                    int chipCode = BitConverter.ToInt16(saveData, i + 2);
                    if (i >= FolderOffsetStart && i <= FolderOffsetEnd)
                    {
                        saveDataObject.FolderData.Add(new Tuple<int, int>(chipID, chipCode));
                    }
                    else if (i >= Folder2OffsetStart && i <= Folder2OffsetEnd) // These values should all be 0 if not unlocked
                    {
                        saveDataObject.Folder2Data.Add(new Tuple<int, int>(chipID, chipCode));
                    }
                    else if (i >= Folder3OffsetStart && i <= Folder3OffsetEnd) // These values should all be 0 if not unlocked
                    {
                        saveDataObject.Folder3Data.Add(new Tuple<int, int>(chipID, chipCode));
                    }
                }
                for (int i = BattleOffsetStart; i <= BattleOffsetEnd; i += 0x12) // BN2 and 3 use this method
                {
                    for (int j = 0; j < 6; j++) // Since most have 6 codes, just read all six.
                    {
                        saveDataObject.BattleChips.Add(saveData[i + j]);
                    }
                }
            }

            switch (saveDataObject.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    saveDataObject.Style1 = saveData[StyleOffset]; // For BN1, this is HeatArmr.
                    saveDataObject.Style2 = saveData[StyleOffset + 0x1]; // For BN1, this is AquaArmr
                    saveDataObject.Style3 = saveData[StyleOffset + 0x2]; // For BN1, this is not ElecArmr
                    for (int i = FolderOffsetStart; i <= FolderOffsetEnd; i += 2)
                    {
                        byte chipID = saveData[i];
                        byte chipCode = saveData[i + 1];
                        saveDataObject.FolderData.Add(new Tuple<int, int>(chipID, chipCode));
                    }

                    for (int i = BattleOffsetStart; i <= BattleOffsetEnd; i++)
                    {
                        if (i % 0x10 <= 0x4)
                        {
                            saveDataObject.BattleChips.Add(saveData[i]);
                        }
                    }

                    for (int i = NaviOffsetStart; i <= NaviOffsetEnd; i += 0x10)
                    {
                        saveDataObject.NaviChips.Add(saveData[i]);
                    }

                    break;

                case GameTitle.Title.MegaManBattleNetwork2:
                    int stylesFound = 0;       // Style parse system for BN2. It'll change a bit for BN3 but hopefully it'll be mostly the same.
                    saveDataObject.Style1 = 0; // Initialize these to 0. No null values!
                    saveDataObject.Style2 = 0;
                    saveDataObject.StyleTypes.Add(StyleOffset); // Normal Style is always present.
                    for (int i = StyleOffset + 0x6; i <= StyleOffset + 0x19; i++) // We know where Normal Style starts, so skip to the good part.
                    {
                        if (i == 0x19A || i == 0x19F || i == 0x1A4)
                        {
                            continue; // We know there's nothing at these addresses. Skip them.
                        }
                        if (saveData[i] != 0) // Style found!
                        {
                            stylesFound++;
                            switch (stylesFound)
                            {
                                case 1:
                                    saveDataObject.Style1 = saveData[i];
                                    saveDataObject.StyleTypes.Add(i);
                                    break;

                                case 2:
                                    saveDataObject.Style2 = saveData[i];
                                    saveDataObject.StyleTypes.Add(i);
                                    break;

                            }
                        }
                        if (stylesFound >= 2) break;
                    }
                    for (int i = saveDataObject.StyleTypes.Count; i < 3; i++)
                    {
                        saveDataObject.StyleTypes.Add(0); // NormStyl + 2 Styles = 3. If there's less than that, pad the rest
                    }

                    saveDataObject.RegChip3 = saveData[RegChip3Offset];
                    saveDataObject.BugFrags = saveData[BugfragOffset];

                    for (int i = SecretOffsetStart; i <= SecretOffsetEnd; i += 0x12)
                    {
                        for (int j = 0; j < 6; j++) // Some act as Navi chips, some act as regular chips, just get them all.
                        {
                            saveDataObject.SecretChips.Add(saveData[i + j]);
                        }
                    }
                    for (int i = NaviOffsetStart; i <= NaviOffsetEnd; i += 0x12)
                    {
                        for (int j = 0; j < 6; j += 5) // We'll only need the first and last byte of each block.
                        {
                            saveDataObject.NaviChips.Add(saveData[i]);
                        }
                    }
                    break;
                case GameTitle.Title.MegaManBattleNetwork3White:
                case GameTitle.Title.MegaManBattleNetwork3Blue:
                    saveDataObject.Style1 = saveData[StyleOffset];     // Works exactly like Equipped Style
                    saveDataObject.Style2 = saveData[StyleOffset + 1]; // This is the Style's level
                    saveDataObject.CustSize = saveData[CustSizeOffset];
                    saveDataObject.ModCode = saveData[ModOffset];
                    saveDataObject.CShotPower = saveData[CShotPowerOffset];
                    saveDataObject.MegaLimit = saveData[LimitsOffset];
                    saveDataObject.GigaLimit = saveData[LimitsOffset + 1];
                    saveDataObject.BugFrags = BitConverter.ToUInt16(saveData, BugfragOffset);
                    saveDataObject.BonusHP = (short)((saveData[HPRedundancy2] * 5) - (saveDataObject.HPUp * 20) - 100);

                    int index = CustInvOffset;
                    Dictionary<int, int> indexMap = new Dictionary<int, int>()
                    {
                        { 0x1DF, 2 }, { 0x1E1, 2 }, { 0x213, 2 }, { 0x232, 2 }, { 0x23E, 2 },
                        { 0x242, 2 }, { 0x246, 2 }, { 0x24A, 2 }, { 0x24E, 2 }, { 0x252, 2 },
                        { 0x256, 2 }, { 0x25A, 2 }, { 0x25E, 2 },
                        { 0x1BC, 3 }, { 0x1D7, 3 }, { 0x1FC, 3 }, { 0x221, 3 }, { 0x239, 3 },
                        { 0x265, 3 }, { 0x26D, 3 }, { 0x275, 3 },
                        { 0x1B7, 4 }, { 0x1BF, 4 }, { 0x1C3, 4 }, { 0x1C7, 4 }, { 0x1CF, 4 },
                        { 0x1D3, 4 }, { 0x1DB, 4 }, { 0x1E3, 4 }, { 0x1E7, 4 }, { 0x1EB, 4 },
                        { 0x1EF, 4 }, { 0x1F3, 4 }, { 0x200, 4 }, { 0x224, 4 },
                        { 0x1F7, 5 }, { 0x204, 5 }, { 0x209, 5 }, { 0x20E, 5 }, { 0x21C, 5 },
                        { 0x228, 5 }, { 0x22D, 5 }, { 0x234, 5 }, { 0x260, 5 }, { 0x268, 5 },
                        { 0x270, 5 },
                        { 0x215, 6 }
                    };

                    while (index < 0x279) // These don't increment in a set pattern.
                    {
                        saveDataObject.NCPInventory.Add(saveData[index]);

                        if (indexMap.ContainsKey(index))
                            index += indexMap[index];
                        else
                            index += 1;
                    }

                    for (int i = CompressOffset; i < 20; i++)
                    {
                        switch (saveData[i])
                        {
                            case 0x0F:
                                saveDataObject.Compression.Add(0);
                                saveDataObject.Compression.Add(1);
                                break;
                            case 0xF0:
                                saveDataObject.Compression.Add(1);
                                saveDataObject.Compression.Add(0);
                                break;
                            case 0xFF:
                                saveDataObject.Compression.Add(1);
                                saveDataObject.Compression.Add(1);
                                break;
                            default:
                                saveDataObject.Compression.Add(0);
                                saveDataObject.Compression.Add(0);
                                break;
                        }
                    }

                    for (int i = GridPartsOffset; i < 0x4E08; i += 0x8)
                    {
                        saveDataObject.NCPGrid.Add(new byte[] { saveData[i], saveData[i + 2], saveData[i + 3], saveData[i + 4] });
                    }

                    for (int i = 0; i < 5; i++) // NaviCust Grid locations here
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            saveDataObject.GridPosData[i, j] = saveData[CustGridOffset + j + (i * 5)];
                        }
                    }
                    for (int i = NaviOffsetStart; i <= NaviOffsetEnd; i += 0x12) // For BN3, these are Mega/Giga chips
                    {
                        for (int j = 0; j < 2; j++) // BN3 checks only the first two slots.
                        {
                            saveDataObject.NaviChips.Add(saveData[i]);
                        }
                    }
                    break;
            }
            return saveDataObject;
        }

        public void UpdateSaveData(SaveDataObject saveDataObject)
        {
            saveData[AttackOffset] = saveDataObject.AttackPower; // Let's write all of the data common to all games first
            saveData[RapidOffset] = saveDataObject.RapidPower;
            saveData[ChargeOffset] = saveDataObject.ChargePower;
            saveData[EqStyleOffset] = saveDataObject.EqStyle;

            short max = 1000;
            short basehp;

            Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.Zenny), 0, saveData, ZennyOffset, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.SteamID), 0, saveData, SteamOffset, 4);

            if (saveDataObject.GameName >= GameTitle.Title.MegaManBattleNetwork3White)
            {
                for (int i = 0; i < saveDataObject.BattleChips.Count / 6 + saveDataObject.NaviChips.Count / 2; i++)
                {
                    if (i < saveDataObject.BattleChips.Count / 6)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            int libraryIndex = (i + 1) / 8;
                            int bitIndex = 7 - ((i + 1) % 8);
                            bool isChecked = (saveDataObject.LibraryData[libraryIndex] & (1 << bitIndex)) != 0;
                            if (saveDataObject.BattleChips[(i * 6) + j] >= 1 && !isChecked)
                            {
                                saveDataObject.LibraryData[libraryIndex] |= (byte)(1 << bitIndex);
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            int libraryIndex = (i + 1) / 8;
                            int bitIndex = 7 - ((i + 1) % 8);
                            bool isChecked = (saveDataObject.LibraryData[libraryIndex] & (1 << bitIndex)) != 0;
                            if (saveDataObject.NaviChips[(i - saveDataObject.BattleChips.Count / 6) * 2 + j] >= 1 && !isChecked)
                            {
                                saveDataObject.LibraryData[libraryIndex] |= (byte)(1 << bitIndex);
                            }
                        }
                    }
                }
            }

            for (int i = LibraryOffsetStart; i <= LibraryOffsetEnd; i++)
            {
                saveData[i] = saveDataObject.LibraryData[i - LibraryOffsetStart];
            }

            var index = 0; // This is a secret tool we'll use later!

            if (saveDataObject.GameName != GameTitle.Title.MegaManBattleNetwork)
            {
                saveData[SubFullOffset] = (byte)saveDataObject.SubFullEnrg;
                saveData[SubLocEnOffset] = (byte)saveDataObject.SubLocEnemy;
                saveData[SubMiniOffset] = (byte)saveDataObject.SubMiniEnrg;
                saveData[SubSneakOffset] = (byte)saveDataObject.SubSneakRun;
                saveData[SubUnlockerOffset] = (byte)saveDataObject.SubUnlocker;
                saveData[SubUntrapOffset] = (byte)saveDataObject.SubUntrap;
                saveData[SubMaxOffset] = (byte)saveDataObject.SubChipMax;
                saveData[RegMemOffset] = (byte)saveDataObject.RegMem;
                saveData[RegChip1Offset] = 0xFF; // Turn off the regular chips.
                saveData[RegChip2Offset] = 0xFF; // We'll do these up proper when we have the functionality
                for (int i = FolderOffsetStart; i <= Folder3OffsetEnd; i += 4)
                {
                    if (i >= FolderOffsetStart && i <= FolderOffsetEnd)
                    {
                        CopyFolderData(saveDataObject.FolderData, i, FolderOffsetStart, 2);
                    }
                    else if (i >= Folder2OffsetStart && i <= Folder2OffsetEnd && saveDataObject.Folders >= 2)
                    {
                        CopyFolderData(saveDataObject.Folder2Data, i, Folder2OffsetStart, 2);
                    }
                    else if (i >= Folder3OffsetStart && i <= Folder3OffsetEnd && saveDataObject.Folders >= 3)
                    {
                        CopyFolderData(saveDataObject.Folder3Data, i, Folder3OffsetStart, 2);
                    }
                }

                index = 0;
                for (int i = BattleOffsetStart; i < BattleOffsetEnd; i += 0x12)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        saveData[(i + j)] = saveDataObject.BattleChips[index];
                        index++;
                    }
                }

                for (int i = PALibStart; i <= PALibEnd; i++)
                {
                    saveData[i] = saveDataObject.PALibraryData[(i - PALibStart)];
                }
            }

            if (saveDataObject.GameName <= GameTitle.Title.MegaManBattleNetwork2) // BN1&2 are more lax with their HP calcs
            {
                saveDataObject.CurrHP = Math.Min(saveDataObject.CurrHP, max);
                saveDataObject.MaxHP = Math.Min(saveDataObject.MaxHP, max);
                Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.CurrHP), 0, saveData, CurrHPOffset, 2);
                Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.MaxHP), 0, saveData, MaxHPOffset, 2);
                saveData[HPUpOffset] = (byte)((saveDataObject.MaxHP - 100) / 20);
            }

            switch (saveDataObject.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    saveData[StyleOffset] = saveDataObject.Style1;       // Save the Armors
                    saveData[StyleOffset + 0x1] = saveDataObject.Style2;
                    saveData[StyleOffset + 0x2] = saveDataObject.Style3;

                    for (int i = FolderOffsetStart; i <= FolderOffsetEnd; i += 2) // Only one folder to save for BN1
                    {
                        CopyFolderData(saveDataObject.FolderData, i, FolderOffsetStart);
                    }

                    for (int i = BattleOffsetStart; i < BattleOffsetEnd; i++)
                    {
                        if ((i % 0x10) <= 0x4)  // Check if i is within the range 0 to 4 for every group of 10 elements
                        {
                            saveData[i] = saveDataObject.BattleChips[index];
                            index++;
                        }
                    }

                    index = 0;
                    for (int i = NaviOffsetStart; i <= NaviOffsetEnd; i += 0x10)
                    {
                        saveData[i] = saveDataObject.NaviChips[index];
                        index++;
                    }
                    break;

                case GameTitle.Title.MegaManBattleNetwork2:
                    Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.CurrHP), 0, saveData, HPRedundancy1, 2);
                    Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.MaxHP), 0, saveData, HPRedundancy2, 2);

                    saveData[BugfragOffset] = (byte)saveDataObject.BugFrags;

                    for (int i = StyleOffset + 0x1; i <= StyleOffset + 0x19; i++) // Erase the currently saved styles
                    {
                        saveData[i] = 0;
                    }

                    for (int i = 1; i < saveDataObject.StyleTypes.Count; i++) // Let's save some styles.
                    {
                        if (saveDataObject.StyleTypes[i] == 0)
                        {
                            break; // If the user has no Style, kick 'em out.
                        }
                        switch (i)
                        {
                            case 1:
                                saveData[saveDataObject.StyleTypes[i]] = saveDataObject.Style1;
                                break;
                            case 2:
                                saveData[saveDataObject.StyleTypes[i]] = saveDataObject.Style2;
                                break;
                        }
                    }

                    index = 0;
                    for (int i = NaviOffsetStart; i <= NaviOffsetEnd; i += 0x12)
                    {
                        for (int j = 0; j < 6; j += 5)
                        {
                            saveData[(i + j)] = saveDataObject.NaviChips[index];
                            index++;
                        }
                    }

                    saveData[RegChip3Offset] = 0xFF; // Turn off the third RegChip

                    index = 0;
                    for (int i = SecretOffsetStart; i < SecretOffsetEnd; i += 0x12)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            saveData[(i + j)] = saveDataObject.SecretChips[index];
                            index++;
                        }
                    }
                    break;
                case GameTitle.Title.MegaManBattleNetwork3White:
                case GameTitle.Title.MegaManBattleNetwork3Blue:
                    // HP is calculated a little differently
                    basehp = Math.Min((short)((saveDataObject.HPUp * 20) + 100), max);
                    saveDataObject.CurrHP = (short)(basehp + saveDataObject.BonusHP);
                    saveDataObject.MaxHP = (short)(basehp + saveDataObject.BonusHP);
                    Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.CurrHP), 0, saveData, CurrHPOffset, 2);
                    Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.MaxHP), 0, saveData, MaxHPOffset, 2);
                    Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.MaxHP), 0, saveData, HPRedundancy1, 2);
                    saveData[HPRedundancy2] = (byte)((basehp + saveDataObject.BonusHP) / 5);
                    saveData[HPUpOffset] = (byte)((basehp - 100) / 20);
                    saveData[StyleOffset] = saveDataObject.Style1;
                    saveData[StyleOffset + 1] = saveDataObject.Style2;
                    saveData[ModOffset] = saveDataObject.ModCode;
                    saveData[CShotPowerOffset] = saveDataObject.CShotPower;
                    saveData[LimitsOffset] = saveDataObject.MegaLimit;
                    saveData[LimitsOffset + 1] = saveDataObject.GigaLimit;

                    Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.BugFrags), 0, saveData, BugfragOffset, 2);

                    int mapIndex = CustInvOffset;
                    Dictionary<int, int> indexMap = new Dictionary<int, int>()
                    {
                        { 0x1DF, 2 }, { 0x1E1, 2 }, { 0x213, 2 }, { 0x232, 2 }, { 0x23E, 2 },
                        { 0x242, 2 }, { 0x246, 2 }, { 0x24A, 2 }, { 0x24E, 2 }, { 0x252, 2 },
                        { 0x256, 2 }, { 0x25A, 2 }, { 0x25E, 2 },
                        { 0x1BC, 3 }, { 0x1D7, 3 }, { 0x1FC, 3 }, { 0x221, 3 }, { 0x239, 3 },
                        { 0x265, 3 }, { 0x26D, 3 }, { 0x275, 3 },
                        { 0x1B7, 4 }, { 0x1BF, 4 }, { 0x1C3, 4 }, { 0x1C7, 4 }, { 0x1CF, 4 },
                        { 0x1D3, 4 }, { 0x1DB, 4 }, { 0x1E3, 4 }, { 0x1E7, 4 }, { 0x1EB, 4 },
                        { 0x1EF, 4 }, { 0x1F3, 4 }, { 0x200, 4 }, { 0x224, 4 },
                        { 0x1F7, 5 }, { 0x204, 5 }, { 0x209, 5 }, { 0x20E, 5 }, { 0x21C, 5 },
                        { 0x228, 5 }, { 0x22D, 5 }, { 0x234, 5 }, { 0x260, 5 }, { 0x268, 5 },
                        { 0x270, 5 },
                        { 0x215, 6 }
                    };

                    foreach (int item in saveDataObject.NCPInventory)
                    {
                        saveData[mapIndex] = (byte)item;
                        if (indexMap.ContainsKey(mapIndex))
                            mapIndex += indexMap[mapIndex];
                        else
                            mapIndex += 1;
                    }

                    index = 0;
                    for (int i = NaviOffsetStart; i <= NaviOffsetEnd; i += 0x12)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            saveData[(i + j)] = saveDataObject.NaviChips[index];
                            index++;
                        }
                    }

                    for (int i = 0; i < saveDataObject.Compression.Count; i += 2)
                    {
                        byte value = (byte)((saveDataObject.Compression[i] << 1) | saveDataObject.Compression[i + 1]);

                        switch (value)
                        {
                            case 0x00:
                                saveData[CompressOffset + (i / 2)] = 0x0;
                                break;
                            case 0x01:
                                saveData[CompressOffset + (i / 2)] = 0xF;
                                break;
                            case 0x02:
                                saveData[CompressOffset + (i / 2)] = 0xF0;
                                break;
                            default:
                                saveData[CompressOffset + (i / 2)] = 0xFF;
                                break;
                        }
                    }

                    short lcs = 0;
                    for (int i = LibraryOffsetStart; i < LibraryOffsetStart + 0x40; i++)
                    {
                        lcs += saveData[i];
                    }
                    Buffer.BlockCopy(BitConverter.GetBytes(-lcs), 0, saveData, LibChecksumOffset, 2);
                    // Thanks, weenie :3

                    byte[,] gridData = new byte[5, 5];
                    for (int row = 0; row < 5; row++)
                    {
                        for (int col = 0; col < 5; col++)
                        {
                            gridData[row, col] = saveDataObject.GridPosData[row, col];
                        }
                    }
                    Buffer.BlockCopy(gridData, 0, saveData, CustGridOffset, 25);

                    for (int i = 0; i < saveDataObject.NCPGrid.Count; i++)
                    {
                        byte[] gridParts = new byte[] { saveDataObject.NCPGrid[i][0], 0, saveDataObject.NCPGrid[i][1], saveDataObject.NCPGrid[i][2], saveDataObject.NCPGrid[i][3], 0, 0, 0 };
                        Buffer.BlockCopy(gridParts, 0, saveData, GridPartsOffset + (i * 8), 8);
                    }

                    break;
            }

            CalculateAndWriteChecksum();

        }

        private void CopyFolderData(List<Tuple<int, int>> folderData, int index, int offset, int bitMulti = 1)
        {
            Tuple<int, int> value = folderData[(index - offset) / (2 * bitMulti)];
            Buffer.BlockCopy(BitConverter.GetBytes(value.Item1), 0, saveData, index, bitMulti);
            Buffer.BlockCopy(BitConverter.GetBytes(value.Item2), 0, saveData, index + bitMulti, bitMulti);
        }

        private void CalculateAndWriteChecksum()
        {
            uint checksum = 0x0;
            uint steamsum = 0x0;
            Buffer.BlockCopy(BitConverter.GetBytes(checksum), 0, saveData, ChecksumOffset, 4); // erase the current checksum
            if (BitConverter.ToUInt32(saveData, SteamOffset) == 0) // Switch doesn't use checksum or Steam ID, so no need to go further
            {
                return;
            }
            else
            {
                for (int i = SteamOffset; i <= SteamOffset + 3; i++)
                {
                    steamsum += saveData[i];
                }
                foreach (byte dataByte in saveData)
                {
                    checksum += dataByte; // Calculate the checksum
                }
            }
            checksum -= steamsum; // Subtract the Steam ID from the checksum
            Buffer.BlockCopy(BitConverter.GetBytes(checksum), 0, saveData, ChecksumOffset, 4);
        }

        public void SaveChanges()
        {
            try
            {
                File.WriteAllBytes(saveFilePath, saveData);
                Console.WriteLine("Save file successfully updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving changes to the file: " + ex.Message);
            }
        }
    }
}