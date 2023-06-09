﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NaviDoctor
{
    public class BattleChipData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }

        public BattleChipData()
        {
        }
        
        private static Dictionary<int, string> BN1ChipNameMap = new Dictionary<int, string>()
        {
            { 1, "Cannon" },
            { 2, "HiCannon" },
            { 3, "M-Cannon" },
            { 4, "Sword" },
            { 5, "WideSwrd" },
            { 6, "LongSwrd" },
            { 7, "LilBomb" },
            { 8, "CrosBomb" },
            { 9, "BigBomb" },
            { 10, "Spreader" },
            { 11, "Bubbler" },
            { 12, "Heater" },
            { 13, "MiniBomb" },
            { 14, "Shotgun" },
            { 15, "Crossgun" },
            { 16, "ShokWave" },
            { 17, "SoniWave" },
            { 18, "DynaWave" },
            { 19, "FireTowr" },
            { 20, "AquaTowr" },
            { 21, "WoodTowr" },
            { 22, "Quake1" },
            { 23, "Quake2" },
            { 24, "Quake3" },
            { 25, "FireSwrd" },
            { 26, "ElecSwrd" },
            { 27, "AquaSwrd" },
            { 28, "GutsPnch" },
            { 29, "IcePunch" },
            { 30, "FtrSwrd" },
            { 31, "Dash" },
            { 32, "KngtSwrd" },
            { 33, "HeroSwrd" },
            { 34, "MetGuard" },
            { 35, "23" },
            { 36, "24" },
            { 37, "TriArrow" },
            { 38, "TriSpear" },
            { 39, "TriLance" },
            { 40, "Typhoon" },
            { 41, "Huricane" },
            { 42, "Cyclone" },
            { 43, "Howitzer" },
            { 44, "Thunder1" },
            { 45, "Thunder2" },
            { 46, "Thunder3" },
            { 47, "2F" },
            { 48, "30" },
            { 49, "Snakegg1" },
            { 50, "Snakegg2" },
            { 51, "Snakegg3" },
            { 52, "Hammer" },
            { 53, "35" },
            { 54, "36" },
            { 55, "Bodyburn" },
            { 56, "38" },
            { 57, "39" },
            { 58, "Ratton1" },
            { 59, "Ratton2" },
            { 60, "Ratton3" },
            { 61, "Lockon1" },
            { 62, "Lockon2" },
            { 63, "Lockon3" },
            { 64, "X-Panel1" },
            { 65, "X-Panel3" },
            { 66, "42" },
            { 67, "Recov10" },
            { 68, "Recov30" },
            { 69, "Recov50" },
            { 70, "Recov80" },
            { 71, "Recov120" },
            { 72, "Recov150" },
            { 73, "Recov200" },
            { 74, "Recov300" },
            { 75, "4B" },
            { 76, "Steal" },
            { 77, "4D" },
            { 78, "4E" },
            { 79, "Geddon1" },
            { 80, "Geddon2" },
            { 81, "51" },
            { 82, "Escape" },
            { 83, "Interupt" },
            { 84, "LifeAura" },
            { 85, "AquaAura" },
            { 86, "FireAura" },
            { 87, "WoodAura" },
            { 88, "Repair" },
            { 89, "59" },
            { 90, "5A" },
            { 91, "Cloud" },
            { 92, "Cloudier" },
            { 93, "Cloudest" },
            { 94, "IceCube" },
            { 95, "RockCube" },
            { 96, "60" },
            { 97, "TimeBom1" },
            { 98, "TimeBom2" },
            { 99, "TimeBom3" },
            { 100, "Invis1" },
            { 101, "Invis2" },
            { 102, "Invis3" },
            { 103, "IronBody" },
            { 104, "68" },
            { 105, "Remobit1" },
            { 106, "Remobit2" },
            { 107, "Remobit3" },
            { 108, "BstrGard" },
            { 109, "BstrBomb" },
            { 110, "BstrSwrd" },
            { 111, "BstrPnch" },
            { 112, "RingZap1" },
            { 113, "RingZap2" },
            { 114, "RingZap3" },
            { 115, "Candle1" },
            { 116, "Candle2" },
            { 117, "Candle3" },
            { 118, "SloGauge" },
            { 119, "FstGauge" },
            { 120, "78" },
            { 121, "Drain1" },
            { 122, "Drain2" },
            { 123, "Drain3" },
            { 124, "Mine1" },
            { 125, "Mine2" },
            { 126, "Mine3" },
            { 127, "Gaia1" },
            { 128, "Gaia2" },
            { 129, "Gaia3" },
            { 130, "BblWrap1" },
            { 131, "BblWrap2" },
            { 132, "BblWrap3" },
            { 133, "Wave" },
            { 134, "RedWave" },
            { 135, "BigWave" },
            { 136, "Muramasa" },
            { 137, "Dropdown" },
            { 138, "Popup" },
            { 139, "Dynamyt1" },
            { 140, "Dynamyt2" },
            { 141, "Dynamyt3" },
            { 142, "Anubis" },
            { 143, "8F" },
            { 144, "90" },
            { 145, "IronShld" },
            { 146, "LeafShld" },
            { 147, "Barrier" },
            { 148, "PharoMan" },
            { 149, "PharoMn2" },
            { 150, "PharoMn3" },
            { 151, "ShadoMan" },
            { 152, "ShadoMn2" },
            { 153, "ShadoMn3" },
            { 154, "9A" },
            { 155, "9B" },
            { 156, "9C" },
            { 157, "MagicMan" },
            { 158, "MagicMn2" },
            { 159, "MagicMn3" },
            { 160, "Roll" },
            { 161, "Roll2" },
            { 162, "Roll3" },
            { 163, "GutsMan" },
            { 164, "GutsMan2" },
            { 165, "GutsMan3" },
            { 166, "ProtoMan" },
            { 167, "ProtoMn2" },
            { 168, "ProtoMn3" },
            { 169, "WoodMan" },
            { 170, "WoodMan2" },
            { 171, "WoodMan3" },
            { 172, "FireMan" },
            { 173, "FireMan2" },
            { 174, "FireMan3" },
            { 175, "NumbrMan" },
            { 176, "NumbrMn2" },
            { 177, "NumbrMn3" },
            { 178, "StoneMan" },
            { 179, "StoneMn2" },
            { 180, "StoneMn3" },
            { 181, "IceMan" },
            { 182, "IceMan2" },
            { 183, "IceMan3" },
            { 184, "SkullMan" },
            { 185, "SkullMn2" },
            { 186, "SkullMn3" },
            { 187, "ColorMan" },
            { 188, "ColorMn2" },
            { 189, "ColorMn3" },
            { 190, "BombMan" },
            { 191, "BombMan2" },
            { 192, "BombMan3" },
            { 193, "SharkMan" },
            { 194, "SharkMn2" },
            { 195, "SharkMn3" },
            { 196, "ElecMan" },
            { 197, "ElecMan2" },
            { 198, "ElecMan3" },
            { 199, "Bass" },
            { 200, "C8" },
            { 201, "C9" },
            { 202, "Z-Canon1" },
            { 203, "Z-Canon2" },
            { 204, "Z-Canon3" },
            { 205, "Z-Spread" },
            { 206, "Z-Raton1" },
            { 207, "Z-Raton2" },
            { 208, "Z-Raton3" },
            { 209, "Z-Arrow" },
            { 210, "Z-Spear" },
            { 211, "Z-Lance" },
            { 212, "O-Canon1" },
            { 213, "O-Canon2" },
            { 214, "O-Canon3" },
            { 215, "O-Spread" },
            { 216, "O-Raton1" },
            { 217, "O-Raton2" },
            { 218, "O-Raton3" },
            { 219, "O-Arrow" },
            { 220, "O-Spear" },
            { 221, "O-Lance" },
            { 222, "B-Bomb" },
            { 223, "B-Sword" },
            { 224, "B-Wave" },
            { 225, "B-Quake" },
            { 226, "S-Bomb" },
            { 227, "S-Sword" },
            { 228, "S-Wave" },
            { 229, "S-Quake" },
            { 230, "PwrCanon" },
            { 231, "HvyStamp" },
            { 232, "BgStrait" },
            { 233, "BloodSuk" },
            { 234, "Storm" },
            { 235, "GtsShoot" },
            { 236, "LifeSavr" },
            { 237, "2xHero" },
            { 238, "EE" },
            { 239, "EF" }
        };

        public static string GetChipNameByID(int chipID)
        {
            if (BN1ChipNameMap.ContainsKey(chipID))
            {
                return BN1ChipNameMap[chipID];
            }
            return "Unknown";
        }

        public static int GetChipIDByName(string chipName)
        {
            foreach (KeyValuePair<int, string> chipEntry in BN1ChipNameMap)
            {
                if (chipEntry.Value.Equals(chipName))
                {
                    return chipEntry.Key;
                }
            }
            // If the chip name is not found, return a default value
            return -1;
        }

        public List<BattleChipData> GenerateChipEntries()
        {
            List<BattleChipData> chipEntries = new List<BattleChipData>();

            // Mapping of chip names to their associated chip codes
            Dictionary<string, List<string>> chipCodeMap = new Dictionary<string, List<string>>()
            {
                { "Cannon",   new List<string> { "A", "B", "C", "D", "E" } },
                { "HiCannon", new List<string> { "F", "G", "H", "I", "J" } },
                { "M-Cannon", new List<string> { "K", "L", "M", "N", "O" } },
                { "Sword",    new List<string> { "B", "K", "L", "P", "S" } },
                { "WideSwrd", new List<string> { "C", "K", "M", "N", "S" } },
                { "LongSwrd", new List<string> { "D", "E", "N", "O", "S" } },
                { "LilBomb",  new List<string> { "B", "D", "G", "O", "T" } },
                { "CrosBomb", new List<string> { "B", "D", "H", "J", "L" } },
                { "BigBomb",  new List<string> { "B", "G", "O", "S", "T" } },
                { "Spreader", new List<string> { "H", "I", "J", "K", "L" } },
                { "Bubbler",  new List<string> { "A", "K", "L", "P", "S" } },
                { "Heater",   new List<string> { "C", "F", "G", "K", "O" } },
                { "MiniBomb", new List<string> { "C", "E", "J", "L", "P" } },
                { "Shotgun",  new List<string> { "K", "M", "N", "Q", "R" } },
                { "Crossgun", new List<string> { "C", "E", "F", "J", "K" } },
                { "ShokWave", new List<string> { "C", "K", "L", "N", "P" } },
                { "SoniWave", new List<string> { "C", "D", "J", "M", "S" } },
                { "DynaWave", new List<string> { "C", "E", "M", "R", "S" } },
                { "FireTowr", new List<string> { "E", "F", "L", "M", "T" } },
                { "AquaTowr", new List<string> { "A", "C", "G", "H", "R" } },
                { "WoodTowr", new List<string> { "B", "C", "H", "K", "N" } },
                { "Quake1",   new List<string> { "A", "E", "H", "K", "Q" } },
                { "Quake2",   new List<string> { "B", "C", "I", "K", "Q" } },
                { "Quake3",   new List<string> { "C", "D", "H", "M", "Q" } },
                { "FireSwrd", new List<string> { "B", "F", "G", "N", "P" } },
                { "ElecSwrd", new List<string> { "E", "G", "L", "O", "S" } },
                { "AquaSwrd", new List<string> { "A", "M", "N", "O", "P" } },
                { "GutsPnch", new List<string> { "B", "H", "M", "N", "T" } },
                { "IcePunch", new List<string> { "B", "H", "M", "N", "T" } },
                { "FtrSwrd",  new List<string> { "B", "K", "L", "P", "S" } },
                { "Dash",     new List<string> { "B", "D", "G", "L", "O" } },
                { "KngtSwrd", new List<string> { "B", "C", "E", "G", "H" } },
                { "HeroSwrd", new List<string> { "B", "D", "F", "I", "J" } },
                { "MetGuard", new List<string> { "A", "C", "E", "G", "L" } },
                { "23",  new List<string> { "None", "None", "None", "None", "None" } },
                { "24",  new List<string> { "None", "None", "None", "None", "None" } },
                { "TriArrow", new List<string> { "A", "B", "C", "D", "E" } },
                { "TriSpear", new List<string> { "F", "G", "H", "I", "J" } },
                { "TriLance", new List<string> { "K", "L", "M", "N", "O" } },
                { "Typhoon",  new List<string> { "A", "B", "D", "E", "G" } },
                { "Huricane", new List<string> { "G", "I", "J", "K", "L" } },
                { "Cyclone",  new List<string> { "E", "F", "G", "H", "I" } },
                { "Howitzer", new List<string> { "A", "C", "G", "H", "O" } },
                { "Thunder1", new List<string> { "A", "E", "G", "H", "S" } },
                { "Thunder2", new List<string> { "B", "C", "F", "I", "L" } },
                { "Thunder3", new List<string> { "D", "F", "G", "K", "N" } },
                { "2F",  new List<string> { "None", "None", "None", "None", "None" } },
                { "30",  new List<string> { "None", "None", "None", "None", "None" } },
                { "Snakegg1", new List<string> { "B", "E", "G", "M", "N" } },
                { "Snakegg2", new List<string> { "C", "E", "H", "N", "P" } },
                { "Snakegg3", new List<string> { "A", "C", "F", "L", "S" } },
                { "Hammer",   new List<string> { "A", "F", "I", "M", "Q" } },
                { "35",  new List<string> { "None", "None", "None", "None", "None" } },
                { "36",  new List<string> { "None", "None", "None", "None", "None" } },
                { "Bodyburn", new List<string> { "E", "F", "K", "M", "N" } },
                { "38",  new List<string> { "None", "None", "None", "None", "None" } },
                { "39",  new List<string> { "None", "None", "None", "None", "None" } },
                { "Ratton1",  new List<string> { "A", "B", "C", "D", "E" } },
                { "Ratton2",  new List<string> { "F", "G", "H", "I", "J" } },
                { "Ratton3",  new List<string> { "K", "L", "M", "N", "O" } },
                { "Lockon1",  new List<string> { "C", "D", "H", "I", "L" } },
                { "Lockon2",  new List<string> { "B", "E", "G", "H", "M" } },
                { "Lockon3",  new List<string> { "A", "D", "K", "N", "O" } },
                { "X-Panel1", new List<string> { "B", "D", "G", "L", "S" } },
                { "X-Panel3", new List<string> { "B", "D", "G", "L", "S" } },
                { "42",  new List<string> { "None", "None", "None", "None", "None" } },
                { "Recov10",  new List<string> { "A", "C", "E", "G", "L" } },
                { "Recov30",  new List<string> { "A", "C", "E", "G", "L" } },
                { "Recov50",  new List<string> { "A", "C", "E", "G", "L" } },
                { "Recov80",  new List<string> { "A", "C", "E", "G", "L" } },
                { "Recov120", new List<string> { "A", "C", "E", "G", "L" } },
                { "Recov150", new List<string> { "A", "C", "E", "G", "L" } },
                { "Recov200", new List<string> { "A", "C", "E", "G", "L" } },
                { "Recov300", new List<string> { "A", "C", "E", "G", "L" } },
                { "4B",  new List<string> { "None", "None", "None", "None", "None" } },
                { "Steal",    new List<string> { "A", "E", "L", "P", "S" } },
                { "4D",  new List<string> { "None", "None", "None", "None", "None" } },
                { "4E",  new List<string> { "None", "None", "None", "None", "None" } },
                { "Geddon1",  new List<string> { "F", "H", "J", "L", "N" } },
                { "Geddon2",  new List<string> { "A", "B", "E", "I", "K" } },
                { "51",  new List<string> { "None", "None", "None", "None", "None" } },
                { "Escape",   new List<string> { "F", "H", "J", "L", "N" } },
                { "Interupt", new List<string> { "F", "H", "J", "L", "N" } },
                { "LifeAura", new List<string> { "A", "H", "K", "M", "P" } },
                { "AquaAura", new List<string> { "D", "E", "L", "R", "S" } },
                { "FireAura", new List<string> { "B", "G", "I", "N", "T" } },
                { "WoodAura", new List<string> { "C", "F", "J", "O", "Q" } },
                { "Repair",   new List<string> { "A", "G", "H", "K", "S" } },
                { "59",  new List<string> { "None", "None", "None", "None", "None" } },
                { "5A",  new List<string> { "None", "None", "None", "None", "None" } },
                { "Cloud",    new List<string> { "B", "G", "H", "O", "R" } },
                { "Cloudier", new List<string> { "A", "D", "I", "M", "P" } },
                { "Cloudest", new List<string> { "C", "F", "J", "K", "O" } },
                { "IceCube",  new List<string> { "A", "C", "I", "L", "M" } },
                { "RockCube", new List<string> { "B", "E", "G", "M", "O" } },
                { "60",  new List<string> { "None", "None", "None", "None", "None" } },
                { "TimeBom1", new List<string> { "E", "G", "J", "L", "Q" } },
                { "TimeBom2", new List<string> { "C", "F", "J", "L", "S" } },
                { "TimeBom3", new List<string> { "A", "B", "G", "O", "P" } },
                { "Invis1",   new List<string> { "I", "J", "L", "O", "Q" } },
                { "Invis2",   new List<string> { "A", "C", "F", "J", "M" } },
                { "Invis3",   new List<string> { "B", "D", "H", "K", "N" } },
                { "IronBody", new List<string> { "C", "D", "L", "Q", "R" } },
                { "68",  new List<string> { "None", "None", "None", "None", "None" } },
                { "Remobit1", new List<string> { "A", "C", "F", "N", "O" } },
                { "Remobit2", new List<string> { "B", "D", "E", "H", "I" } },
                { "Remobit3", new List<string> { "G", "J", "K", "P", "Q" } },
                { "BstrGard", new List<string> { "A", "G", "K", "N", "R" } },
                { "BstrBomb", new List<string> { "D", "H", "J", "O", "T" } },
                { "BstrSwrd", new List<string> { "B", "E", "L", "P", "S" } },
                { "BstrPnch", new List<string> { "C", "F", "I", "M", "Q" } },
                { "RingZap1", new List<string> { "G", "H", "M", "N", "P" } },
                { "RingZap2", new List<string> { "C", "E", "G", "J", "L" } },
                { "RingZap3", new List<string> { "A", "B", "O", "R", "T" } },
                { "Candle1",  new List<string> { "C", "F", "I", "P", "S" } },
                { "Candle2",  new List<string> { "B", "E", "G", "J", "L" } },
                { "Candle3",  new List<string> { "A", "D", "H", "K", "M" } },
                { "SloGauge", new List<string> { "H", "K", "N", "O", "Q" } },
                { "FstGauge", new List<string> { "A", "C", "E", "L", "N" } },
                { "78",  new List<string> { "None", "None", "None", "None", "None" } },
                { "Drain1",   new List<string> { "A", "B", "D", "K", "O" } },
                { "Drain2",   new List<string> { "A", "C", "H", "N", "T" } },
                { "Drain3",   new List<string> { "A", "E", "F", "L", "Q" } },
                { "Mine1",    new List<string> { "G", "H", "M", "N", "P" } },
                { "Mine2",    new List<string> { "C", "E", "G", "J", "L" } },
                { "Mine3",    new List<string> { "A", "B", "O", "R", "T" } },
                { "Gaia1",    new List<string> { "C", "D", "L", "O", "T" } },
                { "Gaia2",    new List<string> { "C", "F", "K", "P", "S" } },
                { "Gaia3",    new List<string> { "C", "G", "M", "N", "T" } },
                { "BblWrap1", new List<string> { "C", "E", "G", "I", "M" } },
                { "BblWrap2", new List<string> { "D", "F", "H", "K", "N" } },
                { "BblWrap3", new List<string> { "A", "B", "L", "Q", "R" } },
                { "Wave",     new List<string> { "A", "D", "I", "L", "M" } },
                { "RedWave",  new List<string> { "B", "E", "J", "N", "P" } },
                { "BigWave",  new List<string> { "C", "H", "K", "L", "Q" } },
                { "Muramasa", new List<string> { "C", "E", "G", "J", "K" } },
                { "Dropdown", new List<string> { "A", "B", "O", "R", "T" } },
                { "Popup",    new List<string> { "C", "D", "H", "K", "N" } },
                { "Dynamyt1", new List<string> { "B", "G", "O", "Q", "S" } },
                { "Dynamyt2", new List<string> { "A", "C", "K", "M", "N" } },
                { "Dynamyt3", new List<string> { "G", "K", "M", "O", "P" } },
                { "Anubis",   new List<string> { "C", "L", "N", "Q", "T" } },
                { "8F",  new List<string> { "None", "None", "None", "None", "None" } },
                { "90",  new List<string> { "None", "None", "None", "None", "None" } },
                { "IronShld", new List<string> { "A", "B", "O", "R", "T" } },
                { "LeafShld", new List<string> { "C", "D", "F", "K", "Q" } },
                { "Barrier",  new List<string> { "D", "F", "M", "R", "S" } },
                { "PharoMan", new List<string> { "P" } },
                { "PharoMn2", new List<string> { "P" } },
                { "PharoMn3", new List<string> { "P" } },
                { "ShadoMan", new List<string> { "S" } },
                { "ShadoMn2", new List<string> { "S" } },
                { "ShadoMn3", new List<string> { "S" } },
                { "9A",  new List<string> { "None" } },
                { "9B",  new List<string> { "None" } },
                { "9C",  new List<string> { "None" } },
                { "MagicMan", new List<string> { "M" } },
                { "MagicMn2", new List<string> { "M" } },
                { "MagicMn3", new List<string> { "M" } },
                { "Roll",     new List<string> { "R" } },
                { "Roll2",    new List<string> { "R" } },
                { "Roll3",    new List<string> { "R" } },
                { "GutsMan",  new List<string> { "G" } },
                { "GutsMan2", new List<string> { "G" } },
                { "GutsMan3", new List<string> { "G" } },
                { "ProtoMan", new List<string> { "B" } },
                { "ProtoMn2", new List<string> { "B" } },
                { "ProtoMn3", new List<string> { "B" } },
                { "WoodMan",  new List<string> { "W" } },
                { "WoodMan2", new List<string> { "W" } },
                { "WoodMan3", new List<string> { "W" } },
                { "FireMan",  new List<string> { "F" } },
                { "FireMan2", new List<string> { "F" } },
                { "FireMan3", new List<string> { "F" } },
                { "NumbrMan", new List<string> { "N" } },
                { "NumbrMn2", new List<string> { "N" } },
                { "NumbrMn3", new List<string> { "N" } },
                { "StoneMan", new List<string> { "S" } },
                { "StoneMn2", new List<string> { "S" } },
                { "StoneMn3", new List<string> { "S" } },
                { "IceMan",   new List<string> { "I" } },
                { "IceMan2",  new List<string> { "I" } },
                { "IceMan3",  new List<string> { "I" } },
                { "SkullMan", new List<string> { "S" } },
                { "SkullMn2", new List<string> { "S" } },
                { "SkullMn3", new List<string> { "S" } },
                { "ColorMan", new List<string> { "C" } },
                { "ColorMn2", new List<string> { "C" } },
                { "ColorMn3", new List<string> { "C" } },
                { "BombMan",  new List<string> { "B" } },
                { "BombMan2", new List<string> { "B" } },
                { "BombMan3", new List<string> { "B" } },
                { "SharkMan", new List<string> { "S" } },
                { "SharkMn2", new List<string> { "S" } },
                { "SharkMn3", new List<string> { "S" } },
                { "ElecMan",  new List<string> { "E" } },
                { "ElecMan2", new List<string> { "E" } },
                { "ElecMan3", new List<string> { "E" } },
                { "Bass",     new List<string> { "F" } },
                { "C8",  new List<string> { "None" } },
                { "C9",  new List<string> { "None" } },
                { "Z-Canon1", new List<string> { "None" } },
                { "Z-Canon2", new List<string> { "None" } },
                { "Z-Canon3", new List<string> { "None" } },
                { "Z-Spread", new List<string> { "None" } },
                { "Z-Raton1", new List<string> { "None" } },
                { "Z-Raton2", new List<string> { "None" } },
                { "Z-Raton3", new List<string> { "None" } },
                { "Z-Arrow",  new List<string> { "None" } },
                { "Z-Spear",  new List<string> { "None" } },
                { "Z-Lance",  new List<string> { "None" } },
                { "O-Canon1", new List<string> { "None" } },
                { "O-Canon2", new List<string> { "None" } },
                { "O-Canon3", new List<string> { "None" } },
                { "O-Spread", new List<string> { "None" } },
                { "O-Raton1", new List<string> { "None" } },
                { "O-Raton2", new List<string> { "None" } },
                { "O-Raton3", new List<string> { "None" } },
                { "O-Arrow",  new List<string> { "None" } },
                { "O-Spear",  new List<string> { "None" } },
                { "O-Lance",  new List<string> { "None" } },
                { "B-Bomb",   new List<string> { "None" } },
                { "B-Sword",  new List<string> { "None" } },
                { "B-Wave",   new List<string> { "None" } },
                { "B-Quake",  new List<string> { "None" } },
                { "S-Bomb",   new List<string> { "None" } },
                { "S-Sword",  new List<string> { "None" } },
                { "S-Wave",   new List<string> { "None" } },
                { "S-Quake",  new List<string> { "None" } },
                { "PwrCanon", new List<string> { "None" } },
                { "HvyStamp", new List<string> { "None" } },
                { "BgStrait", new List<string> { "None" } },
                { "BloodSuk", new List<string> { "None" } },
                { "Storm",    new List<string> { "None" } },
                { "GtsShoot", new List<string> { "None" } },
                { "LifeSavr", new List<string> { "None" } },
                { "2xHero",   new List<string> { "None" } },
                { "EE",  new List<string> { "None" } },
                { "EF",  new List<string> { "None" } }
            };

            // Generate chip entries for each chip name and associated codes
            foreach (var kvp in chipCodeMap)
            {
                string chipName = kvp.Key;
                List<string> chipCodes = kvp.Value;

                foreach (var chipCode in chipCodes)
                {
                    BattleChipData chipEntry = new BattleChipData
                    {
                        ID = GetChipIDByName(chipName),
                        Name = chipName,
                        Code = chipCode,
                        Quantity = 0 // Set the initial quantity to 0
                    };

                    chipEntries.Add(chipEntry);
                }
            }
            return chipEntries;
        }

    }
}

