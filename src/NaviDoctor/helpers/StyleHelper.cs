using NaviDoctor.extensions;
using NaviDoctor.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaviDoctor.helpers
{
    public static class StyleHelper
    {
        public static void LoadStyles(this SaveDataObject saveData, ref List<Style> _styles)
        {
            List<Style> _tempStyles;

            switch (saveData.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    {
                        _tempStyles = (Style.ResetStyleList(Style.BN1));

                        if (saveData.Style1 == 1)
                        {
                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Heat).Add = true;
                        }
                        if (saveData.Style2 == 1)
                        {
                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Aqua).Add = true;
                        }
                        if (saveData.Style3 == 1)
                        {
                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Wood).Add = true;
                        }

                        if (saveData.EqStyle == 02)
                        {
                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Heat).Equip = true;
                        }
                        else if (saveData.EqStyle == 03)
                        {
                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Aqua).Equip = true;
                        }
                        else if (saveData.EqStyle == 04)
                        {
                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Wood).Equip = true;
                        }
                        else
                        {
                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Normal).Equip = true;
                        }

                        _styles = _tempStyles;
                        break;
                    }
                case GameTitle.Title.MegaManBattleNetwork2:
                    {
                        _tempStyles = (Style.ResetStyleList(Style.BN2));
                        var index = 0;

                        foreach (var style in saveData.StyleTypes)
                        {
                            var hex = Convert.ToString(style, 16).ToUpper();
                            switch (hex)
                            {
                                case "190": //Normal
                                    break;
                                case "196": //ElecGuts
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecGuts).Add = true;
                                    switch (index)
                                    {
                                        case 1:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecGuts).Version = saveData.Style1;
                                            break;
                                        case 2:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecGuts).Version = saveData.Style2;
                                            break;
                                    }
                                    break;
                                case "197": //HeatGuts
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatGuts).Add = true;
                                    switch (index)
                                    {
                                        case 1:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatGuts).Version = saveData.Style1;
                                            break;
                                        case 2:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatGuts).Version = saveData.Style2;
                                            break;
                                    }
                                    break;
                                case "198": //AquaGuts
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaGuts).Add = true;
                                    switch (index)
                                    {
                                        case 1:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaGuts).Version = saveData.Style1;
                                            break;
                                        case 2:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaGuts).Version = saveData.Style2;
                                            break;
                                    }
                                    break;
                                case "199": //WoodGuts
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodGuts).Add = true;
                                    switch (index)
                                    {
                                        case 1:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodGuts).Version = saveData.Style1;
                                            break;
                                        case 2:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodGuts).Version = saveData.Style2;
                                            break;
                                    }
                                    break;
                                case "19B": //ElecCust
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecCust).Add = true;
                                    switch (index)
                                    {
                                        case 1:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecCust).Version = saveData.Style1;
                                            break;
                                        case 2:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecCust).Version = saveData.Style2;
                                            break;
                                    }
                                    break;
                                case "19C": //HeatCust
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatCust).Add = true;
                                    switch (index)
                                    {
                                        case 1:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatCust).Version = saveData.Style1;
                                            break;
                                        case 2:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatCust).Version = saveData.Style2;
                                            break;
                                    }
                                    break;
                                case "19D": //AquaCust
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaCust).Add = true;
                                    switch (index)
                                    {
                                        case 1:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaCust).Version = saveData.Style1;
                                            break;
                                        case 2:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaCust).Version = saveData.Style2;
                                            break;
                                    }
                                    break;
                                case "19E": //WoodCust
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodCust).Add = true;
                                    switch (index)
                                    {
                                        case 1:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodCust).Version = saveData.Style1;
                                            break;
                                        case 2:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodCust).Version = saveData.Style2;
                                            break;
                                    }
                                    break;
                                case "1A0": //ElecTeam
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecTeam).Add = true;
                                    switch (index)
                                    {
                                        case 1:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecTeam).Version = saveData.Style1;
                                            break;
                                        case 2:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecTeam).Version = saveData.Style2;
                                            break;
                                    }
                                    break;
                                case "1A1": //HeatTeam
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatTeam).Add = true;
                                    switch (index)
                                    {
                                        case 1:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatTeam).Version = saveData.Style1;
                                            break;
                                        case 2:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatTeam).Version = saveData.Style2;
                                            break;
                                    }
                                    break;
                                case "1A2": //AquaTeam
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaTeam).Add = true;
                                    switch (index)
                                    {
                                        case 1:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaTeam).Version = saveData.Style1;
                                            break;
                                        case 2:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaTeam).Version = saveData.Style2;
                                            break;
                                    }
                                    break;
                                case "1A3": //WoodTeam
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodTeam).Add = true;
                                    switch (index)
                                    {
                                        case 1:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodTeam).Version = saveData.Style1;
                                            break;
                                        case 2:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodTeam).Version = saveData.Style2;
                                            break;
                                    }
                                    break;
                                case "1A5": //ElecShld
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Add = true;
                                    switch (index)
                                    {
                                        case 1:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Version = saveData.Style1;
                                            break;
                                        case 2:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Version = saveData.Style2;
                                            break;
                                    }
                                    break;
                                case "1A6": //HeatShld
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatShield).Add = true;
                                    switch (index)
                                    {
                                        case 1:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatShield).Version = saveData.Style1;
                                            break;
                                        case 2:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatShield).Version = saveData.Style2;
                                            break;
                                    }
                                    break;
                                case "1A7": //AquaShld
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Add = true;
                                    switch (index)
                                    {
                                        case 1:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Version = saveData.Style1;
                                            break;
                                        case 2:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Version = saveData.Style2;
                                            break;
                                    }
                                    break;
                                case "1A8": //WoodShld
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodShield).Add = true;
                                    switch (index)
                                    {
                                        case 1:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodShield).Version = saveData.Style1;
                                            break;
                                        case 2:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodShield).Version = saveData.Style2;
                                            break;
                                    }
                                    break;
                                case "1A9": //Hub
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Hub).Add = true;
                                    switch (index)
                                    {
                                        case 1:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Hub).Version = saveData.Style1;
                                            break;
                                        case 2:
                                            _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Hub).Version = saveData.Style2;
                                            break;
                                    }
                                    break;
                            }
                            index++;
                        }

                        var equipHex = Convert.ToString(saveData.EqStyle, 16).ToUpper();

                        switch (equipHex)
                        {
                            case "00": // Normal Style
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Normal).Equip = true;
                                    break;
                                }
                            case "09": // Elec Guts V1
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecGuts).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecGuts).Version = 1;
                                    break;
                                }
                            case "0A": // Heat Guts V1
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatGuts).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatGuts).Version = 1;
                                    break;
                                }
                            case "0B": // Aqua Guts V1
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaGuts).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaGuts).Version = 1;
                                    break;
                                }
                            case "0C": // Wood Guts V1
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodGuts).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodGuts).Version = 1;
                                    break;
                                }
                            case "11": // Elec Custom V1
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecCust).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecCust).Version = 1;
                                    break;
                                }
                            case "12": // Fire Custom V1
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatCust).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatCust).Version = 1;
                                    break;
                                }
                            case "13": // Aqua Custom V1
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaCust).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaCust).Version = 1;
                                    break;
                                }
                            case "14": // Wood Custom V1
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodCust).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodCust).Version = 1;
                                    break;
                                }
                            case "19": // Elec Team V1
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecTeam).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecTeam).Version = 1;
                                    break;
                                }
                            case "1A": // Fire Team V1
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatTeam).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatTeam).Version = 1;
                                    break;
                                }
                            case "1B": // Aqua Team V1
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaTeam).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaTeam).Version = 1;
                                    break;
                                }
                            case "1C": // Wood Team V1
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodTeam).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodTeam).Version = 1;
                                    break;
                                }
                            case "21": // Elec Shield V1
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Version = 1;
                                    break;
                                }
                            case "22": // Fire Shield V1
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatShield).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatShield).Version = 1;
                                    break;
                                }
                            case "23": // Aqua Shield V1
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Version = 1;
                                    break;
                                }
                            case "24": // Wood Shield V1
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodShield).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodShield).Version = 1;
                                    break;
                                }
                            case "28": // Hub Style
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Hub).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Hub).Version = 1;
                                    break;
                                }
                            case "40": // Normal Style V2
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Normal).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Normal).Version = 2;
                                    break;
                                }
                            case "49": // Elec Guts V2
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecGuts).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecGuts).Version = 2;
                                    break;
                                }
                            case "4A": // Heat Guts V2
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatGuts).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatGuts).Version = 2;
                                    break;
                                }
                            case "4B": // Aqua Guts V2
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaGuts).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaGuts).Version = 2;
                                    break;
                                }
                            case "4C": // Wood Guts V2
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodGuts).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodGuts).Version = 2;
                                    break;
                                }
                            case "51": // Elec Custom V2
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecCust).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecCust).Version = 2;
                                    break;
                                }
                            case "52": // Heat Custom V2
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatCust).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatCust).Version = 2;
                                    break;
                                }
                            case "53": // Aqua Custom V2
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaCust).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaCust).Version = 2;
                                    break;
                                }
                            case "54": // Wood Custom V2
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodCust).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodCust).Version = 2;
                                    break;
                                }
                            case "59": // Elec Team V2
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecTeam).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecTeam).Version = 2;
                                    break;
                                }
                            case "5A": // Heat Team V2
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatTeam).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatTeam).Version = 2;
                                    break;
                                }
                            case "5B": // Aqua Team V2
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaTeam).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaTeam).Version = 2;
                                    break;
                                }
                            case "5C": // Wood Team V2
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodTeam).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodTeam).Version = 2;
                                    break;
                                }
                            case "61": // Elec Shield V2
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Version = 2;
                                    break;
                                }
                            case "62": // Heat Shield V2
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatShield).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatShield).Version = 2;
                                    break;
                                }
                            case "63": // Aqua Shield V2
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Version = 2;
                                    break;
                                }
                            case "64": // Wood Shield V2
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodShield).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodShield).Version = 2;
                                    break;
                                }
                            case "68": // Hub Style V2
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Hub).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Hub).Version = 2;
                                    break;
                                }
                            case "80": // Normal Style V3
                            case "C0": // Normal Style V4
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Normal).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Normal).Version = 3;
                                    break;
                                }
                            case "C9": // Elec Guts V4
                            case "89": // Elec Guts V3
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecGuts).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecGuts).Version = 3;
                                    break;
                                }
                            case "CA": // Heat Guts V4
                            case "8A": // Heat Guts V3
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatGuts).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatGuts).Version = 3;
                                    break;
                                }
                            case "CB": // Aqua Guts V4
                            case "8B": // Aqua Guts V3
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaGuts).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaGuts).Version = 3;
                                    break;
                                }
                            case "CC": // Wood Guts V4
                            case "8C": // Wood Guts V3
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodGuts).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodGuts).Version = 3;
                                    break;
                                }
                            case "D1": // Elec Custom V4
                            case "91": // Elec Custom V3
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecCust).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecCust).Version = 3;
                                    break;
                                }
                            case "D2": // Heat Custom V4
                            case "92": // Heat Custom V3
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatCust).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatCust).Version = 3;
                                    break;
                                }
                            case "D3": // Aqua Custom V4
                            case "93": // Aqua Custom V3
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaCust).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaCust).Version = 3;
                                    break;
                                }
                            case "D4": // Wood Custom V4
                            case "94": // Wood Custom V3
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodCust).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodCust).Version = 3;
                                    break;
                                }
                            case "D9": // Elec Team V4
                            case "99": // Elec Team V3
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecTeam).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecTeam).Version = 3;
                                    break;
                                }
                            case "DA": // Heat Team V4
                            case "9A": // Heat Team V3
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatTeam).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatTeam).Version = 3;
                                    break;
                                }
                            case "DB": // Aqua Team V4
                            case "9B": // Aqua Team V3
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaTeam).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaTeam).Version = 3;
                                    break;
                                }
                            case "DC": // Wood Team V4
                            case "9C": // Wood Team V3
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodTeam).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodTeam).Version = 3;
                                    break;
                                }
                            case "E1": // Elec Shield V4
                            case "A1": // Elec Shield V3
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Version = 3;
                                    break;
                                }
                            case "E2": // Heat Shield V4
                            case "A2": // Heat Shield V3
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatShield).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatShield).Version = 3;
                                    break;
                                }
                            case "E3": // Aqua Shield V4
                            case "A3": // Aqua Shield V3
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Version = 3;
                                    break;
                                }
                            case "E4": // Wood Shield V4
                            case "A4": // Wood Shield V3
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodShield).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodShield).Version = 3;
                                    break;
                                }
                            case "E8": // Hub Style V4
                            case "A8": // Hub Style V3
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Hub).Equip = true;
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Hub).Version = 3;
                                    break;
                                }
                            default: //default to normal
                                {
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.Normal).Equip = true;
                                    break;
                                }
                        }

                        _styles = _tempStyles;
                        break;
                    }
                case GameTitle.Title.MegaManBattleNetwork3Blue: //Style1 is the Style and Style2 is the Level
                case GameTitle.Title.MegaManBattleNetwork3White:
                    {
                        _tempStyles = (Style.ResetStyleList(Style.BN3));
                        switch (saveData.EqStyle.ToString())
                        {
                            case "0": //Normal
                                break;
                            case "9": //ElecGuts
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecGuts).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecGuts).Version = saveData.Style2 + 1;
                                break;
                            case "10": //HeatGuts
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatGuts).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatGuts).Version = saveData.Style2 + 1;
                                break;
                            case "11": //AquaGuts
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaGuts).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaGuts).Version = saveData.Style2 + 1;
                                break;
                            case "12": //WoodGuts
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodGuts).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodGuts).Version = saveData.Style2 + 1;
                                break;
                            case "17": //ElecCust
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecCust).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecCust).Version = saveData.Style2 + 1;
                                break;
                            case "18": //HeatCust
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatCust).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatCust).Version = saveData.Style2 + 1;
                                break;
                            case "19": //AquaCust
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaCust).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaCust).Version = saveData.Style2 + 1;
                                break;
                            case "20": //WoodCust
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodCust).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodCust).Version = saveData.Style2 + 1;
                                break;
                            case "25": //ElecTeam
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecTeam).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecTeam).Version = saveData.Style2 + 1;
                                break;
                            case "26": //HeatTeam
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatTeam).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatTeam).Version = saveData.Style2 + 1;
                                break;
                            case "27": //AquaTeam
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaTeam).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaTeam).Version = saveData.Style2 + 1;
                                break;
                            case "28": //WoodTeam
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodTeam).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodTeam).Version = saveData.Style2 + 1;
                                break;
                            case "33": //ElecShld
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Version = saveData.Style2 + 1;
                                break;
                            case "34": //HeatShld
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatShield).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatShield).Version = saveData.Style2 + 1;
                                break;
                            case "35": //AquaShld
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Version = saveData.Style2 + 1;
                                break;
                            case "36": //WoodShld
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodShield).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodShield).Version = saveData.Style2 + 1;
                                break;
                            case "41": //ElecGround
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecGround).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecGround).Version = saveData.Style2 + 1;
                                break;
                            case "42": //HeatGround
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatGround).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatGround).Version = saveData.Style2 + 1;
                                break;
                            case "43": //AquaGround
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaGround).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaGround).Version = saveData.Style2 + 1;
                                break;
                            case "44": //WoodGround
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodGround).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodGround).Version = saveData.Style2 + 1;
                                break;
                            case "49": //ElecShdw
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecShadow).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecShadow).Version = saveData.Style2 + 1;
                                break;
                            case "50": //HeatShdw
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatShadow).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatShadow).Version = saveData.Style2 + 1;
                                break;
                            case "51": //AquaShdw
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaShadow).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaShadow).Version = saveData.Style2 + 1;
                                break;
                            case "52": //WoodShdw
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodShadow).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodShadow).Version = saveData.Style2 + 1;
                                break;
                            case "57": //ElecBug
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecBug).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecBug).Version = saveData.Style2 + 1;
                                break;
                            case "58": //HeatBug
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatBug).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatBug).Version = saveData.Style2 + 1;
                                break;
                            case "59": //AquaBug
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaBug).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaBug).Version = saveData.Style2 + 1;
                                break;
                            case "60": //WoodBug
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodBug).Equip = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodBug).Version = saveData.Style2 + 1;
                                break;
                        }

                        switch (saveData.Style1.ToString())
                        {
                            case "0": //Normal
                                break;
                            case "9": //ElecGuts
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecGuts).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecGuts).Version = saveData.Style2 + 1;
                                break;
                            case "10": //HeatGuts
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatGuts).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatGuts).Version = saveData.Style2 + 1;
                                break;
                            case "11": //AquaGuts
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaGuts).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaGuts).Version = saveData.Style2 + 1;
                                break;
                            case "12": //WoodGuts
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodGuts).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodGuts).Version = saveData.Style2 + 1;
                                break;
                            case "17": //ElecCust
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecCust).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecCust).Version = saveData.Style2 + 1;
                                break;
                            case "18": //HeatCust
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatCust).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatCust).Version = saveData.Style2 + 1;
                                break;
                            case "19": //AquaCust
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaCust).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaCust).Version = saveData.Style2 + 1;
                                break;
                            case "20": //WoodCust
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodCust).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodCust).Version = saveData.Style2 + 1;
                                break;
                            case "25": //ElecTeam
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecTeam).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecTeam).Version = saveData.Style2 + 1;
                                break;
                            case "26": //HeatTeam
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatTeam).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatTeam).Version = saveData.Style2 + 1;
                                break;
                            case "27": //AquaTeam
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaTeam).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaTeam).Version = saveData.Style2 + 1;
                                break;
                            case "28": //WoodTeam
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodTeam).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodTeam).Version = saveData.Style2 + 1;
                                break;
                            case "33": //ElecShld
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Version = saveData.Style2 + 1;
                                break;
                            case "34": //HeatShld
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatShield).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatShield).Version = saveData.Style2 + 1;
                                break;
                            case "35": //AquaShld
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Version = saveData.Style2 + 1;
                                break;
                            case "36": //WoodShld
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodShield).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodShield).Version = saveData.Style2 + 1;
                                break;
                            case "41": //ElecGround
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecGround).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecGround).Version = saveData.Style2 + 1;
                                break;
                            case "42": //HeatGround
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatGround).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatGround).Version = saveData.Style2 + 1;
                                break;
                            case "43": //AquaGround
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaGround).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaGround).Version = saveData.Style2 + 1;
                                break;
                            case "44": //WoodGround
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodGround).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodGround).Version = saveData.Style2 + 1;
                                break;
                            case "49": //ElecShdw
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecShadow).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecShadow).Version = saveData.Style2 + 1;
                                break;
                            case "50": //HeatShdw
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatShadow).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatShadow).Version = saveData.Style2 + 1;
                                break;
                            case "51": //AquaShdw
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaShadow).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaShadow).Version = saveData.Style2 + 1;
                                break;
                            case "52": //WoodShdw
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodShadow).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodShadow).Version = saveData.Style2 + 1;
                                break;
                            case "57": //ElecBug
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecBug).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecBug).Version = saveData.Style2 + 1;
                                break;
                            case "58": //HeatBug
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatBug).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.HeatBug).Version = saveData.Style2 + 1;
                                break;
                            case "59": //AquaBug
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaBug).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.AquaBug).Version = saveData.Style2 + 1;
                                break;
                            case "60": //WoodBug
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodBug).Add = true;
                                _tempStyles.FirstOrDefault(x => x.Name == Style.Value.WoodBug).Version = saveData.Style2 + 1;
                                break;
                        }
                        _styles = _tempStyles;
                        break;
                    }
                default:
                    break;
            }
        }

        public static void UpdateStyles(this SaveDataObject saveData, ref List<Style> _styles)
        {
            switch (saveData.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    {
                        foreach (var style in _styles)
                        {
                            switch (style.Name)
                            {
                                case Style.Value.Normal:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 0;
                                        }
                                        break;
                                    }
                                case Style.Value.Heat:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 2;
                                        }

                                        saveData.Style1 = style.Add.ToByte();
                                        break;
                                    }
                                case Style.Value.Aqua:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 3;
                                        }

                                        saveData.Style2 = style.Add.ToByte();
                                        break;
                                    }
                                case Style.Value.Wood:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 4;
                                        }

                                        saveData.Style3 = style.Add.ToByte();
                                        break;
                                    }
                                default:
                                    break;

                            }
                        }
                        break;
                    }
                case GameTitle.Title.MegaManBattleNetwork2:
                    {
                        saveData.StyleTypes = new List<int>(); //resetting the list
                        saveData.StyleTypes.Add(Convert.ToInt32("190", 16)); //Add Normal back into the list
                        var index = 1;
                        foreach (var style in _styles)
                        {
                            switch (style.Name)
                            {
                                case Style.Value.Normal:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = Convert.ToByte("00", 16);
                                        }
                                        break;
                                    }
                                case Style.Value.AquaGuts:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            switch (style.Version.GetValueOrDefault(1))
                                            {
                                                case 1:
                                                    saveData.EqStyle = Convert.ToByte("0B", 16);
                                                    break;
                                                case 2:
                                                    saveData.EqStyle = Convert.ToByte("4B", 16);
                                                    break;
                                                case 3:
                                                    saveData.EqStyle = Convert.ToByte("8B", 16);
                                                    break;
                                            }
                                        }
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.StyleTypes.Add(Convert.ToInt32("198", 16));
                                            switch (index)
                                            {
                                                case 1:
                                                    saveData.Style1 = (byte)style.Version.GetValueOrDefault(1);
                                                    index++;
                                                    break;
                                                case 2:
                                                    saveData.Style2 = (byte)style.Version.GetValueOrDefault(1);
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case Style.Value.WoodGuts:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            switch (style.Version.GetValueOrDefault(1))
                                            {
                                                case 1:
                                                    saveData.EqStyle = Convert.ToByte("0C", 16);
                                                    break;
                                                case 2:
                                                    saveData.EqStyle = Convert.ToByte("4C", 16);
                                                    break;
                                                case 3:
                                                    saveData.EqStyle = Convert.ToByte("8C", 16);
                                                    break;
                                            }
                                        }
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.StyleTypes.Add(Convert.ToInt32("199", 16));
                                            switch (index)
                                            {
                                                case 1:
                                                    saveData.Style1 = (byte)style.Version.GetValueOrDefault(1);
                                                    index++;
                                                    break;
                                                case 2:
                                                    saveData.Style2 = (byte)style.Version.GetValueOrDefault(1);
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case Style.Value.HeatGuts:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            switch (style.Version.GetValueOrDefault(1))
                                            {
                                                case 1:
                                                    saveData.EqStyle = Convert.ToByte("0A", 16);
                                                    break;
                                                case 2:
                                                    saveData.EqStyle = Convert.ToByte("4A", 16);
                                                    break;
                                                case 3:
                                                    saveData.EqStyle = Convert.ToByte("8A", 16);
                                                    break;
                                            }
                                        }
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.StyleTypes.Add(Convert.ToInt32("197", 16));
                                            switch (index)
                                            {
                                                case 1:
                                                    saveData.Style1 = (byte)style.Version.GetValueOrDefault(1);
                                                    index++;
                                                    break;
                                                case 2:
                                                    saveData.Style2 = (byte)style.Version.GetValueOrDefault(1);
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case Style.Value.ElecGuts:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            switch (style.Version.GetValueOrDefault(1))
                                            {
                                                case 1:
                                                    saveData.EqStyle = Convert.ToByte("09", 16);
                                                    break;
                                                case 2:
                                                    saveData.EqStyle = Convert.ToByte("49", 16);
                                                    break;
                                                case 3:
                                                    saveData.EqStyle = Convert.ToByte("89", 16);
                                                    break;
                                            }
                                        }
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.StyleTypes.Add(Convert.ToInt32("196", 16));
                                            switch (index)
                                            {
                                                case 1:
                                                    saveData.Style1 = (byte)style.Version.GetValueOrDefault(1);
                                                    index++;
                                                    break;
                                                case 2:
                                                    saveData.Style2 = (byte)style.Version.GetValueOrDefault(1);
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case Style.Value.AquaCust:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            switch (style.Version.GetValueOrDefault(1))
                                            {
                                                case 1:
                                                    saveData.EqStyle = Convert.ToByte("13", 16);
                                                    break;
                                                case 2:
                                                    saveData.EqStyle = Convert.ToByte("53", 16);
                                                    break;
                                                case 3:
                                                    saveData.EqStyle = Convert.ToByte("93", 16);
                                                    break;
                                            }
                                        }
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.StyleTypes.Add(Convert.ToInt32("19D", 16));
                                            switch (index)
                                            {
                                                case 1:
                                                    saveData.Style1 = (byte)style.Version.GetValueOrDefault(1);
                                                    index++;
                                                    break;
                                                case 2:
                                                    saveData.Style2 = (byte)style.Version.GetValueOrDefault(1);
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case Style.Value.WoodCust:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            switch (style.Version.GetValueOrDefault(1))
                                            {
                                                case 1:
                                                    saveData.EqStyle = Convert.ToByte("14", 16);
                                                    break;
                                                case 2:
                                                    saveData.EqStyle = Convert.ToByte("54", 16);
                                                    break;
                                                case 3:
                                                    saveData.EqStyle = Convert.ToByte("94", 16);
                                                    break;
                                            }
                                        }
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.StyleTypes.Add(Convert.ToInt32("19E", 16));
                                            switch (index)
                                            {
                                                case 1:
                                                    saveData.Style1 = (byte)style.Version.GetValueOrDefault(1);
                                                    index++;
                                                    break;
                                                case 2:
                                                    saveData.Style2 = (byte)style.Version.GetValueOrDefault(1);
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case Style.Value.HeatCust:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            switch (style.Version.GetValueOrDefault(1))
                                            {
                                                case 1:
                                                    saveData.EqStyle = Convert.ToByte("12", 16);
                                                    break;
                                                case 2:
                                                    saveData.EqStyle = Convert.ToByte("52", 16);
                                                    break;
                                                case 3:
                                                    saveData.EqStyle = Convert.ToByte("92", 16);
                                                    break;
                                            }
                                        }
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.StyleTypes.Add(Convert.ToInt32("19C", 16));
                                            switch (index)
                                            {
                                                case 1:
                                                    saveData.Style1 = (byte)style.Version.GetValueOrDefault(1);
                                                    index++;
                                                    break;
                                                case 2:
                                                    saveData.Style2 = (byte)style.Version.GetValueOrDefault(1);
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case Style.Value.ElecCust:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            switch (style.Version.GetValueOrDefault(1))
                                            {
                                                case 1:
                                                    saveData.EqStyle = Convert.ToByte("11", 16);
                                                    break;
                                                case 2:
                                                    saveData.EqStyle = Convert.ToByte("51", 16);
                                                    break;
                                                case 3:
                                                    saveData.EqStyle = Convert.ToByte("91", 16);
                                                    break;
                                            }
                                        }
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.StyleTypes.Add(Convert.ToInt32("19B", 16));
                                            switch (index)
                                            {
                                                case 1:
                                                    saveData.Style1 = (byte)style.Version.GetValueOrDefault(1);
                                                    index++;
                                                    break;
                                                case 2:
                                                    saveData.Style2 = (byte)style.Version.GetValueOrDefault(1);
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case Style.Value.AquaTeam:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            switch (style.Version.GetValueOrDefault(1))
                                            {
                                                case 1:
                                                    saveData.EqStyle = Convert.ToByte("1B", 16);
                                                    break;
                                                case 2:
                                                    saveData.EqStyle = Convert.ToByte("5B", 16);
                                                    break;
                                                case 3:
                                                    saveData.EqStyle = Convert.ToByte("9B", 16);
                                                    break;
                                            }
                                        }
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.StyleTypes.Add(Convert.ToInt32("1A2", 16));
                                            switch (index)
                                            {
                                                case 1:
                                                    saveData.Style1 = (byte)style.Version.GetValueOrDefault(1);
                                                    index++;
                                                    break;
                                                case 2:
                                                    saveData.Style2 = (byte)style.Version.GetValueOrDefault(1);
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case Style.Value.WoodTeam:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            switch (style.Version.GetValueOrDefault(1))
                                            {
                                                case 1:
                                                    saveData.EqStyle = Convert.ToByte("1C", 16);
                                                    break;
                                                case 2:
                                                    saveData.EqStyle = Convert.ToByte("5C", 16);
                                                    break;
                                                case 3:
                                                    saveData.EqStyle = Convert.ToByte("9C", 16);
                                                    break;
                                            }
                                        }
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.StyleTypes.Add(Convert.ToInt32("1A3", 16));
                                            switch (index)
                                            {
                                                case 1:
                                                    saveData.Style1 = (byte)style.Version.GetValueOrDefault(1);
                                                    index++;
                                                    break;
                                                case 2:
                                                    saveData.Style2 = (byte)style.Version.GetValueOrDefault(1);
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case Style.Value.HeatTeam:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            switch (style.Version.GetValueOrDefault(1))
                                            {
                                                case 1:
                                                    saveData.EqStyle = Convert.ToByte("1A", 16);
                                                    break;
                                                case 2:
                                                    saveData.EqStyle = Convert.ToByte("5A", 16);
                                                    break;
                                                case 3:
                                                    saveData.EqStyle = Convert.ToByte("9A", 16);
                                                    break;
                                            }
                                        }
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.StyleTypes.Add(Convert.ToInt32("1A1", 16));
                                            switch (index)
                                            {
                                                case 1:
                                                    saveData.Style1 = (byte)style.Version.GetValueOrDefault(1);
                                                    index++;
                                                    break;
                                                case 2:
                                                    saveData.Style2 = (byte)style.Version.GetValueOrDefault(1);
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case Style.Value.ElecTeam:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            switch (style.Version.GetValueOrDefault(1))
                                            {
                                                case 1:
                                                    saveData.EqStyle = Convert.ToByte("19", 16);
                                                    break;
                                                case 2:
                                                    saveData.EqStyle = Convert.ToByte("59", 16);
                                                    break;
                                                case 3:
                                                    saveData.EqStyle = Convert.ToByte("99", 16);
                                                    break;
                                            }
                                        }
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.StyleTypes.Add(Convert.ToInt32("1A0", 16));
                                            switch (index)
                                            {
                                                case 1:
                                                    saveData.Style1 = (byte)style.Version.GetValueOrDefault(1);
                                                    index++;
                                                    break;
                                                case 2:
                                                    saveData.Style2 = (byte)style.Version.GetValueOrDefault(1);
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case Style.Value.AquaShield:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            switch (style.Version.GetValueOrDefault(1))
                                            {
                                                case 1:
                                                    saveData.EqStyle = Convert.ToByte("23", 16);
                                                    break;
                                                case 2:
                                                    saveData.EqStyle = Convert.ToByte("63", 16);
                                                    break;
                                                case 3:
                                                    saveData.EqStyle = Convert.ToByte("A3", 16);
                                                    break;
                                            }
                                        }
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.StyleTypes.Add(Convert.ToInt32("1A7", 16));
                                            switch (index)
                                            {
                                                case 1:
                                                    saveData.Style1 = (byte)style.Version.GetValueOrDefault(1);
                                                    index++;
                                                    break;
                                                case 2:
                                                    saveData.Style2 = (byte)style.Version.GetValueOrDefault(1);
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case Style.Value.WoodShield:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            switch (style.Version.GetValueOrDefault(1))
                                            {
                                                case 1:
                                                    saveData.EqStyle = Convert.ToByte("24", 16);
                                                    break;
                                                case 2:
                                                    saveData.EqStyle = Convert.ToByte("64", 16);
                                                    break;
                                                case 3:
                                                    saveData.EqStyle = Convert.ToByte("A4", 16);
                                                    break;
                                            }
                                        }
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.StyleTypes.Add(Convert.ToInt32("1A8", 16));
                                            switch (index)
                                            {
                                                case 1:
                                                    saveData.Style1 = (byte)style.Version.GetValueOrDefault(1);
                                                    index++;
                                                    break;
                                                case 2:
                                                    saveData.Style2 = (byte)style.Version.GetValueOrDefault(1);
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case Style.Value.HeatShield:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            switch (style.Version.GetValueOrDefault(1))
                                            {
                                                case 1:
                                                    saveData.EqStyle = Convert.ToByte("22", 16);
                                                    break;
                                                case 2:
                                                    saveData.EqStyle = Convert.ToByte("62", 16);
                                                    break;
                                                case 3:
                                                    saveData.EqStyle = Convert.ToByte("A2", 16);
                                                    break;
                                            }
                                        }
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.StyleTypes.Add(Convert.ToInt32("1A6", 16));
                                            switch (index)
                                            {
                                                case 1:
                                                    saveData.Style1 = (byte)style.Version.GetValueOrDefault(1);
                                                    index++;
                                                    break;
                                                case 2:
                                                    saveData.Style2 = (byte)style.Version.GetValueOrDefault(1);
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case Style.Value.ElecShield:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            switch (style.Version.GetValueOrDefault(1))
                                            {
                                                case 1:
                                                    saveData.EqStyle = Convert.ToByte("21", 16);
                                                    break;
                                                case 2:
                                                    saveData.EqStyle = Convert.ToByte("61", 16);
                                                    break;
                                                case 3:
                                                    saveData.EqStyle = Convert.ToByte("A1", 16);
                                                    break;
                                            }
                                        }
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.StyleTypes.Add(Convert.ToInt32("1A5", 16));
                                            switch (index)
                                            {
                                                case 1:
                                                    saveData.Style1 = (byte)style.Version.GetValueOrDefault(1);
                                                    index++;
                                                    break;
                                                case 2:
                                                    saveData.Style2 = (byte)style.Version.GetValueOrDefault(1);
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case Style.Value.Hub:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            switch (style.Version.GetValueOrDefault(1))
                                            {
                                                case 1:
                                                    saveData.EqStyle = Convert.ToByte("28", 16);
                                                    break;
                                                case 2:
                                                    saveData.EqStyle = Convert.ToByte("68", 16);
                                                    break;
                                                case 3:
                                                    saveData.EqStyle = Convert.ToByte("A8", 16);
                                                    break;
                                            }
                                        }
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.StyleTypes.Add(Convert.ToInt32("1A9", 16));
                                            switch (index)
                                            {
                                                case 1:
                                                    saveData.Style1 = (byte)style.Version.GetValueOrDefault(1);
                                                    index++;
                                                    break;
                                                case 2:
                                                    saveData.Style2 = (byte)style.Version.GetValueOrDefault(1);
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                default:
                                    break;
                            }
                        }
                        break;
                    }
                case GameTitle.Title.MegaManBattleNetwork3Blue:
                case GameTitle.Title.MegaManBattleNetwork3White:
                    {
                        foreach (var style in _styles)
                        {
                            switch (style.Name)
                            {
                                case Style.Value.Normal:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 0;
                                        }
                                        break;
                                    }
                                case Style.Value.AquaGuts:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 11;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 11;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.WoodGuts:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 12;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 12;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.HeatGuts:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 10;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 10;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.ElecGuts:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 9;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 9;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.AquaCust:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 19;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 19;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.WoodCust:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 20;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 20;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.HeatCust:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 18;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 18;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { continue; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.ElecCust:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 17;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 17;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.AquaTeam:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 27;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 27;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.WoodTeam:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 28;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 28;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.HeatTeam:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 26;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 26;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.ElecTeam:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 25;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 25;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.AquaShield:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 35;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 35;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.WoodShield:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 36;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 36;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.HeatShield:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 34;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 34;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.ElecShield:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 33;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 33;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.AquaGround:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 43;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 43;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.WoodGround:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 44;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 44;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.HeatGround:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 42;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 42;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.ElecGround:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 41;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 41;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.AquaShadow:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 51;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 51;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.WoodShadow:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 52;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 52;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.HeatShadow:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 50;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 50;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.ElecShadow:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 49;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 49;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.AquaBug:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 59;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 59;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.WoodBug:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 60;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 60;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.HeatBug:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 58;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 58;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                case Style.Value.ElecBug:
                                    {
                                        if (style.Add.GetValueOrDefault(false))
                                        {
                                            saveData.Style1 = 57;
                                        }
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = 57;
                                        }

                                        if (!style.Add.GetValueOrDefault(false) && !style.Equip.GetValueOrDefault(false)) { break; }

                                        switch (style.Version.GetValueOrDefault(1))
                                        {
                                            case 1:
                                                saveData.Style2 = 0;
                                                break;
                                            case 2:
                                                saveData.Style2 = 1;
                                                break;
                                            case 3:
                                                saveData.Style2 = 2;
                                                break;
                                        }
                                        break;
                                    }
                                default:
                                    break;

                            }
                        }
                        break;
                    }
                default: break;
            }
        }

    }
}
