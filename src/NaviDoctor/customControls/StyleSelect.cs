using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NaviDoctor.extensions;
using NaviDoctor.models;

namespace NaviDoctor.customControls
{
    public partial class StyleSelect : UserControl
    {
        public event EventHandler EquipStyleChecked;
        public event EventHandler AddStyleChecked;
        public Style.Value StyleValue {get; set;}

        public bool AddStyle
        {
            get => cbxAddStyle.Checked;
            set => cbxAddStyle.Checked = value;
        }

        public bool EquipStyle
        {
            get => radEquipStyle.Checked;
            set => radEquipStyle.Checked = value;
        }

        public string StyleName
        {
            get => radEquipStyle.Text;
            set => radEquipStyle.Text = value;
        }

        public int Version
        {
            get => (int)nudVersion.Value;
            set => nudVersion.Value = value;
        }

        public StyleSelect()
        {
            InitializeComponent();
        }

        public StyleSelect(Style style, GameTitle.Title title)
        {
            InitializeComponent();
            StyleValue = style.Name;
            StyleName = style.Name.GetString();
            switch(title)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    nudVersion.Visible = false;
                    break;
                case GameTitle.Title.MegaManBattleNetwork2:
                    break;

            }
            if(style.Name == Style.Value.Normal)
            {
                cbxAddStyle.Visible = false;
                nudVersion.Visible = false;
            }
            if(style.Name == Style.Value.Hub)
            {
                nudVersion.Visible = false;
            }
            radEquipStyle.CheckedChanged += (s, e) => EquipStyleChecked?.Invoke(this, e);
            cbxAddStyle.CheckedChanged += (s, e) => AddStyleChecked?.Invoke(this, e);
        }

        public void ToggleAdd(bool toggle)
        {
            cbxAddStyle.Enabled = toggle;
        }
        public void ToggleEquip(bool toggle)
        {
            radEquipStyle.Enabled = toggle;
        }
    }
}
