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
        private const int MAX_STYLE_BN2 = 2;
        private int currentAddCount = 0;
        private GameTitle.Title _currentGame;
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
            _currentGame = title;
            if (_currentGame == GameTitle.Title.MegaManBattleNetwork) label3.Visible = false;
            PopulateStyles();
        }

        private void PopulateStyles()
        {
            foreach(var style in _styles)
            {
                var styleSelect = new StyleSelect(style, _currentGame);
                styleSelect.EquipStyle = _styles.FirstOrDefault(x => x.Name == style.Name).Equip.GetValueOrDefault();
                styleSelect.AddStyle = _styles.FirstOrDefault(x => x.Name == style.Name).Add.GetValueOrDefault();
                if (_currentGame == GameTitle.Title.MegaManBattleNetwork2 && style.Name != Style.Value.Normal)
                {
                    styleSelect.Version = _styles.FirstOrDefault(x => x.Name == style.Name).Version.GetValueOrDefault();
                }
                styleSelect.EquipStyleChecked += (s, e) => EquipCheck(styleSelect);
                styleSelect.AddStyleChecked += (s, e) => AddCheck();
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

        private void AddCheck()
        {
            currentAddCount = 0;
            foreach (StyleSelect style in flpStyleChange.Controls)
            {
                if (style.AddStyle) currentAddCount++;

                if (_currentGame == GameTitle.Title.MegaManBattleNetwork2)
                {
                    if (currentAddCount > MAX_STYLE_BN2)
                    {
                        MessageBox.Show($"You can only select {MAX_STYLE_BN2} styles to add.", "Error", MessageBoxButtons.OK);
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
                if (_currentGame == GameTitle.Title.MegaManBattleNetwork2) { _styles.FirstOrDefault(x => x.Name == style.StyleValue).Version = style.Version; }
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
