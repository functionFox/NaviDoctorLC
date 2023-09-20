using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using NaviDoctor.models;
using System.Reflection;

namespace NaviDoctor
{
    public partial class NaviCustEdit : Form
    {
        public static NaviCust naviCust = new NaviCust();
        private NaviCustGrid[,] naviCustGrid;
        private SaveDataObject _initialSave;
        private Style _style;
        private List<PictureBox> preview;
        private int[] selectedPart;
        private int rotator = 0;
        private bool _placement_mode = false;

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
            InitializeColorBox();
            InitializeModCode();
            ReadInventory();
            ReadCompression();
            InitializeGrid();
            ReadGrid();
            ReadStats();
            // ColorTest();
            PopulateGrid();
            ReadEffects();
            ReadBugs();
            PopulateNCPList();
        }
        public void InitializeStats()
        {
            naviCust.HpUp = _initialSave.HPUp;
            naviCust.BaseHP = (naviCust.HpUp * 20) + 100;
            naviCust.BonusHP = _initialSave.BonusHP;
            naviCust.RegMem = _initialSave.RegMem;
            naviCust.CustSize = _initialSave.CustSize;
            naviCust.AtkBonus = _initialSave.AttackPower;
            naviCust.SpdBonus = _initialSave.RapidPower;
            naviCust.ChrgBonus = _initialSave.ChargePower;
            naviCust.BonusRegMem = _initialSave.CustEffects[17];
            naviCust.CustomSize = _initialSave.CustEffects[18];
            naviCust.CShotBonus = _initialSave.CShotPower;
            naviCust.NcpInv = _initialSave.NCPInventory;
            naviCust.Compression = _initialSave.Compression;
            naviCust.NcpGrid = _initialSave.NCPGrid;
            naviCust.GridPos = _initialSave.GridPosData;
            naviCust.Effects = _initialSave.CustEffects;
            naviCust.Bugs = _initialSave.CustBugs;
            naviCust.ModCode = _initialSave.ModCode;
            naviCust.MegaLimit = _initialSave.MegaLimit;
            naviCust.GigaLimit = _initialSave.GigaLimit;
            naviCust.IsBugged = _initialSave.isCustBugged;

            labelStyleName.Text = _style.Name.ToString() + " Style";
            
            switch (_style.Name)
            {
                case Style.Value.HeatGuts:
                case Style.Value.AquaGuts:
                case Style.Value.ElecGuts:
                case Style.Value.WoodGuts:
                    naviCust.IsGuts = true;
                    break;
                case Style.Value.HeatCust:
                case Style.Value.AquaCust:
                case Style.Value.ElecCust:
                case Style.Value.WoodCust:
                    naviCust.IsCust = true;
                    break;
                case Style.Value.HeatTeam:
                case Style.Value.AquaTeam:
                case Style.Value.ElecTeam:
                case Style.Value.WoodTeam:
                    naviCust.IsTeam = true;
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
                    naviCust.ColorsList.Add("Red");
                    break;
                case Style.Value.HeatShield:
                case Style.Value.AquaShield:
                case Style.Value.ElecShield:
                case Style.Value.WoodShield:
                case Style.Value.HeatCust:
                case Style.Value.AquaCust:
                case Style.Value.ElecCust:
                case Style.Value.WoodCust:
                    naviCust.ColorsList.Add("Blue");
                    break;
                case Style.Value.HeatTeam:
                case Style.Value.AquaTeam:
                case Style.Value.ElecTeam:
                case Style.Value.WoodTeam:
                case Style.Value.HeatGround:
                case Style.Value.AquaGround:
                case Style.Value.ElecGround:
                case Style.Value.WoodGround:
                    naviCust.ColorsList.Add("Green");
                    break;
                case Style.Value.HeatBug:
                case Style.Value.AquaBug:
                case Style.Value.ElecBug:
                case Style.Value.WoodBug:
                    naviCust.ColorsList.Add("Dark");
                    break;
                default:
                    break;
            }
            switch (_initialSave.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork3White:
                case GameTitle.Title.MegaManBattleNetwork3Blue:
                    naviCust.NcpMapList = new NaviCustParts().BN3NCPMap();
                    break;
                default:
                    break;
            }    
        }
        public void InitializeColorBox()
        {
            naviCust.ColorBox = new List<PictureBox> { imgColorBox1, imgColorBox2, imgColorBox3, imgColorBox4, imgColorBox5, imgColorBox6 };
            for (int i = 0; i < naviCust.ColorsList.Count; i++)
            {
                switch (naviCust.ColorsList[i])
                {
                    case "White":
                        naviCust.ColorBox[i].BackColor = Color.White;
                        break;
                    case "Pink":
                        naviCust.ColorBox[i].BackColor = Color.Pink;
                        break;
                    case "Yellow":
                        naviCust.ColorBox[i].BackColor = Color.Yellow;
                        break;
                    case "Red":
                        naviCust.ColorBox[i].BackColor = Color.Red;
                        break;
                    case "Orange":
                        naviCust.ColorBox[i].BackColor = Color.Orange;
                        break;
                    case "Green":
                        naviCust.ColorBox[i].BackColor = Color.Green;
                        break;
                    case "Blue":
                        naviCust.ColorBox[i].BackColor = Color.Blue;
                        break;
                    case "Purple":
                        naviCust.ColorBox[i].BackColor = Color.Purple;
                        break;
                    case "Dark":
                        naviCust.ColorBox[i].BackColor = Color.DarkGray;
                        break;
                    default:
                        naviCust.ColorBox[i].BackColor = Color.Transparent;
                        break;
                }
                naviCust.ColorBox[i].BorderStyle = BorderStyle.FixedSingle;
                naviCust.ColorBox[i].Visible = true;
            }
        }
        public void InitializeModCode()
        {
            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(cBoxModCode, cBoxModCode.Tag.ToString());
            tooltip.Active = true;
            switch (naviCust.ModCode)
            {
                case 0x1E:
                    cBoxModCode.SelectedItem = "HP+100";
                    naviCust.ModHP = 100;
                    naviCust.BonusHP -= 100;
                    break;
                case 0x1F:
                    cBoxModCode.SelectedItem = "HP+150";
                    naviCust.ModHP = 150;
                    naviCust.BonusHP -= 150;
                    break;
                case 0x20:
                    cBoxModCode.SelectedItem = "HP+200";
                    naviCust.ModHP = 200;
                    naviCust.BonusHP -= 200;
                    break;
                case 0x21:
                    cBoxModCode.SelectedItem = "HP+250";
                    naviCust.ModHP = 250;
                    naviCust.BonusHP -= 250;
                    break;
                case 0x22:
                    cBoxModCode.SelectedItem = "HP+300";
                    naviCust.ModHP = 300;
                    naviCust.BonusHP -= 300;
                    break;
                case 0x23:
                    cBoxModCode.SelectedItem = "HP+350";
                    naviCust.ModHP = 350;
                    naviCust.BonusHP -= 350;
                    break;
                case 0x24:
                    cBoxModCode.SelectedItem = "HP+400 *";
                    naviCust.ModHP = 400;
                    naviCust.BonusHP -= 400;
                    break;
                case 0x25:
                    cBoxModCode.SelectedItem = "HP+450 *";
                    naviCust.ModHP = 450;
                    naviCust.BonusHP -= 450;
                    break;
                case 0x26:
                    cBoxModCode.SelectedItem = "HP+500 *";
                    naviCust.ModHP = 500;
                    naviCust.BonusHP -= 500;
                    break;
                case 0x27:
                    cBoxModCode.SelectedItem = "HP+550 *";
                    naviCust.ModHP = 550;
                    naviCust.BonusHP -= 550;
                    break;
                case 0x28:
                    cBoxModCode.SelectedItem = "HP+600 *";
                    naviCust.ModHP = 600;
                    naviCust.BonusHP -= 600;
                    break;
                case 0x29:
                    cBoxModCode.SelectedItem = "HP+650 *";
                    naviCust.ModHP = 650;
                    naviCust.BonusHP -= 650;
                    break;
                case 0x2A:
                    cBoxModCode.SelectedItem = "HP+700 *";
                    naviCust.ModHP = 700;
                    naviCust.BonusHP -= 700;
                    break;
                case 0x2B:
                    cBoxModCode.SelectedItem = "Equip Super Armor";
                    break;
                case 0x2C:
                    cBoxModCode.SelectedItem = "Equip Break Buster *";
                    break;
                case 0x2D:
                    cBoxModCode.SelectedItem = "Equip Break Charge *";
                    break;
                case 0x2E:
                    cBoxModCode.SelectedItem = "Equip Shadow Shoes";
                    break;
                case 0x2F:
                    cBoxModCode.SelectedItem = "Equip Float Shoes";
                    break;
                case 0x30:
                    cBoxModCode.SelectedItem = "Equip Air Shoes *";
                    break;
                case 0x31:
                    cBoxModCode.SelectedItem = "Equip UnderShirt";
                    break;
                case 0x32:
                    cBoxModCode.SelectedItem = "Equip Block (B+Left)";
                    break;
                case 0x33:
                    cBoxModCode.SelectedItem = "Equip Shield (B+Left)";
                    break;
                case 0x34:
                    cBoxModCode.SelectedItem = "Equip Reflect (B+Left) *";
                    break;
                case 0x35:
                    cBoxModCode.SelectedItem = "Equip Anti-Damage (B+Left) *";
                    break;
                case 0x36:
                    cBoxModCode.SelectedItem = "MegaChip +1";
                    naviCust.MegaLimit -= 1;
                    naviCust.ModMega = 1;
                    break;
                case 0x37:
                    cBoxModCode.SelectedItem = "MegaChip +2 *";
                    naviCust.MegaLimit -= 2;
                    naviCust.ModMega = 2;
                    break;
                case 0x38:
                    cBoxModCode.SelectedItem = "Activate FastGauge *";
                    break;
                case 0x39:
                    cBoxModCode.SelectedItem = "Activate SneakRun";
                    break;
                case 0x3A:
                    cBoxModCode.SelectedItem = "Activate Humor";
                    break;
                case 0x3B:
                    cBoxModCode.SelectedItem = "HP+800 *";
                    naviCust.ModHP = 800;
                    naviCust.BonusHP -= 800;
                    break;
                case 0x3C:
                    cBoxModCode.SelectedItem = "HP+900 *";
                    naviCust.ModHP = 900;
                    naviCust.BonusHP -= 900;
                    break;
                case 0x3D:
                    cBoxModCode.SelectedItem = "HP+1000 *";
                    naviCust.ModHP = 1000;
                    naviCust.BonusHP -= 1000;
                    break;
                case 0x3E:
                    cBoxModCode.SelectedItem = "MegaChip +3 *";
                    naviCust.MegaLimit -= 3;
                    naviCust.ModMega = 3;
                    break;
                case 0x3F:
                    cBoxModCode.SelectedItem = "MegaChip +4 *";
                    naviCust.MegaLimit -= 4;
                    naviCust.ModMega = 4;
                    break;
                case 0x40:
                    cBoxModCode.SelectedItem = "MegaChip +5 *";
                    naviCust.MegaLimit -= 5;
                    naviCust.ModMega = 5;
                    break;
                case 0x41:
                    cBoxModCode.SelectedItem = "GigaChip +1 *";
                    naviCust.GigaLimit -= 1;
                    naviCust.ModGiga = 1;
                    break;
                default:
                    cBoxModCode.SelectedItem = "None"; 
                    // Insert check for Error Codes here!
                    // cBoxModCode.Items.Add("Error A1: Super Armor");
                    // cBoxModCode.SelectedItem = "Error A1: Super Armor";
                    // cBoxModCode.Enabled = false;
                    break;
            }
        }
        public void ReadInventory()
        {
            int index = 0;
            foreach (NCPListing part in naviCust.NcpMapList)
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
                            part.QuantityCol1 = naviCust.NcpInv[index];
                            break;
                        case 1:
                            part.QuantityCol2 = naviCust.NcpInv[index];
                            break;
                        case 2:
                            part.QuantityCol3 = naviCust.NcpInv[index];
                            break;
                        default:
                            part.QuantityCol4 = naviCust.NcpInv[index];
                            break;
                    }
                    colorIndex++;
                }
                index++;
            }
        }
        public void ReadCompression()
        {
            for (int i = 0; i < naviCust.NcpMapList.Count; i++)
            {
                naviCust.NcpMapList[i].isCompressed = naviCust.Compression[i] == 1;
            }
        }
        public void InitializeGrid()
        {
            preview = new List<PictureBox>
            { imgSelect00, imgSelect01, imgSelect02, imgSelect03, imgSelect04, imgSelect10, imgSelect11, imgSelect12, imgSelect13, imgSelect14, imgSelect20, imgSelect21, imgSelect22, imgSelect23, imgSelect24, imgSelect30, imgSelect31, imgSelect32, imgSelect33, imgSelect34, imgSelect40, imgSelect41, imgSelect42, imgSelect43, imgSelect44
            };
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
                    List<PictureBox> exclusions = new List<PictureBox>();
                    switch (naviCust.CustSize)
                    {
                        case 0:
                            exclusions = new List<PictureBox> { imgCustGrid04, imgCustGrid14, imgCustGrid24, imgCustGrid34, imgCustGrid40, imgCustGrid41, imgCustGrid42, imgCustGrid43, imgCustGrid44 };
                            foreach (PictureBox image in exclusions)
                            {
                                image.Visible = false;
                            }
                            naviCust.PictureBoxList = new List<PictureBox>()
                            {
                                imgCustGrid00, imgCustGrid01, imgCustGrid02, imgCustGrid03, imgCustGrid10, imgCustGrid11, imgCustGrid12,
                                imgCustGrid13, imgCustGrid20, imgCustGrid21, imgCustGrid22, imgCustGrid23, imgCustGrid30, imgCustGrid31,
                                imgCustGrid32, imgCustGrid33
                            };
                            for (int i = 0; i < 5; i++)
                            {
                                for (int j = 0; j < 5; j++)
                                {
                                    NaviCustGrid ncg = new NaviCustGrid();
                                    ncg.BlockType = 0;
                                    ncg.PivotX = i;
                                    ncg.PivotY = j;
                                    if (i == 4 || j == 4)
                                    {
                                        ncg.BlockType = -1;
                                    }
                                    naviCustGrid[i, j] = ncg;
                                }
                            }
                            break;
                        case 1:
                            exclusions = new List<PictureBox> { imgCustGrid40, imgCustGrid41, imgCustGrid42, imgCustGrid43, imgCustGrid44 };
                            foreach (PictureBox image in exclusions)
                            {
                                image.Visible = false;
                            }
                            naviCust.PictureBoxList = new List<PictureBox>()
                            {
                                imgCustGrid00, imgCustGrid01, imgCustGrid02, imgCustGrid03, imgCustGrid04, imgCustGrid10, imgCustGrid11, 
                                imgCustGrid12, imgCustGrid13, imgCustGrid14, imgCustGrid20, imgCustGrid21, imgCustGrid22, imgCustGrid23, 
                                imgCustGrid24, imgCustGrid30, imgCustGrid31, imgCustGrid32, imgCustGrid33, imgCustGrid34
                            };
                            for (int i = 0; i < 5; i++)
                            {
                                for (int j = 0; j < 5; j++)
                                {
                                    NaviCustGrid ncg = new NaviCustGrid();
                                    ncg.BlockType = 0;
                                    ncg.PivotX = i;
                                    ncg.PivotY = j;
                                    if (j == 4)
                                    {
                                        ncg.BlockType = -1;
                                    }
                                    naviCustGrid[i, j] = ncg;
                                }
                            }
                            break;
                        case 2:
                            naviCust.PictureBoxList = new List<PictureBox>()
                            {
                                imgCustGrid00, imgCustGrid01, imgCustGrid02, imgCustGrid03, imgCustGrid04, imgCustGrid10, imgCustGrid11,
                                imgCustGrid12, imgCustGrid13, imgCustGrid14, imgCustGrid20, imgCustGrid21, imgCustGrid22, imgCustGrid23,
                                imgCustGrid24, imgCustGrid30, imgCustGrid31, imgCustGrid32, imgCustGrid33, imgCustGrid34, imgCustGrid40,
                                imgCustGrid41, imgCustGrid42, imgCustGrid43, imgCustGrid44
                            };
                            for (int i = 0; i < 5; i++)
                            {
                                for (int j = 0; j < 5; j++)
                                {
                                    NaviCustGrid ncg = new NaviCustGrid();
                                    ncg.BlockType = 0;
                                    ncg.PivotX = i;
                                    ncg.PivotY = j;
                                    naviCustGrid[i, j] = ncg;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    foreach (PictureBox box in naviCust.PictureBoxList)
                    {
                        int xPos = box.Location.X;
                        int yPos = box.Location.Y;
                        switch (3 - naviCust.CustSize)
                        {
                            case 1:
                            case 2:
                                xPos += 75;
                                yPos += 75;
                                break;
                            case 3:
                                xPos += 112;
                                yPos += 75;
                                break;
                            default:
                                break;
                        }
                        box.Location = new Point(xPos, yPos);
                    }
                    List<PictureBox> colorBoxes = new List<PictureBox> { imgColorBox1, imgColorBox2, imgColorBox3, imgColorBox4 };
                    imgRunLine.Location = new Point(imgRunLine.Location.X, imgRunLine.Location.Y + 75);
                    labelStyleName.Location = new Point(labelStyleName.Location.X, labelStyleName.Location.Y + 75);
                    foreach (PictureBox box in colorBoxes)
                    {
                        box.Location = new Point(box.Location.X, box.Location.Y + 75);
                    }
                    break;
            }
        }
        public void ReadGrid()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    naviCustGrid[i, j].Index = naviCust.GridPos[i, j];
                    if (naviCustGrid[i, j].Index == 0) continue; // If the space is 0, there's no data to gather here.
                    List<int> ColorID = ParseIDandColor(naviCust.NcpGrid[naviCustGrid[i, j].Index - 1][0]); // ColorID[0] is color, ColorID[1] is ID
                    naviCustGrid[i, j].PartName = naviCust.NcpMapList[ColorID[1]].ncpName;
                    naviCustGrid[i, j].Color = naviCust.NcpMapList[ColorID[1]].ncpColors[ColorID[0]];
                    naviCustGrid[i, j].BlockType = naviCust.NcpMapList[ColorID[1]].isProg ? 1 : 2;
                    naviCustGrid[i, j].PivotX = naviCust.NcpGrid[naviCustGrid[i, j].Index - 1][1];
                    naviCustGrid[i, j].PivotY = naviCust.NcpGrid[naviCustGrid[i, j].Index - 1][2];
                    naviCustGrid[i, j].Rotation = naviCust.NcpGrid[naviCustGrid[i, j].Index - 1][3];
                    if (!naviCust.GridIndex.ContainsKey(naviCustGrid[i, j].Index))
                    {
                        naviCust.GridIndex.Add(naviCustGrid[i, j].Index, naviCustGrid[i, j].PartName);
                    }
                }
            }
        }
        public void ReadStats()
        {
            int gutsMod = naviCust.IsGuts ? 2 : 1;
            int custMod = naviCust.IsCust ? 1 : 0;
            int teamMod = naviCust.IsTeam ? 1 : 0;
            labelHPTotal.Text = (naviCust.BaseHP + naviCust.BonusHP + naviCust.ModHP).ToString();
            labelAttack.Text = (Math.Min(naviCust.AtkBonus, 5) * gutsMod).ToString();
            labelSpeed.Text = (Math.Min(naviCust.SpdBonus, 5) + 1).ToString();
            labelCharge.Text = (Math.Min(naviCust.ChrgBonus, 5) + 1).ToString();
            labelCShot.Text = Math.Min(naviCust.CShotBonus, 3).ToString();
            labelRegMem.Text = (naviCust.RegMem + naviCust.BonusRegMem).ToString();
            labelMegaLimit.Text = (naviCust.MegaLimit + teamMod + naviCust.ModMega).ToString();
            labelGigaLimit.Text = (naviCust.GigaLimit + naviCust.ModGiga).ToString();
            labelCustHandSize.Text = (naviCust.CustomSize + custMod + naviCust.ModCustom).ToString();
        }
        public void PopulateGrid()
        {
            int index = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    switch (naviCustGrid[i, j].BlockType)
                    {
                        case 1:
                            switch (naviCustGrid[i, j].Color)
                            {
                                case "White":
                                    naviCust.PictureBoxList[index].Image = Properties.Resources.NCPblockWhite;
                                    break;
                                case "Red":
                                    naviCust.PictureBoxList[index].Image = Properties.Resources.NCPblockRed;
                                    break;
                                case "Pink":
                                    naviCust.PictureBoxList[index].Image = Properties.Resources.NCPblockPink;
                                    break;
                                case "Orange":
                                    naviCust.PictureBoxList[index].Image = Properties.Resources.NCPblockOrange;
                                    break;
                                case "Yellow":
                                    naviCust.PictureBoxList[index].Image = Properties.Resources.NCPblockYellow;
                                    break;
                                case "Green":
                                    naviCust.PictureBoxList[index].Image = Properties.Resources.NCPblockGreen;
                                    break;
                                case "Blue":
                                    naviCust.PictureBoxList[index].Image = Properties.Resources.NCPblockBlue;
                                    break;
                                case "Purple":
                                    naviCust.PictureBoxList[index].Image = Properties.Resources.NCPblockPurple;
                                    break;
                                case "Dark":
                                    naviCust.PictureBoxList[index].Image = Properties.Resources.NCPblockDark;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 2:
                            switch (naviCustGrid[i, j].Color)
                            {
                                case "White":
                                    naviCust.PictureBoxList[index].Image = Properties.Resources.NCPplusblockWhite;
                                    break;
                                case "Red":
                                    naviCust.PictureBoxList[index].Image = Properties.Resources.NCPplusblockRed;
                                    break;
                                case "Pink":
                                    naviCust.PictureBoxList[index].Image = Properties.Resources.NCPplusblockPink;
                                    break;
                                case "Yellow":
                                    naviCust.PictureBoxList[index].Image = Properties.Resources.NCPplusblockYellow;
                                    break;
                                case "Green":
                                    naviCust.PictureBoxList[index].Image = Properties.Resources.NCPplusblockGreen;
                                    break;
                                case "Blue":
                                    naviCust.PictureBoxList[index].Image = Properties.Resources.NCPplusblockBlue;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    naviCust.PictureBoxList[index].Tag = naviCustGrid[i, j].PartName;
                    index++;
                }
            }
        }
        public void ReadEffects()
        {
            Dictionary<string, int> effects = new Dictionary<string, int>
            {
                { "HP", naviCust.BonusHP },
                { "Attack", (naviCust.AtkBonus / (naviCust.IsGuts ? 2 : 1)) - 1 },
                { "Speed", naviCust.SpdBonus },
                { "Charge", naviCust.ChrgBonus },
                { "WeapLvl", naviCust.CShotBonus - 1 },
                { "RegMem", naviCust.BonusRegMem },
                { "MegaChip", naviCust.ModMega },
                { "GigaChip", naviCust.ModGiga },
                { "Custom", naviCust.CustomSize - 5 }
            };

            foreach (KeyValuePair<string, int> effect in effects)
            {
                if (effect.Value > 0)
                    dgvEffects.Rows.Add($"{effect.Key}+{effect.Value}");
            }

            List<string> parts = new List<string>();
            List<string> excludes = new List<string> { "HP+100", "HP+200", "HP+300", "HP+500", "Reg+5", "Atk+1", "Speed+1", "Charge+1", "WeapLvl+1", "Custom1", "Custom2", "MegFldr1", "MegFldr2", "GigFldr1" };
            for (int i = 1; i < naviCust.GridIndex.Count; i++)
            {
                if (!parts.Any(x => x == naviCust.GridIndex[i]) && !excludes.Any(x => x == naviCust.GridIndex[i]))
                {
                    parts.Add(naviCust.GridIndex[i]);
                    dgvEffects.Rows.Add(naviCust.GridIndex[i]);
                }
            }
            if (naviCust.ModCode < 0x42 && naviCust.ModCode > 0)
            {
                dgvEffects.Rows.Add($"ModTools: " + naviCust.ModCodeDict[naviCust.ModCode]);
            }
        }
        public void ReadBugs()
        {
            string bugEffect;
            int bugLevel;
            for (int i = 0; i < naviCust.Bugs.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        bugEffect = "Player Movement: ";
                        switch (naviCust.Effects[15])
                        {
                            case 4:
                                bugEffect = bugEffect + "Up";
                                break;
                            case 8:
                                bugEffect = bugEffect + "Down";
                                break;
                            case 12:
                                bugEffect = bugEffect + "Confused";
                                break;
                            default:
                                bugEffect = "Error";
                                break;
                        }
                        break;
                    case 1:
                        bugEffect = "Battle HP Drain";
                        break;
                    case 2:
                        bugEffect = "Custom HP Drain";
                        break;
                    case 3:
                        bugEffect = "Battle Panel: ";
                        bugEffect = naviCust.Bugs[3] == 13 ? bugEffect + "Cracked" : naviCust.Bugs[3] == 14 ? bugEffect + "Swamp" : "Error";
                        break;
                    case 4:
                        bugEffect = "SlowGauge";
                        break;
                    case 5:
                        bugEffect = "Increased Encounters";
                        break;
                    case 6:
                        bugEffect = "Buster Misfire";
                        break;
                    case 7:
                        bugEffect = "Support Disabled";
                        break;
                    case 8:
                        bugEffect = "Modified C. Shot: ";
                        switch (naviCust.Effects[11])
                        {
                            case 1:
                                bugEffect = bugEffect + "Rock Cube";
                                break;
                            case 2:
                                bugEffect = bugEffect + "Water Gun";
                                break;
                            case 3:
                                bugEffect = bugEffect + "Flower";
                                break;
                            default:
                                bugEffect = "Error";
                                break;
                        }
                        break;
                    case 9:
                        bugEffect = "Battle Result: Zenny";
                        break;
                    case 10:
                        bugEffect = "AutoBug: BustrMAX";
                        break;
                    case 11:
                        bugEffect = "AutoBug: GigFldr1";
                        break;
                    case 12:
                        bugEffect = "AutoBug: HubBatch";
                        break;
                    case 13:
                        bugEffect = "AutoBug: DarkLcns";
                        break;
                    case 14:
                        bugEffect = "ModTools: ";
                        switch (naviCust.ModCode)
                        {
                            case 0x24:
                            case 0x25:
                            case 0x26:
                            case 0x27:
                            case 0x2D:
                            case 0x34:
                            case 0x35:
                                bugEffect = bugEffect + "Custom -1";
                                break;
                            case 0x28:
                            case 0x29:
                            case 0x2A:
                            case 0x2C:
                            case 0x38:
                                bugEffect = bugEffect + "Custom -2";
                                break;
                            case 0x3E:
                            case 0x3F:
                            case 0x40:
                            case 0x41:
                                bugEffect = bugEffect + "Swamp Step";
                                break;
                            default:
                                bugEffect = "Error";
                                break;
                        }
                        break;
                    default:
                        bugEffect = "Error";
                        break;
                }
                bugLevel = naviCust.Bugs[i];
                if (bugLevel > 0)
                {
                    dgvBugs.Rows.Add(bugEffect, bugLevel);
                }
            }
        }
        public void PopulateNCPList()
        {
            int qty;
            foreach (NCPListing part in naviCust.NcpMapList)
            {
                if (part.ncpName == "None") continue;
                foreach (string color in part.ncpColors)
                {
                    if (color == "None") continue;
                    else
                    {
                        switch (part.ncpColors.IndexOf(color))
                            {
                            case 0:
                                qty = part.QuantityCol1;
                                break;
                            case 1:
                                qty = part.QuantityCol2;
                                break;
                            case 2:
                                qty = part.QuantityCol3;
                                break;
                            case 3:
                                qty = part.QuantityCol4;
                                break;
                            default:
                                qty = 69420;
                                break;
                        }
                        dgvNCPInv.Rows.Add(part.ncpName, part.isCompressed, color, qty);
                    }
                }
            }
        }
        public List<int> ParseIDandColor(int ncp)
        {
            byte[] bytes = BitConverter.GetBytes(ncp);
            int color = bytes[0] & 3;
            int id = bytes[0] >> 2;
            return new List<int>() { color, id };
        }
        public void setupPreview()
        {
            DataGridViewRow dgv = dgvNCPInv.CurrentRow;
            dgv.Selected = true;
            DataGridViewCellCollection currentCells = dgv.Cells;
            string partName = (string)currentCells[0].Value;
            string color = (string)currentCells[2].Value;
            bool isProg = naviCust.NcpMapList.FirstOrDefault(x => x.ncpName == partName).isProg;
            Image partPic = picSetup(color, isProg);
            int[,] shape = shapeSetup(partName, currentCells[1].Value.ToString());
            for (int i = 0; i < rotator; i++)
            {
                shape = rotateShape(shape);
            }
            displayPreview(partPic, shape);
        }
        public void displayPreview(Image pic, int[,] shape)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    preview[i * 5 + j].Image = shape[i, j] == 1 ? pic : Properties.Resources.NCPGrid;
                }
            }
            Cleanup();
        }
        public int[,] shapeSetup(string partName, string isCom)
        {
            List<NCPListing> map = naviCust.NcpMapList;
            bool isCompressed = isCom == "True" ? true : false;
            int partId = map.IndexOf(map.FirstOrDefault(e => e.ncpName == partName));
            int[,] shape = (int[,]) map[partId].ncpData.FirstOrDefault(e => e.Key == isCompressed).Value.Clone(); // Clone so we don't transform the original data
            return shape;
        }
        public Image picSetup(string color, bool isProg) 
        {
            Image partPic = Properties.Resources.NCPGrid;
            switch (color)
            {
                case "White":
                    partPic = isProg ? Properties.Resources.NCPblockWhite : Properties.Resources.NCPplusblockWhite;
                    break;
                case "Red":
                    partPic = isProg ? Properties.Resources.NCPblockRed : Properties.Resources.NCPplusblockRed;
                    break;
                case "Pink":
                    partPic = isProg ? Properties.Resources.NCPblockPink : Properties.Resources.NCPplusblockPink;
                    break;
                case "Orange":
                    partPic = Properties.Resources.NCPblockOrange;
                    break;
                case "Yellow":
                    partPic = isProg ? Properties.Resources.NCPblockYellow : Properties.Resources.NCPplusblockYellow;
                    break;
                case "Green":
                    partPic = isProg ? Properties.Resources.NCPblockGreen : Properties.Resources.NCPplusblockGreen;
                    break;
                case "Blue":
                    partPic = isProg ? Properties.Resources.NCPblockBlue : Properties.Resources.NCPplusblockBlue;
                    break;
                case "Purple":
                    partPic = Properties.Resources.NCPblockPurple;
                    break;
                case "Dark":
                    partPic = Properties.Resources.NCPblockDark;
                    break;
                default:
                    break;
            }
            return partPic;
        }
        static int[,] rotateShape(int[,] shape)
        {
            for (int i = 0; i < 5 / 2; i++)
            {
                for (int j = i; j < 5 - i - 1; j++)
                {
                    // Swap elements of each cycle
                    // in clockwise direction
                    int temp = shape[i, j];
                    shape[i, j] = shape[4 - j, i];
                    shape[4 - j, i] = shape[4 - i, 4 - j];
                    shape[4 - i, 4 - j] = shape[j, 4 - i];
                    shape[j, 4 - i] = temp;
                }
            }
            return shape;
        }
        private void emptyHands() // Drops any piece that was selected on the board
        {
            lblSelected.Enabled = false;
            lblSelected.Text = "";
            lblSelectedHeader.Enabled = false;
            btnMove.Enabled = false;
            btnRemove.Enabled = false;
            lblMessage.Visible = false;
        }
        private void redrawBorders() // redraws all borders
        {
            naviCust.PictureBoxList.ForEach(p => ControlPaint.DrawBorder(p.CreateGraphics(), p.ClientRectangle, Color.FromArgb(0, 0, 0), ButtonBorderStyle.Solid));
        }
        private void jumpToNCP (NaviCustGrid selection)
        {
            rotator = selection.Rotation;
            foreach (DataGridViewRow row in dgvNCPInv.Rows)
            {
                if (row.Cells[0].Value.ToString() == selection.PartName && row.Cells[2].Value.ToString() == selection.Color)
                {
                    dgvNCPInv.CurrentCell = row.Cells[0];
                    break;
                }
            }
            setupPreview();
        }
        private void selectPart(PictureBox box)
        {
            int r = 50;
            int g = 220;
            int b = 255;
            int index = naviCust.PictureBoxList.IndexOf(box);
            int indX = naviCustGrid.GetLength(0);
            int indY = naviCustGrid.GetLength(1);
            List<int> indexList = new List<int>();
            NaviCustGrid selection = naviCustGrid[index / indX, index % indY];
            int[] coordinates = new int[2];
            coordinates[0] = index / indX;
            coordinates[1] = index % indY;
            selectedPart = coordinates;
            emptyHands();
            redrawBorders();
            if (selection.Index != 0)
            {
                jumpToNCP(selection);
                lblSelected.Enabled = true;
                lblSelected.Text = selection.PartName;
                lblSelectedHeader.Enabled = true;
                btnMove.Enabled = true;
                btnRemove.Enabled = true;
                lblMessage.Visible = true;
                for (int i = 0; i < indX; i++)
                {
                    for (int j = 0; j < indY; j++)
                    {
                        if (naviCustGrid[i, j].Index == selection.Index)
                        {
                            indexList.Add(i * indX + j);
                        }
                    }
                }
                for (int i = 0; i <= 255; i += 10)
                {
                    indexList.ForEach(p => ControlPaint.DrawBorder(naviCust.PictureBoxList[p].CreateGraphics(), naviCust.PictureBoxList[p].ClientRectangle, Color.FromArgb(Math.Min(i, r), Math.Min(i, g), Math.Min(i, b)), ButtonBorderStyle.Dashed));
                } // Don't .Dispose() here! Let cleanup() take care of it.
            }
        }
        private void showPlacement(PictureBox box)
        {
            int r = 255;
            int g = 0;
            int b = 0;
            redrawBorders();
            int index = naviCust.PictureBoxList.IndexOf(box);
            int[] coordinates = new int[2];
            List<int> indexList = new List<int>();
            coordinates[0] = index / naviCustGrid.GetLength(0);
            coordinates[1] = index % naviCustGrid.GetLength(1); // coordinates is where we're currently hovering over, so it's our Pivot anchor
            DataGridViewCellCollection part = dgvNCPInv.CurrentRow.Cells;
            int[,] shape = shapeSetup(part[0].Value.ToString(), part[1].Value.ToString());
            for (int i = 0; i < rotator; i++)
            {
                shape = rotateShape(shape);
            }
            int[,] shiftedShape = shiftShape(shape, coordinates[0], coordinates[1]);
            for (int i = 0; i < naviCustGrid.GetLength(0); i++)
            {
                for (int j = 0; j < naviCustGrid.GetLength(1); j++)
                {
                    if (shiftedShape[i, j] == 1)
                    {
                        indexList.Add(i * naviCustGrid.GetLength(0) + j);
                    }
                }
            }
            indexList.ForEach(p => ControlPaint.DrawBorder(naviCust.PictureBoxList[p].CreateGraphics(), naviCust.PictureBoxList[p].ClientRectangle, Color.FromArgb(r, g, b), ButtonBorderStyle.Dashed));
            // highlight border based on shape
        }
        private int[,] shiftShape(int[,] shape, int posX, int posY)
        {
            int[,] shapePlace = new int[naviCustGrid.GetLength(0), naviCustGrid.GetLength(1)]; // Needs to be the precise size of the naviCustGrid
            for (int i = 0; i < shapePlace.GetLength(0); i++)
            {
                for (int j = 0; j < shapePlace.GetLength(1); j++)
                {
                    try
                    {
                        if (shape[i, j] == 1 && posX - 2 + i >= 0 && posY - 2 + j >= 0 && posX - 2 + i < shapePlace.GetLength(0) && posY - 2 + j < shapePlace.GetLength(1))
                        { // Make sure everything is in bounds
                            shapePlace[posX - 2 + i, posY - 2 + j] = 1;
                        }
                    }
                    catch
                    { // This means that something's off the grid, just ignore it for now
                        continue;
                    }
                }
            }
            return shapePlace;
        }
        private void placePart(PictureBox box) // This should be the actual act of placing the part.
        {
            int index = naviCust.PictureBoxList.IndexOf(box);
            int posX = index / naviCustGrid.GetLength(0);
            int posY = index % naviCustGrid.GetLength(1);
            NaviCustGrid part = new NaviCustGrid();
            DataGridViewCellCollection partInfo = dgvNCPInv.CurrentRow.Cells;
            part.PartName = partInfo[0].Value.ToString();
            part.Color = partInfo[2].Value.ToString();
            part.PivotX = posX;
            part.PivotY = posY;
            part.BlockType = naviCust.NcpMapList.FirstOrDefault(x => x.ncpName == part.PartName).isProg ? 1 : 2;
            part.Rotation = rotator;
            part.Index = 1; // The minimum amount of index a part can be
            foreach (NaviCustGrid entry in naviCustGrid)
            {
                if (entry.Index >= part.Index) // Make sure the newest index is the absolute highest on the list
                {
                    part.Index = entry.Index + 1;
                }
            }
            bool emergencyExit = false;
            if (_placement_mode)
            { // Regardless of how the part was obtained, the currently selected part should always be the one highlighted in inventory
                int[,] shape = shapeSetup(part.PartName, dgvNCPInv.CurrentRow.Cells[1].Value.ToString());
                Image pic = picSetup(part.Color, part.BlockType == 1 ? true : false);
                for (int i = 0; i < rotator; i++)
                {
                    shape = rotateShape(shape);
                }
                int[,] shapePlace = shiftShape(shape, posX, posY); // Move the shape relative to where we want it
                for (int i = 0; i < shapePlace.GetLength(0); i++)
                {
                    for (int j = 0; j < shapePlace.GetLength(1); j++)
                    {
                        try
                        {
                            if (shape[i,j] == 1 && posX-2+i >= 0 && posY-2+j >=0 && posX-2+i < shapePlace.GetLength(0) && posY-2+j < shapePlace.GetLength(1))
                            { // Make sure everything is in bounds
                                shapePlace[posX - 2 + i, posY - 2 + j] = 1;
                            }
                            else if (shape[i,j] == 1 && (posX-2+i < 0 || posY-2+j < 0 || posX-2+i >= shapePlace.GetLength(0) || posY-2+j >= shapePlace.GetLength(1)))
                            {
                                throw new Exception();
                            }
                        }
                        catch
                        { // This means that something's off the grid, can't place it here
                            emergencyExit = true;
                            break;
                        }
                    }
                }
                for (int i = 0; i < shapePlace.GetLength(0) && !emergencyExit; i++)
                {
                    for (int j = 0; j < shapePlace.GetLength(1) && !emergencyExit; j++)
                    {
                        if (shapePlace[i, j] != 1) // Make sure all values are populated
                        {
                            shapePlace[i, j] = 0; // Do me a favor and check if this part is even necessary later
                        }
                    }
                }
                for (int i = 0; i < naviCustGrid.GetLength(0) && !emergencyExit; i++)
                {
                    for (int j = 0; j < naviCustGrid.GetLength(1) && !emergencyExit; j++)
                    {
                        try
                        {
                            if (naviCustGrid[i, j].Index == 0 && shapePlace[i, j] == 1)
                            {
                                naviCust.PictureBoxList[i * naviCustGrid.GetLength(0) + j].Image = pic;
                                naviCust.PictureBoxList[i * naviCustGrid.GetLength(0) + j].Refresh();
                                naviCust.PictureBoxList[i * naviCustGrid.GetLength(0) + j].Tag = part.PartName;
                                naviCustGrid[i, j].PartName = part.PartName;
                                naviCustGrid[i, j].PivotX = part.PivotX;
                                naviCustGrid[i, j].PivotY = part.PivotY;
                                naviCustGrid[i, j].BlockType = part.BlockType;
                                naviCustGrid[i, j].Color = part.Color;
                                naviCustGrid[i, j].Rotation = rotator;
                                naviCustGrid[i, j].Index = part.Index;
                                selectedPart[0] = i;
                                selectedPart[1] = j;
                            }
                            else if (naviCustGrid[i, j].Index != 0 && shapePlace[i, j] == 1)
                            {   // If the index isn't 0 but the shape to place is 1, it's either another piece or in the void
                                throw new Exception();
                            }
                        }
                        catch
                        {
                            emergencyExit = true;
                            break;
                        }
                    }
                }
            }
            if (emergencyExit) abortPlacement();
            else placementMode(); // If we got here without triggering emergencyExit, then we're done here, disengage placementMode
        }
        private void abortPlacement()
        {
            removePart();
            MessageBox.Show("Error: Unable to place part in this location. \nReason: Illegal Placement.");
        }
        private void removePart()
        {
            NaviCustGrid selection = naviCustGrid[selectedPart[0], selectedPart[1]];
            lblSelected.Enabled = false;
            lblSelected.Text = "";
            lblSelectedHeader.Enabled = false;
            btnMove.Enabled = false;
            btnRemove.Enabled = false;
            lblMessage.Visible = false;
            int indX = naviCustGrid.GetLength(0);
            int indY = naviCustGrid.GetLength(1);
            for (int i = 0; i < indX; i++)
            {
                for (int j = 0; j < indY; j++)
                {
                    if (naviCustGrid[i, j].Index == selection.Index)
                    {
                        naviCustGrid[i, j] = new NaviCustGrid(); // Reset to default
                        naviCust.PictureBoxList[i * indX + j].Image = Properties.Resources.NCPGrid;
                        naviCust.PictureBoxList[i * indX + j].Refresh();
                        naviCust.PictureBoxList[i * indX + j].Tag = null; // Reset the risidual data, it persists for some reason
                    }
                }
            }
            selectedPart = new int[2]; // Nothing is selected anymore, reset the value here.
            reindexGridParts(selection.Index);
            // Redirect to method that recalculates NaviCust stats/bugs here
        }
        public void reindexGridParts(int index) // As a side note, reindexing should only occur when removing a part from the grid
        {
            foreach (NaviCustGrid part in naviCustGrid)
            {
                part.Index = part.Index > index ? part.Index-- : part.Index;
            }
        }
        private void placementMode() // Engage or disengage placement mode
        {
            _placement_mode = !_placement_mode;
            if (_placement_mode) Cursor.Current = Cursors.Hand;
            else Cursor.Current = Cursors.Default;
        }
        private void infoText(PictureBox image)
        {
            if ((string)image.Tag != null && (string)image.Tag != "" && image.Visible == true)
            {
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(image, (string)image.Tag);
                toolTip.Active = true;
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
            foreach (PictureBox box in preview)
            {
                pictureBoxes.Append(box);
            }
            foreach (PictureBox box in pictureBoxes)
            {
                box.Image.Dispose();
            }
        }
        private void NaviCustEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cleanup();
        }
        private void imgCustGrid_MouseHover(object sender, EventArgs e)
        {
            PictureBox image = (PictureBox)sender;
            if (!_placement_mode) infoText(image);
        }
        private void imgCustGrid_MouseLeave(object sender, EventArgs e)
        {
            if (!_placement_mode)
            {
                PictureBox image = (PictureBox)sender;
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(image, "");
                toolTip.Active = false;
            }
            if (_placement_mode) redrawBorders();
        }
        private void dgvNCPInv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rotator = 0;
            setupPreview();
        }
        private void btnRotCW_Click(object sender, EventArgs e)
        {
            rotator++;
            if (rotator > 3) rotator = 0;
            setupPreview();
        }
        private void btnRotCCW_Click(object sender, EventArgs e)
        {
            rotator--;
            if (rotator < 0) rotator = 3;
            setupPreview();
        }
        private void btnCompress_Click(object sender, EventArgs e)
        {
            DataGridViewCellCollection cell = dgvNCPInv.CurrentRow.Cells;
            NCPListing part = naviCust.NcpMapList.FirstOrDefault(x => x.ncpName == (string)cell[0].Value);
            bool setCompress = (bool)cell[1].Value;
            if (part.ncpData.ContainsKey(true)) // if it can't compress, you must acquit
            {
                foreach (DataGridViewRow row in dgvNCPInv.Rows) // Some parts have multiple colors, this will change the value for all with the same name
                {
                    if (row.Cells[0].Value == cell[0].Value)
                    {
                        row.Cells[1].Value = !setCompress; // Flip the value to the reverse.
                    }
                }
                setupPreview();
             }
        }
        private void custGrid_Click(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            if (!_placement_mode)
            {
                selectPart(box);
            }
            if (_placement_mode)
            {
                placePart(box);
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            removePart();
        }
        private void btnPlacePart_Click(object sender, EventArgs e)
        {
            placementMode();
        }
        private class NaviCustGrid
        {
            public int BlockType { get; set; } // Empty Grid space, Program part, or Plus part. -1 is void.
            public string Color { get; set; } = ""; // Color of the piece
            public string PartName { get; set; } = ""; // No name should pop up on a blank grid space.
            public int PivotX { get; set; } = 0; // Where the piece's center is anchored
            public int PivotY { get; set; } = 0;
            public int Rotation { get; set; } = 0; // 0 = No rotation. Each increase is one clockwise rotation
            public int Index { get; set; } = 0; // This is for GridPosData. Keep track of the order of placement.
        }

        private void imgCustGrid_MouseEnter(object sender, EventArgs e)
        {
            PictureBox image = (PictureBox)sender;
            if (_placement_mode)
            {
                redrawBorders();
                showPlacement(image);
            }
        }
    }
}