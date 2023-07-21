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
        private int _hpUp;
        private int _baseHP;
        private int _bonusHP;
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
        private int _modHP = 0;
        private byte _modCode;
        private int _regMem;
        private byte _bonusRegMem;
        private byte _megaLimit;
        private byte _modMega = 0;
        private byte _gigaLimit;
        private byte _modGiga = 0;
        private byte _customSize;
        private byte _modCustom = 0;
        private bool isBugged = false;
        private bool isGuts = false;
        private bool isCust = false;
        private bool isTeam = false;
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
            ReadStats();
            // ColorTest();

        }
        public void InitializeModCode()
        {
            switch (_modCode)
            {
                case 0x1E:
                    cBoxModCode.SelectedItem = "HP+100";
                    _modHP = 100;
                    _bonusHP -= 100;
                    break;
                case 0x1F:
                    cBoxModCode.SelectedItem = "HP+150";
                    _modHP = 150;
                    _bonusHP -= 150;
                    break;
                case 0x20:
                    cBoxModCode.SelectedItem = "HP+200";
                    _modHP = 200;
                    _bonusHP -= 200;
                    break;
                case 0x21:
                    cBoxModCode.SelectedItem = "HP+250";
                    _modHP = 250;
                    _bonusHP -= 250;
                    break;
                case 0x22:
                    cBoxModCode.SelectedItem = "HP+300";
                    _modHP = 300;
                    _bonusHP -= 300;
                    break;
                case 0x23:
                    cBoxModCode.SelectedItem = "HP+350";
                    _modHP = 350;
                    _bonusHP -= 350;
                    break;
                case 0x24:
                    cBoxModCode.SelectedItem = "HP+400";
                    _modHP = 400;
                    _bonusHP -= 400;
                    break;
                case 0x25:
                    cBoxModCode.SelectedItem = "HP+450";
                    _modHP = 450;
                    _bonusHP -= 450;
                    break;
                case 0x26:
                    cBoxModCode.SelectedItem = "HP+500";
                    _modHP = 500;
                    _bonusHP -= 500;
                    break;
                case 0x27:
                    cBoxModCode.SelectedItem = "HP+550";
                    _modHP = 550;
                    _bonusHP -= 550;
                    break;
                case 0x28:
                    cBoxModCode.SelectedItem = "HP+600";
                    _modHP = 600;
                    _bonusHP -= 600;
                    break;
                case 0x29:
                    cBoxModCode.SelectedItem = "HP+650";
                    _modHP = 650;
                    _bonusHP -= 650;
                    break;
                case 0x2A:
                    cBoxModCode.SelectedItem = "HP+700";
                    _modHP = 700;
                    _bonusHP -= 700;
                    break;
                case 0x2B:
                    cBoxModCode.SelectedItem = "Equip Super Armor";
                    break;
                case 0x2C:
                    cBoxModCode.SelectedItem = "Equip Break Buster";
                    break;
                case 0x2D:
                    cBoxModCode.SelectedItem = "Equip Break Charge";
                    break;
                case 0x2E:
                    cBoxModCode.SelectedItem = "Equip Shadow Shoes";
                    break;
                case 0x2F:
                    cBoxModCode.SelectedItem = "Equip Float Shoes";
                    break;
                case 0x30:
                    cBoxModCode.SelectedItem = "Equip Air Shoes";
                    break;
                case 0x31:
                    cBoxModCode.SelectedItem = "Equip UnderShirt";
                    break;
                case 0x32:
                    cBoxModCode.SelectedItem = "Equip Block (Left+B)";
                    break;
                case 0x33:
                    cBoxModCode.SelectedItem = "Equip Shield (Left+B)";
                    break;
                case 0x34:
                    cBoxModCode.SelectedItem = "Equip Reflect (Left+B)";
                    break;
                case 0x35:
                    cBoxModCode.SelectedItem = "Equip Anti-Damage (Left+B)";
                    break;
                case 0x36:
                    cBoxModCode.SelectedItem = "MegaChip +1";
                    _megaLimit -= 1;
                    _modMega = 1;
                    break;
                case 0x37:
                    cBoxModCode.SelectedItem = "MegaChip +2";
                    _megaLimit -= 2;
                    _modMega = 2;
                    break;
                case 0x38:
                    cBoxModCode.SelectedItem = "Activate FastGauge";
                    break;
                case 0x39:
                    cBoxModCode.SelectedItem = "Activate SneakRun";
                    break;
                case 0x3A:
                    cBoxModCode.SelectedItem = "Activate Humor";
                    break;
                case 0x3B:
                    cBoxModCode.SelectedItem = "HP+800";
                    _modHP = 800;
                    _bonusHP -= 800;
                    break;
                case 0x3C:
                    cBoxModCode.SelectedItem = "HP+900";
                    _modHP = 900;
                    _bonusHP -= 900;
                    break;
                case 0x3D:
                    cBoxModCode.SelectedItem = "HP+1000";
                    _modHP = 1000;
                    _bonusHP -= 1000;
                    break;
                case 0x3E:
                    cBoxModCode.SelectedItem = "MegaChip +3";
                    _megaLimit -= 3;
                    _modMega = 3;
                    break;
                case 0x3F:
                    cBoxModCode.SelectedItem = "MegaChip +4";
                    _megaLimit -= 4;
                    _modMega = 4;
                    break;
                case 0x40:
                    cBoxModCode.SelectedItem = "MegaChip +5";
                    _megaLimit -= 5;
                    _modMega = 5;
                    break;
                case 0x41:
                    cBoxModCode.SelectedItem = "GigaChip +1";
                    _gigaLimit -= 1;
                    _modGiga = 1;
                    break;
                default:
                    cBoxModCode.SelectedItem = "None";
                    break;
            }
        }
        public void ReadStats()
        {
            int gutsMod = isGuts ? 2 : 1;
            int custMod = isCust ? 1 : 0;
            int teamMod = isTeam ? 1 : 0;
            labelHPTotal.Text = (_baseHP + _bonusHP + _modHP).ToString();
            labelAttack.Text = (Math.Min(_atkBonus, 5) * gutsMod).ToString();
            labelSpeed.Text = (Math.Min(_spdBonus, 5) + 1).ToString();
            labelCharge.Text = (Math.Min(_chrgBonus, 5) + 1).ToString();
            labelCShot.Text = Math.Min(_cShotBonus, 3).ToString();
            labelRegMem.Text = (_regMem + _bonusRegMem).ToString();
            labelMegaLimit.Text = (_megaLimit + teamMod + _modMega).ToString();
            labelGigaLimit.Text = (_gigaLimit + _modGiga).ToString();
            labelCustHandSize.Text = (_customSize + custMod + _modCustom).ToString();
        }
        public void InitializeGrid()
        {
            switch (_initialSave.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork6CybeastGregar:
                case GameTitle.Title.MegaManBattleNetwork6CybeastFalzar:
                    naviCustGrid = new NaviCustGrid[7, 7];
                    imgCustGrid00.Visible = false;
                    break;
                default:
                    naviCustGrid = new NaviCustGrid[5, 5];
                    List<PictureBox> exclusions = new List<PictureBox> { imgCustGrid05, imgCustGrid15, imgCustGrid16, imgCustGrid25, imgCustGrid26, imgCustGrid35, imgCustGrid36, imgCustGrid45, imgCustGrid46, imgCustGrid50, imgCustGrid51, imgCustGrid52, imgCustGrid53, imgCustGrid54, imgCustGrid55, imgCustGrid56, imgCustGrid61, imgCustGrid62, imgCustGrid63, imgCustGrid64, imgCustGrid65 };
                    foreach (PictureBox image in exclusions)
                    {
                        image.Visible = false;
                    }
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
                            imgCustGrid04.Visible = false;
                            imgCustGrid14.Visible = false;
                            imgCustGrid24.Visible = false;
                            imgCustGrid34.Visible = false;
                            imgCustGrid40.Visible = false;
                            imgCustGrid41.Visible = false;
                            imgCustGrid42.Visible = false;
                            imgCustGrid43.Visible = false;
                            imgCustGrid44.Visible = false;
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
                            imgCustGrid40.Visible = false;
                            imgCustGrid41.Visible = false;
                            imgCustGrid42.Visible = false;
                            imgCustGrid43.Visible = false;
                            imgCustGrid44.Visible = false;
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
            _baseHP = (_hpUp * 20) + 100;
            _bonusHP = _initialSave.BonusHP;
            _regMem = _initialSave.RegMem;
            _custSize = _initialSave.CustSize;
            _atkBonus = _initialSave.AttackPower;
            _spdBonus = _initialSave.RapidPower;
            _chrgBonus = _initialSave.ChargePower;
            _bonusRegMem = _initialSave.CustEffects[17];
            _customSize = _initialSave.CustEffects[18];
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
            isBugged = _initialSave.isCustBugged;
            
            
            switch (_style.Name)
            {
                case Style.Value.HeatGuts:
                case Style.Value.AquaGuts:
                case Style.Value.ElecGuts:
                case Style.Value.WoodGuts:
                    isGuts = true;
                    break;
                case Style.Value.HeatCust:
                case Style.Value.AquaCust:
                case Style.Value.ElecCust:
                case Style.Value.WoodCust:
                    isCust = true;
                    break;
                case Style.Value.HeatTeam:
                case Style.Value.AquaTeam:
                case Style.Value.ElecTeam:
                case Style.Value.WoodTeam:
                    isTeam = true;
                    break;
                default:
                    break;
            }
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
        public void ColorTest()
        {
            imgCustGrid00.Image = Properties.Resources.NCPblockWhite;
            imgCustGrid00.Tag = "NCPblockWhite";
            imgCustGrid01.Image = Properties.Resources.NCPblockRed;
            imgCustGrid01.Tag = "NCPblockRed";
            imgCustGrid02.Image = Properties.Resources.NCPblockPink;
            imgCustGrid02.Tag = "NCPblockPink";
            imgCustGrid03.Image = Properties.Resources.NCPblockOrange;
            imgCustGrid03.Tag = "NCPblockOrange";
            imgCustGrid04.Image = Properties.Resources.NCPblockYellow;
            imgCustGrid04.Tag = "NCPblockYellow";
            imgCustGrid10.Image = Properties.Resources.NCPblockGreen;
            imgCustGrid10.Tag = "NCPblockGreen";
            imgCustGrid11.Image = Properties.Resources.NCPblockBlue;
            imgCustGrid11.Tag = "NCPblockBlue";
            imgCustGrid12.Image = Properties.Resources.NCPblockPurple;
            imgCustGrid12.Tag = "NCPblockPurple";
            imgCustGrid13.Image = Properties.Resources.NCPblockDark;
            imgCustGrid13.Tag = "NCPblockDark";
            imgCustGrid14.Image = Properties.Resources.NCPplusblockWhite;
            imgCustGrid14.Tag = "NCPplusblockWhite";
            imgCustGrid20.Image = Properties.Resources.NCPplusblockRed;
            imgCustGrid20.Tag = "NCPplusblockRed";
            imgCustGrid21.Image = Properties.Resources.NCPplusblockPink;
            imgCustGrid21.Tag = "NCPplusblockPink";
            imgCustGrid22.Image = Properties.Resources.NCPplusblockYellow;
            imgCustGrid22.Tag = "NCPplusblockYellow";
            imgCustGrid23.Image = Properties.Resources.NCPplusblockGreen;
            imgCustGrid23.Tag = "NCPplusblockGreen";
            imgCustGrid24.Image = Properties.Resources.NCPplusblockBlue;
            imgCustGrid24.Tag = "NCPplusblockBlue";
        }
        public void Cleanup()
        {
            List<PictureBox> pictureBoxes = new List<PictureBox> { imgCustGrid00, imgCustGrid01, imgCustGrid02, imgCustGrid03, imgCustGrid04, imgCustGrid05, imgCustGrid10, imgCustGrid11, imgCustGrid12, imgCustGrid13, imgCustGrid14, imgCustGrid15, imgCustGrid16, imgCustGrid20, imgCustGrid21, imgCustGrid22, imgCustGrid23, imgCustGrid24, imgCustGrid25, imgCustGrid26, imgCustGrid30, imgCustGrid31, imgCustGrid32, imgCustGrid33, imgCustGrid34, imgCustGrid35, imgCustGrid36, imgCustGrid40, imgCustGrid41, imgCustGrid42, imgCustGrid43, imgCustGrid44, imgCustGrid45, imgCustGrid46, imgCustGrid50, imgCustGrid51, imgCustGrid52, imgCustGrid53, imgCustGrid54, imgCustGrid55, imgCustGrid56, imgCustGrid61, imgCustGrid62, imgCustGrid63, imgCustGrid64, imgCustGrid65, imgRunLine };
            foreach (PictureBox box in pictureBoxes)
            {
                box.Image.Dispose();
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
        private void NaviCustEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cleanup();
        }

        private void imgCustGrid_MouseHover(object sender, EventArgs e)
        {
            PictureBox image = (PictureBox)sender;
            if ((string)image.Tag != null && (string)image.Tag != "" && image.Visible == true)
            {
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(image, (string)image.Tag);
                toolTip.Active = true;
            }
        }

        private void imgCustGrid_MouseLeave(object sender, EventArgs e)
        {
            PictureBox image = (PictureBox)sender;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(image, "");
            toolTip.Active = false;
        }
    }
}
