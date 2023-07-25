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
        private NaviCust naviCust = new NaviCust();
        private NaviCustGrid[,] naviCustGrid;
        private SaveDataObject _initialSave;
        private Style _style;
        
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
        public List<int> ParseIDandColor(int ncp)
        {
            byte[] bytes = BitConverter.GetBytes(ncp);
            int color = bytes[0] & 3;
            int id = bytes[0] >> 2;
            return new List<int>() { color, id };
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
                    cBoxModCode.SelectedItem = "Equip Block (Left+B)";
                    break;
                case 0x33:
                    cBoxModCode.SelectedItem = "Equip Shield (Left+B)";
                    break;
                case 0x34:
                    cBoxModCode.SelectedItem = "Equip Reflect (Left+B) *";
                    break;
                case 0x35:
                    cBoxModCode.SelectedItem = "Equip Anti-Damage (Left+B) *";
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
        public void ReadCompression()
        {
            for (int i = 0; i < naviCust.NcpMapList.Count; i++)
            {
                naviCust.NcpMapList[i].isCompressed = naviCust.Compression[i] == 1;
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
    }
}
