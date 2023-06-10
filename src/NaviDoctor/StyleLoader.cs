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

namespace NaviDoctor
{
    public partial class StyleLoader : Form
    {
        private GameTitle.Title _gameTitle;
        private string _currentEquipStyle;

        public StyleLoader()
        {
            InitializeComponent();
        }

        public StyleLoader(GameTitle.Title gameTitle)
        {
            InitializeComponent();
            _gameTitle = gameTitle;
            LoadStyles();
        }


        private void LoadStyles()
        {

            switch (_gameTitle)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    PopulateStyles(Style.BN1);
                    break;
                case GameTitle.Title.MegaManBattleNetwork2:
                    PopulateStyles(Style.BN2);
                    break;
                case GameTitle.Title.MegaManBattleNetwork3White:
                case GameTitle.Title.MegaManBattleNetwork3Blue:
                    break;
                default:
                    break;
            }
        }

        private void PopulateStyles(List<Style> styles)
        {
            foreach(var style in styles)
            {
                var fullStyleName = $"{style.Name}{style.Type}";
                var styleSelect = new StyleSelect(fullStyleName);
                if(fullStyleName == "Normal") { styleSelect.EquipStyle = true; }
                styleSelect.EquipStyleChecked += (s, e) => EquipCheck(styleSelect);
                //Most likely will need to also add an AddStyleCheck since we won't allow users to add all styles for BN2
                flpStyleChange.Controls.Add(styleSelect);
            }
        }
        private void EquipCheck(StyleSelect styleSelect)
        {
            if (styleSelect.EquipStyle)
            {
                _currentEquipStyle = styleSelect.StyleName;
            }

            foreach (StyleSelect style in flpStyleChange.Controls)
            {
                if(style.StyleName != _currentEquipStyle)
                {
                    style.EquipStyle = false;
                }
            }
        }


    }
}
