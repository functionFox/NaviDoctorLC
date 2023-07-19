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
        public NaviCustEdit()
        {
            InitializeComponent();
            imgRunLine.Parent = imgCustGrid;
        }
        public NaviCustEdit(SaveDataObject save, Style style)
        {
            InitializeComponent();
            imgRunLine.Parent = imgCustGrid;
            _hpUp = save.HPUp;
            _custSize = save.CustSize;
            _atkBonus = save.AttackPower;
            _spdBonus = save.RapidPower;
            _chrgBonus = save.ChargePower;
            _cShotBonus = save.CShotPower;
            _ncpInv = save.NCPInventory;
            _compression = save.Compression;
            _ncpGrid = save.NCPGrid;
            _gridPos = save.GridPosData;
            _effects = save.CustEffects;
            _bugs = save.CustBugs;
            _modCode = save.ModCode;
            _megaLimit = save.MegaLimit;
            _gigaLimit = save.GigaLimit;
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
                _maxHP = 2 * save.MaxHP;
            }
            else
            {
                _maxHP = save.MaxHP;
            }
            _bonusHP = (short)(_maxHP - (_hpUp * 20) - 100);
            switch (style.Name)
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
        }
    }
}
