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
                    AttackOffset =       0x0014;
                    RapidOffset =        0x0015;
                    ChargeOffset =       0x0016;
                    EqStyleOffset =      0x0017;
                    CurrHPOffset =       0x001C;
                    MaxHPOffset =        0x001E;
                    ZennyOffset =        0x0074;
                    TimeOffset =         0x0098;
                    ChecksumOffset =     0x00A0;
                    SteamOffset =        0x00BC;
                    HPUpOffset =         0x0100;
                    StyleOffset =        0x0104;
                    FolderOffsetStart =  0x0120;
                    FolderOffsetEnd =    0x015B;
                    BattleOffsetStart =  0x0170;
                    BattleOffsetEnd =    0x0A94;
                    NaviOffsetStart =    0x0AA0;
                    NaviOffsetEnd =      0x1050;
                    LibraryOffsetStart = 0x1080;
                    LibraryOffsetEnd =   0x1098;
    }
                else if (saveData.Length == 14976)
                {
                    GameName = GameTitle.Title.MegaManBattleNetwork2;
                    EqStyleOffset =      0x0001;
                    RegMemOffset =       0x0017;
                    RegChip1Offset =     0x001D;
                    RegChip2Offset =     0x001E;
                    RegChip3Offset =     0x001F;
                    CurrHPOffset =       0x0020;
                    MaxHPOffset =        0x0022;
                    HPRedundancy1 =      0x008C; // BN2 has two HP redundancies.
                    HPRedundancy2 =      0x008E;
                    ZennyOffset =        0x0074;
                    FoldersOffset =      0x0082;
                    AttackOffset =       0x0084;
                    RapidOffset =        0x0085;
                    ChargeOffset =       0x0086;
                    TimeOffset =         0x00A0;
                    ChecksumOffset =     0x00A8;
                    SteamOffset =        0x0104;
                    BugfragOffset =      0x0155;
                    HPUpOffset =         0x0170;
                    SubMaxOffset =       0x0175;
                    SubMiniOffset =      0x0180;
                    SubFullOffset =      0x0181;
                    SubSneakOffset =     0x0182;
                    SubUntrapOffset =    0x0183;
                    SubLocEnOffset =     0x0184;
                    SubUnlockerOffset =  0x0185;
                    StyleOffset =        0x0190;
                    FolderOffsetStart =  0x01B0;
                    FolderOffsetEnd =    0x0227;
                    Folder2OffsetStart = 0x0228;
                    Folder2OffsetEnd =   0x029F;
                    Folder3OffsetStart = 0x02A0;
                    Folder3OffsetEnd =   0x0317;
                    BattleOffsetStart =  0x032A;
                    BattleOffsetEnd =    0x10AF;
                    NaviOffsetStart =    0x10BC;
                    NaviOffsetEnd =      0x14B1;
                    SecretOffsetStart =  0x14BE;
                    SecretOffsetEnd =    0x162B;
                    LibraryOffsetStart = 0x1690;
                    LibraryOffsetEnd =   0x16B1;
                    PALibStart =         0x16CC;
                    PALibEnd =           0x16CF;
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
            saveDataObject.RapidPower =  saveData[RapidOffset];
            saveDataObject.ChargePower = saveData[ChargeOffset];
            saveDataObject.EqStyle = saveData[EqStyleOffset]; // I know this is armor for BN1, not styles but it's close enough.

            saveDataObject.CurrHP =   BitConverter.ToInt16(saveData, CurrHPOffset);
            saveDataObject.MaxHP =    BitConverter.ToInt16(saveData, MaxHPOffset);

            saveDataObject.Zenny =    BitConverter.ToInt32(saveData, ZennyOffset);

            saveDataObject.PlayTime = BitConverter.ToInt32(saveData, TimeOffset);

            saveDataObject.CheckSum = BitConverter.ToInt32(saveData, ChecksumOffset);
            saveDataObject.SteamID =  BitConverter.ToInt32(saveData, SteamOffset);

            saveDataObject.HPUp = saveData[HPUpOffset];
            saveDataObject.Folders = 1; // BN1 only has one folder. Just set it by default.

            for (int i = LibraryOffsetStart; i <= LibraryOffsetEnd; i++)
            {
                saveDataObject.LibraryData.Add(saveData[i]);
            }
            
            if (saveDataObject.GameName != GameTitle.Title.MegaManBattleNetwork) // BN1 is the only game without a PA Library.
            {
                for (int i = PALibStart; i <= PALibEnd; i++)
                {
                    saveDataObject.PALibraryData.Add(saveData[i]);
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

                    saveDataObject.RegMem = saveData[RegMemOffset];
                    saveDataObject.RegChip1 = saveData[RegChip1Offset];
                    saveDataObject.RegChip2 = saveData[RegChip2Offset];
                    saveDataObject.RegChip3 = saveData[RegChip3Offset];
                    saveDataObject.SubChipMax = saveData[SubMaxOffset];
                    saveDataObject.SubFullEnrg = saveData[SubFullOffset];
                    saveDataObject.SubLocEnemy = saveData[SubLocEnOffset];
                    saveDataObject.SubMiniEnrg = saveData[SubMiniOffset];
                    saveDataObject.SubSneakRun = saveData[SubSneakOffset];
                    saveDataObject.SubUnlocker = saveData[SubUnlockerOffset];
                    saveDataObject.SubUntrap = saveData[SubUntrapOffset];
                    saveDataObject.BugFrags = saveData[BugfragOffset];
                    saveDataObject.Folders = saveData[FoldersOffset];

                    for (int i = FolderOffsetStart; i <= Folder3OffsetEnd; i += 4) // BN2 has 3 Folders
                    {
                        int chipID = BitConverter.ToInt16(saveData, i);
                        int chipCode = BitConverter.ToInt16(saveData, i + 2);
                        if (i >= FolderOffsetStart && i <= FolderOffsetEnd)
                        {
                            saveDataObject.FolderData.Add(new Tuple<int, int>(chipID, chipCode));
                        } else if ( i >= Folder2OffsetStart && i <= Folder2OffsetEnd) // These values should all be 0 if not unlocked
                        {
                            saveDataObject.Folder2Data.Add(new Tuple<int, int>(chipID, chipCode)); 
                        } else if ( i >= Folder3OffsetStart && i <= Folder3OffsetEnd) // These values should all be 0 if not unlocked
                        {
                            saveDataObject.Folder3Data.Add(new Tuple<int, int>(chipID, chipCode));
                        }
                    }

                    for (int i = BattleOffsetStart; i <= BattleOffsetEnd; i += 0x12)
                    {
                        for (int j = 0; j < 6; j++) // Since most have 6 codes, just read all six.
                        {
                            saveDataObject.BattleChips.Add(saveData[i+j]);
                        }
                    }

                    for (int i = NaviOffsetStart; i <= NaviOffsetEnd; i += 0x12)
                    {
                        for (int j = 0; j < 6; j+=5) // We'll only need the first and last byte of each block.
                        {
                            saveDataObject.NaviChips.Add(saveData[i]);
                        }
                    }

                    for (int i = SecretOffsetStart; i <= SecretOffsetEnd; i+=0x12)
                    {
                        for (int j = 0; j < 6; j++) // Some act as Navi chips, some act as regular chips, just get them all.
                        {
                            saveDataObject.SecretChips.Add(saveData[i+j]);
                        }
                    }

                    break;
            }
            return saveDataObject;
        }

        public void UpdateSaveData(SaveDataObject saveDataObject)
        {
            // Let's write all of the data common to all games first
            saveData[AttackOffset] = saveDataObject.AttackPower;
            saveData[RapidOffset] = saveDataObject.RapidPower;
            saveData[ChargeOffset] = saveDataObject.ChargePower;
            saveData[EqStyleOffset] = saveDataObject.EqStyle;

            if (saveDataObject.CurrHP > 1000) // Cheating? In MY House? Not on my watch.
            {
                saveDataObject.CurrHP = 1000;
            }
            Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.CurrHP), 0, saveData, CurrHPOffset, 2);

            if (saveDataObject.MaxHP > 1000) // Yes, I understand the irony of that statement.
            {
                saveDataObject.MaxHP = 1000;
            }

            Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.MaxHP), 0, saveData, MaxHPOffset, 2);

            Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.Zenny), 0, saveData, ZennyOffset, 4);

            Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.SteamID), 0, saveData, SteamOffset, 4);

            saveData[HPUpOffset] = (byte)((saveDataObject.MaxHP - 100) / 20);

            for (int i = LibraryOffsetStart; i <= LibraryOffsetEnd; i++)
            {
                saveData[i] = saveDataObject.LibraryData[i - LibraryOffsetStart];
            }
            
            var index = 0; // This is a secret tool we'll use later!

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
                        switch(i)
                        {
                            case 1:
                                saveData[saveDataObject.StyleTypes[i]] = saveDataObject.Style1;
                                break;
                            case 2:
                                saveData[saveDataObject.StyleTypes[i]] = saveDataObject.Style2;
                                break;
                        } 
                    }

                    saveData[BugfragOffset] = (byte)saveDataObject.BugFrags;
                    saveData[SubFullOffset] = (byte)saveDataObject.SubFullEnrg;
                    saveData[SubLocEnOffset] = (byte)saveDataObject.SubLocEnemy;
                    saveData[SubMiniOffset] = (byte)saveDataObject.SubMiniEnrg;
                    saveData[SubSneakOffset] = (byte)saveDataObject.SubSneakRun;
                    saveData[SubUnlockerOffset] = (byte)saveDataObject.SubUnlocker;
                    saveData[SubUntrapOffset] = (byte)saveDataObject.SubUntrap;
                    saveData[SubMaxOffset] = (byte)saveDataObject.SubChipMax;
                    saveData[RegMemOffset] = (byte)saveDataObject.RegMem;
                    saveData[RegChip1Offset] = 0xFF; // Turn off the regular chips.
                    saveData[RegChip2Offset] = 0xFF;
                    saveData[RegChip3Offset] = 0xFF;

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

                    index = 0;
                    for (int i = NaviOffsetStart; i <= NaviOffsetEnd; i += 0x12)
                    {
                        for (int j = 0; j < 6; j += 5)
                        {
                            saveData[(i + j)] = saveDataObject.NaviChips[index];
                            index++;
                        }
                    }

                    index = 0;
                    for (int i = SecretOffsetStart; i < SecretOffsetEnd; i += 0x12)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            saveData[(i + j)] = saveDataObject.SecretChips[index];
                            index++;
                        }
                    }

                    for (int i = PALibStart; i <= PALibEnd; i++)
                    {
                            saveData[i] = saveDataObject.PALibraryData[(i - PALibStart)];
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