using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NaviDoctor.customControls;
using NaviDoctor.models;

namespace NaviDoctor
{
    public partial class StyleLoader : Form
    {
        private Style.Value _currentEquipStyle;
        public List<Style> _styles;

        public StyleLoader()
        {
            InitializeComponent();
        }

        public StyleLoader( List<Style> styles)
        {
            InitializeComponent();
            _styles = styles;
            PopulateStyles();
        }

        private void PopulateStyles()
        {
            foreach(var style in _styles)
            {
                var styleSelect = new StyleSelect(style.Name);
                styleSelect.EquipStyle = _styles.FirstOrDefault(x => x.Name == style.Name).Equip.GetValueOrDefault();
                styleSelect.AddStyle = _styles.FirstOrDefault(x => x.Name == style.Name).Add.GetValueOrDefault();
                styleSelect.EquipStyleChecked += (s, e) => EquipCheck(styleSelect);
                //Most likely will need to also add an AddStyleCheck since we won't allow users to add all styles for BN2
                flpStyleChange.Controls.Add(styleSelect);
            }
        }
        private void EquipCheck(StyleSelect styleSelect)
        {
            if (styleSelect.EquipStyle)
            {
                _currentEquipStyle = styleSelect.StyleValue;
            }

            foreach (StyleSelect style in flpStyleChange.Controls)
            {
                if(style.StyleValue != _currentEquipStyle)
                {
                    style.EquipStyle = false;
                }
            }
        }

        private void GetStyles()
        {
            foreach (StyleSelect style in flpStyleChange.Controls)
            {
                _styles.FirstOrDefault(x => x.Name == style.StyleValue).Equip = style.EquipStyle;
                _styles.FirstOrDefault(x => x.Name == style.StyleValue).Add = style.AddStyle;
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            GetStyles();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
