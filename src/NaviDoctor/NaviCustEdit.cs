using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NaviDoctor.models;

namespace NaviDoctor
{
    public partial class NaviCustEdit : Form
    {
        private int _maxHP;
        private int _hpUp;
        private int _custSize;
        private int _atkBonus;
        private int _spdBonus;
        private int _chrgBonus;
        private int _cShotBonus;
        private List<byte> _ncpInv;
        private List<byte> _compression;
        private List<byte[]> _ncpGrid;
        private byte[,] _gridPos;
        private List<byte> _effects;
        private List<byte> _bugs;
        private byte _modCode;
        private byte _megaLimit;
        private byte _gigaLimit;
        private short _bonusHP;
        private List<string> _colors = new List<string> { "White", "Pink", "Yellow" };
        private SaveDataObject _initialSave;
        private Style _style;
        private List<NCPListing> ncpMapList;
        private NaviCustGrid[,] naviCustGrid;
        
        public NaviCustEdit()
        {
            InitializeComponent();
        }
        public NaviCustEdit(SaveDataObject save, Style style)
        {
            InitializeComponent();
            _initialSave = save;
            _style = style;
            InitializeStats();
            ReadInventory();
            ReadCompression();
            InitializeGrid();
            imgCustGrid00.Image = Properties.Resources.NCPblockWhite;
            imgCustGrid01.Image = Properties.Resources.NCPblockRed;
            imgCustGrid02.Image = Properties.Resources.NCPblockPink;
            imgCustGrid03.Image = Properties.Resources.NCPblockOrange;
            imgCustGrid04.Image = Properties.Resources.NCPblockYellow;
            imgCustGrid10.Image = Properties.Resources.NCPblockGreen;
            imgCustGrid11.Image = Properties.Resources.NCPblockBlue;
            imgCustGrid12.Image = Properties.Resources.NCPblockPurple;
            imgCustGrid13.Image = Properties.Resources.NCPblockDark;
            imgCustGrid14.Image = Properties.Resources.NCPplusblockWhite;
            imgCustGrid20.Image = Properties.Resources.NCPplusblockRed;
            imgCustGrid21.Image = Properties.Resources.NCPplusblockPink;
            imgCustGrid22.Image = Properties.Resources.NCPplusblockYellow;
            imgCustGrid23.Image = Properties.Resources.NCPplusblockGreen;
            imgCustGrid24.Image = Properties.Resources.NCPplusblockBlue;
            Properties.Resources.NCPblockWhite.Dispose();
            Properties.Resources.NCPblockRed.Dispose();
            Properties.Resources.NCPblockPink.Dispose();
            Properties.Resources.NCPblockOrange.Dispose();
            Properties.Resources.NCPblockYellow.Dispose();
            Properties.Resources.NCPblockGreen.Dispose();
            Properties.Resources.NCPblockBlue.Dispose();
            Properties.Resources.NCPblockPurple.Dispose();
            Properties.Resources.NCPblockDark.Dispose();
            Properties.Resources.NCPplusblockWhite.Dispose();
            Properties.Resources.NCPplusblockRed.Dispose();
            Properties.Resources.NCPplusblockPink.Dispose();
            Properties.Resources.NCPplusblockYellow.Dispose();
            Properties.Resources.NCPplusblockGreen.Dispose();
            Properties.Resources.NCPplusblockBlue.Dispose();
            Properties.Resources.NCPGrid.Dispose();
            Properties.Resources.blank.Dispose();
        }
        public void InitializeGrid()
        {
            switch (_initialSave.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork6CybeastGregar:
                case GameTitle.Title.MegaManBattleNetwork6CybeastFalzar:
                    naviCustGrid = new NaviCustGrid[7, 7];
                    imgCustGrid00.Image = Properties.Resources.blank;
                    break;
                default:
                    naviCustGrid = new NaviCustGrid[5, 5];
                    imgCustGrid05.Image = Properties.Resources.blank;
                    imgCustGrid15.Image = Properties.Resources.blank;
                    imgCustGrid16.Image = Properties.Resources.blank;
                    imgCustGrid25.Image = Properties.Resources.blank;
                    imgCustGrid26.Image = Properties.Resources.blank;
                    imgCustGrid35.Image = Properties.Resources.blank;
                    imgCustGrid36.Image = Properties.Resources.blank;
                    imgCustGrid45.Image = Properties.Resources.blank;
                    imgCustGrid46.Image = Properties.Resources.blank;
                    imgCustGrid50.Image = Properties.Resources.blank;
                    imgCustGrid51.Image = Properties.Resources.blank;
                    imgCustGrid52.Image = Properties.Resources.blank;
                    imgCustGrid53.Image = Properties.Resources.blank;
                    imgCustGrid54.Image = Properties.Resources.blank;
                    imgCustGrid55.Image = Properties.Resources.blank;
                    imgCustGrid56.Image = Properties.Resources.blank;
                    imgCustGrid61.Image = Properties.Resources.blank;
                    imgCustGrid62.Image = Properties.Resources.blank;
                    imgCustGrid63.Image = Properties.Resources.blank;
                    imgCustGrid64.Image = Properties.Resources.blank;
                    imgCustGrid65.Image = Properties.Resources.blank;
                    break;
            }
            UpdateGridSize();
        }
        public void UpdateGridSize()
        {
            switch (_initialSave.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork6CybeastGregar:
                case GameTitle.Title.MegaManBattleNetwork6CybeastFalzar:
                    break;
                default:
                    switch (_custSize)
                    {
                        case 0:
                            imgCustGrid04.Image = Properties.Resources.blank;
                            imgCustGrid14.Image = Properties.Resources.blank;
                            imgCustGrid24.Image = Properties.Resources.blank;
                            imgCustGrid34.Image = Properties.Resources.blank;
                            imgCustGrid40.Image = Properties.Resources.blank;
                            imgCustGrid41.Image = Properties.Resources.blank;
                            imgCustGrid42.Image = Properties.Resources.blank;
                            imgCustGrid43.Image = Properties.Resources.blank;
                            imgCustGrid44.Image = Properties.Resources.blank;
                            for (int i = 0; i < 5; i++)
                            {
                                for (int j = 0; j < 5; j++)
                                {
                                    NaviCustGrid ncg = new NaviCustGrid();
                                    ncg.BlockType = 0;
                                    ncg.CoordX = i;
                                    ncg.CoordY = j;
                                    if (i == 4 || j == 4)
                                    {
                                        ncg.BlockType = -1;
                                    }
                                    naviCustGrid[i, j] = ncg;
                                }
                            }
                            break;
                        case 1:
                            imgCustGrid40.Image = Properties.Resources.blank;
                            imgCustGrid41.Image = Properties.Resources.blank;
                            imgCustGrid42.Image = Properties.Resources.blank;
                            imgCustGrid43.Image = Properties.Resources.blank;
                            imgCustGrid44.Image = Properties.Resources.blank;
                            for(int i = 0; i < 5; i++)
                            {
                                for (int j = 0; j < 5; j++)
                                {
                                    NaviCustGrid ncg = new NaviCustGrid();
                                    ncg.BlockType = 0;
                                    ncg.CoordX = i;
                                    ncg.CoordY = j;
                                    if (j == 4)
                                    {
                                        ncg.BlockType = -1;
                                    }
                                    naviCustGrid[i, j] = ncg;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }
        public void ReadCompression()
        {
            for (int i = 0; i < ncpMapList.Count; i++)
            {
                ncpMapList[i].isCompressed = _compression[i] == 1;
            }
        }
        public void ReadInventory()
        {
            int index = 0;
            foreach (NCPListing part in ncpMapList)
            {
                if (part.ncpName == "None")
                    continue;
                int colorIndex = 0;
                foreach (string color in part.ncpColors)
                {
                    if (color == "None")
                    {
                        colorIndex++;
                        continue;
                    }
                    switch (colorIndex)
                    {
                        case 0:
                            part.QuantityCol1 = _ncpInv[index];
                            break;
                        case 1:
                            part.QuantityCol2 = _ncpInv[index];
                            break;
                        case 2:
                            part.QuantityCol3 = _ncpInv[index];
                            break;
                        default:
                            part.QuantityCol4 = _ncpInv[index];
                            break;
                    }
                    colorIndex++;
                }
                index++;
            }
        }
        public void InitializeStats()
        {
            _hpUp = _initialSave.HPUp;
            _custSize = _initialSave.CustSize;
            _atkBonus = _initialSave.AttackPower;
            _spdBonus = _initialSave.RapidPower;
            _chrgBonus = _initialSave.ChargePower;
            _cShotBonus = _initialSave.CShotPower;
            _ncpInv = _initialSave.NCPInventory;
            _compression = _initialSave.Compression;
            _ncpGrid = _initialSave.NCPGrid;
            _gridPos = _initialSave.GridPosData;
            _effects = _initialSave.CustEffects;
            _bugs = _initialSave.CustBugs;
            _modCode = _initialSave.ModCode;
            _megaLimit = _initialSave.MegaLimit;
            _gigaLimit = _initialSave.GigaLimit;
            bool hubBatch = false;
            foreach (byte[] ncp in _ncpGrid) // check the NCP grid for HubBatc
            {
                if (ncp[0] == 0xC4)
                {
                    hubBatch = true;
                }
            }
            if (hubBatch) // if HubBatc is equipped, MaxHP will be halved, so we've got to double it.
            {
                _maxHP = 2 * _initialSave.MaxHP;
            }
            else
            {
                _maxHP = _initialSave.MaxHP;
            }
            _bonusHP = (short)(_maxHP - (_hpUp * 20) - 100);
            switch (_style.Name)
            {
                case Style.Value.HeatGuts:
                case Style.Value.AquaGuts:
                case Style.Value.ElecGuts:
                case Style.Value.WoodGuts:
                case Style.Value.HeatShadow:
                case Style.Value.AquaShadow:
                case Style.Value.ElecShadow:
                case Style.Value.WoodShadow:
                    _colors.Add("Red");
                    break;
                case Style.Value.HeatShield:
                case Style.Value.AquaShield:
                case Style.Value.ElecShield:
                case Style.Value.WoodShield:
                case Style.Value.HeatCust:
                case Style.Value.AquaCust:
                case Style.Value.ElecCust:
                case Style.Value.WoodCust:
                    _colors.Add("Blue");
                    break;
                case Style.Value.HeatTeam:
                case Style.Value.AquaTeam:
                case Style.Value.ElecTeam:
                case Style.Value.WoodTeam:
                case Style.Value.HeatGround:
                case Style.Value.AquaGround:
                case Style.Value.ElecGround:
                case Style.Value.WoodGround:
                    _colors.Add("Green");
                    break;
                case Style.Value.HeatBug:
                case Style.Value.AquaBug:
                case Style.Value.ElecBug:
                case Style.Value.WoodBug:
                    _colors.Add("Dark");
                    break;
                default:
                    break;
            }
            switch (_initialSave.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork3White:
                case GameTitle.Title.MegaManBattleNetwork3Blue:
                    ncpMapList = new NaviCustParts().BN3NCPMap();
                    break;
                default:
                    break;
            }    
        }
        private class NaviCustGrid
        {
            public int BlockType { get; set; } // Empty Grid space, Program part, or Plus part. -1 is transparent.
            public string Color { get; set; } = "White"; // White is no overlay because the pieces are already white.
            public string PartName { get; set; } = ""; // No name should pop up on a blank grid space.
            public int CoordX { get; set; } // Might have to track which square coordinate it is.
            public int CoordY { get; set; }
            public int Index { get; set; } = 0; // This is for GridPosData. Keep track of the order of placement.
        }
    }
}
