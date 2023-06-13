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
        private const int MAX_STYLE_BN2 = 3;
        private int currentAddCount = 0;
        private Style.Value _currentEquipStyle;
        public List<Style> _styles;

        public StyleLoader()
        {
            InitializeComponent();
        }

        public StyleLoader(List<Style> styles, GameTitle.Title title)
        {
            InitializeComponent();
            _styles = styles;
            if (title == GameTitle.Title.MegaManBattleNetwork) label3.Visible = false;
            PopulateStyles(title);
        }

        private void PopulateStyles(GameTitle.Title title)
        {
            foreach(var style in _styles)
            {
                var styleSelect = new StyleSelect(style, title);
                styleSelect.EquipStyle = _styles.FirstOrDefault(x => x.Name == style.Name).Equip.GetValueOrDefault();
                styleSelect.AddStyle = _styles.FirstOrDefault(x => x.Name == style.Name).Add.GetValueOrDefault();
                styleSelect.EquipStyleChecked += (s, e) => EquipCheck(styleSelect);
                styleSelect.AddStyleChecked += (s, e) => AddCheck(title);
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

        private void AddCheck(GameTitle.Title title)
        {
            currentAddCount = 0;
            foreach (StyleSelect style in flpStyleChange.Controls)
            {
                if (style.AddStyle) currentAddCount++;

                if (title == GameTitle.Title.MegaManBattleNetwork2)
                {
                    if (currentAddCount > MAX_STYLE_BN2)
                    {
                        MessageBox.Show("You can only select 3 styles to add.", "Error", MessageBoxButtons.OK);
                        style.AddStyle = false;
                        return;
                    } 
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
