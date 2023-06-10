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

        public StyleSelect()
        {
            InitializeComponent();
        }

        public StyleSelect(Style.Value styleName)
        {
            InitializeComponent();
            StyleValue = styleName;
            StyleName = styleName.GetString();
            radEquipStyle.CheckedChanged += (s, e) => EquipStyleChecked?.Invoke(this, e);
        }
    }
}
