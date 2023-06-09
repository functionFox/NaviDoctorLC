using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NaviDoctor
{
    public class BN1SaveParse
    {
        private const int SaveDataSize = 8909;
        private const int ChecksumStartOffset = 0x00A0;
        private const int SteamIDStartOffset = 0x00BC;
        private string saveFilePath;
        private byte[] saveData;

        public BN1SaveParse(string filePath)
        {
            saveFilePath = filePath;
            ReadSaveFile();
        }

        private void ReadSaveFile()
        {
            try
            {
                saveData = File.ReadAllBytes(saveFilePath);
                if (saveData.Length != SaveDataSize)
                {
                    throw new Exception("Invalid save file size.");
                }
            }
            catch
            {
                throw;
            }
        }

        public BN1SaveDataObject ExtractSaveData()
        {
            BN1SaveDataObject saveDataObject = new BN1SaveDataObject();

            saveDataObject.GameName = "Mega Man Battle Network";

            saveDataObject.AttackPower = saveData[0x0014];
            saveDataObject.RapidPower = saveData[0x0015];
            saveDataObject.ChargePower = saveData[0x0016];
            saveDataObject.EqArmor = saveData[0x0017];

            saveDataObject.CurrHP = BitConverter.ToInt16(saveData, 0x001C);
            saveDataObject.MaxHP = BitConverter.ToInt16(saveData, 0x001E);

            saveDataObject.Zenny = BitConverter.ToInt32(saveData, 0x0074);

            saveDataObject.PlayTime = BitConverter.ToInt32(saveData, 0x0098);

            saveDataObject.CheckSum = BitConverter.ToInt32(saveData, 0x00A0);
            saveDataObject.SteamID = BitConverter.ToInt32(saveData, 0x00BC);

            saveDataObject.HPUp = saveData[0x0100];

            saveDataObject.HaveHeatArmr = saveData[0x0104];
            saveDataObject.HaveAquaArmr = saveData[0x0105];
            saveDataObject.HaveWoodArmr = saveData[0x0106];

            saveDataObject.BugFrags = 0; // BN1 is the only game without BugFrags, just set it to 0.

            for (int i = 0x0120; i <= 0x015B; i += 2)
            {
                byte chipID = saveData[i];
                byte chipCode = saveData[i + 1];
                saveDataObject.FolderData.Add(new Tuple<byte, byte>(chipID, chipCode));
            }

            for (int i = 0x0170; i <= 0x0A94; i++)
            {
                if (i % 0x10 <= 0x4)
                {
                    saveDataObject.BattleChips.Add(saveData[i]);
                }
            }

            for (int i = 0x0AA0; i <= 0x1050; i += 0x10)
            {
                saveDataObject.NaviChips.Add(saveData[i]);
            }


            for (int i = 0x1080; i <= 0x1098; i++)
            {
                saveDataObject.LibraryData.Add(saveData[i]);
            }

            return saveDataObject;
        }

        public void UpdateSaveData(BN1SaveDataObject saveDataObject)
        {
            
            saveData[0x0014] = saveDataObject.AttackPower;
            saveData[0x0015] = saveDataObject.RapidPower;
            saveData[0x0016] = saveDataObject.ChargePower;
            saveData[0x0017] = saveDataObject.EqArmor;
            
            if (saveDataObject.CurrHP > 1000) // Cheating? In MY House? Not on my watch.
            {
                saveDataObject.CurrHP = 1000;
            }
            Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.CurrHP), 0, saveData, 0x001C, 2);
            
            if (saveDataObject.MaxHP > 1000) // Yes, I understand the irony of that statement.
            {
                saveDataObject.MaxHP = 1000;
            }
            
            Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.MaxHP), 0, saveData, 0x001E, 2);

            Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.Zenny), 0, saveData, 0x0074, 4);

            Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.PlayTime), 0, saveData, 0x0098, 4);

            Buffer.BlockCopy(BitConverter.GetBytes(saveDataObject.SteamID), 0, saveData, 0x00BC, 4);
            
            saveData[0x0100] = (byte)((saveDataObject.MaxHP - 100)/20);
            saveData[0x0104] = saveDataObject.HaveHeatArmr;
            saveData[0x0105] = saveDataObject.HaveAquaArmr;
            saveData[0x0106] = saveDataObject.HaveWoodArmr;
            
            for (int i = 0x0120; i <= 0x015B; i += 2)
            {
                Tuple<byte, byte> value = saveDataObject.FolderData[(i - 0x0120) / 2];
                saveData[i] = value.Item1;
                saveData[i + 1] = value.Item2;
            }
            
                    
            int index = 0;
            for (int i = 0x0170; i < 0x0A95; i++)
            {
                if ((i % 0x10) <= 0x4)  // Check if i is within the range 0 to 4 for every group of 10 elements
                {
                    saveData[i] = saveDataObject.BattleChips[index];
                    index++;
                }
            }
            
            index = 0;
            for (int i = 0x0AA0; i <= 0x1050; i += 0x10)
            {
                saveData[i] = saveDataObject.NaviChips[index];
                index++;
            }
            
            index = 0;
            for (int i = 0x1080; i <= 0x1098; i++)
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
            Buffer.BlockCopy(BitConverter.GetBytes(checksum), 0, saveData, ChecksumStartOffset, 4); // erase the current checksum
            if (BitConverter.ToUInt32(saveData, SteamIDStartOffset) == 0) // Switch doesn't use checksum or Steam ID, so no need to go further
            {
                return;
            }
            else
            {
                for (int i = SteamIDStartOffset; i <= SteamIDStartOffset+3; i++)
                {
                    steamsum += saveData[i];
                }    
                foreach (byte dataByte in saveData)
                {
                    checksum += dataByte; // Calculate the checksum
                }
            }
            checksum -= steamsum; // Subtract the Steam ID from the checksum
            Buffer.BlockCopy(BitConverter.GetBytes(checksum), 0, saveData, ChecksumStartOffset, 4);
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

    public class BN1SaveDataObject : SaveDataObject
    {
        public byte EqArmor { get; set; }
        public byte HaveHeatArmr { get; set; }
        public byte HaveAquaArmr { get; set; }
        public byte HaveWoodArmr { get; set; }
    }
}