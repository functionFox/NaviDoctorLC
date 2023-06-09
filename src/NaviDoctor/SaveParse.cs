using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NaviDoctor
{
    public class SaveParse
    {
        private string GameName;
        private int ChecksumOffset;
        private int SteamOffset;
        private int AttackOffset;
        private int RapidOffset;
        private int ChargeOffset;
        private int EqStyleOffset;
        private int CurrHPOffset;
        private int MaxHPOffset;
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
        private string saveFilePath;
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
                    GameName = "Mega Man Battle Network";
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
                    GameName = "Mega Man Battle Network 2";
                    EqStyleOffset = 0x0001;
                    RegMemOffset = 0x0017;
                    RegChip1Offset = 0x001D;
                    RegChip2Offset = 0x001E;
                    RegChip3Offset = 0x001F;
                    CurrHPOffset = 0x0020;
                    MaxHPOffset = 0x0022;
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
            saveDataObject.EqStyle = saveData[EqStyleOffset]; // I know this is armor for BN1, not styles but it's close enough and you store 3.

            saveDataObject.CurrHP = BitConverter.ToInt16(saveData, CurrHPOffset);
            saveDataObject.MaxHP = BitConverter.ToInt16(saveData, MaxHPOffset);

            saveDataObject.Zenny = BitConverter.ToInt32(saveData, ZennyOffset);

            saveDataObject.PlayTime = BitConverter.ToInt32(saveData, TimeOffset);

            saveDataObject.CheckSum = BitConverter.ToInt32(saveData, ChecksumOffset);
            saveDataObject.SteamID = BitConverter.ToInt32(saveData, SteamOffset);

            saveDataObject.HPUp = saveData[HPUpOffset];


            if (saveDataObject.GameName == "Mega Man Battle Network")
            {
                saveDataObject.Style1 = saveData[StyleOffset]; // For BN1, this is HeatArmr. For BN2, this is a range of addresses.
                saveDataObject.Style2 = saveData[StyleOffset + 0x1]; // For BN1, this is AquaArmr
                saveDataObject.Style3 = saveData[StyleOffset + 0x2]; // For BN1, this is not ElecArmr
            }
            else
            {
                // ADD A PARSE HERE FOR THE RANGE OF ADDRESSES IN BN2

                saveDataObject.RegMem = 0; // BN1 doesn't use these. Just skip these unless the game is BN2+.
                saveDataObject.SubChipMax = 0;
                saveDataObject.SubFullEnrg = 0;
                saveDataObject.SubLocEnemy = 0;
                saveDataObject.SubMiniEnrg = 0;
                saveDataObject.SubSneakRun = 0;
                saveDataObject.SubUnlocker = 0;
                saveDataObject.SubUntrap = 0;
                saveDataObject.BugFrags = 0;
            }

            for (int i = FolderOffsetStart; i <= FolderOffsetEnd; i += 2) // Will have to adjust the algorithms for BN2
            {
                byte chipID = saveData[i];
                byte chipCode = saveData[i + 1];
                saveDataObject.FolderData.Add(new Tuple<byte, byte>(chipID, chipCode));
            }

            for (int i = BattleOffsetStart; i <= BattleOffsetEnd; i++) // Will have to adjust the algorithms for BN2
            {
                if (i % 0x10 <= 0x4)
                {
                    saveDataObject.BattleChips.Add(saveData[i]);
                }
            }

            for (int i = NaviOffsetStart; i <= NaviOffsetEnd; i += 0x10) // Will have to adjust the algorithms for BN2
            {
                saveDataObject.NaviChips.Add(saveData[i]);
            }


            for (int i = LibraryOffsetStart; i <= LibraryOffsetEnd; i++)
            {
                saveDataObject.LibraryData.Add(saveData[i]);
            }

            return saveDataObject;
        }

        public void UpdateSaveData(SaveDataObject saveDataObject)
        {

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

            Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.PlayTime), 0, saveData, TimeOffset, 4);

            Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.SteamID), 0, saveData, SteamOffset, 4);

            saveData[HPUpOffset] = (byte)((saveDataObject.MaxHP - 100) / 20);
            saveData[StyleOffset] = saveDataObject.Style1;
            saveData[StyleOffset + 0x1] = saveDataObject.Style2;
            saveData[StyleOffset + 0x2] = saveDataObject.Style3;

            for (int i = FolderOffsetStart; i <= FolderOffsetEnd; i += 2) // Obviously, need to adjust the algo for BN2
            {
                Tuple<byte, byte> value = saveDataObject.FolderData[(i - FolderOffsetStart) / 2];
                saveData[i] = value.Item1;
                saveData[i + 1] = value.Item2;
            }


            int index = 0;
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

            index = 0;
            for (int i = LibraryOffsetStart; i <= LibraryOffsetEnd; i++)
            {
                saveData[i] = saveDataObject.LibraryData[index];
                index++;
            }

            CalculateAndWriteChecksum();

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