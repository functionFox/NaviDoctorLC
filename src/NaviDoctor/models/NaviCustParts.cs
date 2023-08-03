using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaviDoctor.models
{
    class NaviCustParts
    {
        public List<NCPListing> ncpList = new List<NCPListing>();
        
        public List<NCPListing> BN3NCPMap()
            // bool canCompress = ncpList[1].ncpData.ContainsKey(true); // example of querying if the NCP can be compressed.
            // int[,] ncpShape = ncpList[1].ncpData.FirstOrDefault(e => e.Key == true).Value;  
            // Example of how to get the grid shape of ID 1's (SprArmor's) compressed version.
            // string findName = ncpList[1].ncpName; // Getting the name is easy.
            // int findId = ncpList.IndexOf(ncpList.FirstOrDefault( e => e.ncpName=="SprArmor" )); // Finding the ID is a little harder
            // string partColor = ncpList[1].ncpColors[3]; // Finding the color isn't too bad.
        {
            AddPart("None", new List<string> { "None", "None", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    { 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 }
                }
            }); // Basically a template
            AddPart("SprArmor", new List<string> { "None", "None", "None", "Red" }, new Dictionary<bool, int[,]>() 
            { 
                [false] = new int[,]
                {
                    { 0, 0, 0, 0, 0 },
                    { 0, 0, 1, 0, 0 },
                    { 0, 0, 1, 1, 0 },
                    { 0, 0, 1, 1, 0 },
                    { 0, 0, 0, 0, 0 }
                },
                [true] = new int[,]
                {
                    { 0, 0, 0, 0, 0 },
                    { 0, 0, 1, 0, 0 },
                    { 0, 0, 1, 1, 0 },
                    { 0, 0, 1, 0, 0 },
                    { 0, 0, 0, 0, 0 }
                }
            });
            AddPart("BrakBust", new List<string> { "None", "None", "None", "Red" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {1, 1, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {1, 1, 1, 1, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("BrakChrg", new List<string> { "Orange", "None", "None", "Red" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 1, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("SetGreen", new List<string> { "None", "None", "None", "Green" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 1, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("SetIce", new List<string> { "None", "None", "None", "Green" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 1, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("SetLava", new List<string> { "None", "None", "None", "Green" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 1, 1, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 1, 1, 0},
                    {1, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 1, 1, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("SetSand", new List<string> { "None", "None", "None", "Green" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 1, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("SetMetal", new List<string> { "None", "None", "None", "Green" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 1, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("SetHoly", new List<string> { "None", "None", "None", "Green" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 1, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 1, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 1, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("Custom1", new List<string> { "None", "None", "Yellow", "Blue" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 0, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("Custom2", new List<string> { "None", "None", "None", "Blue" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 1, 0},
                    {0, 0, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("MegFldr1", new List<string> { "None", "Pink", "None", "Green" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("MegFldr2", new List<string> { "None", "None", "None", "Green" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 1, 1, 1, 1},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("Block", new List<string> { "None", "None", "None", "Blue" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("Shield", new List<string> { "None", "None", "None", "Blue" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("Reflect", new List<string> { "None", "None", "None", "Blue" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 0, 0, 0},
                    {0, 1, 0, 0, 0},
                    {0, 1, 1, 1, 1},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 0, 0, 0},
                    {0, 1, 0, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("ShdwShoe", new List<string> { "None", "None", "None", "Red" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("FlotShoe", new List<string> { "None", "None", "None", "Red" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {1, 1, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {1, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("AntiDmg", new List<string> { "None", "None", "None", "Red" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 1, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 1, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("Press", new List<string> { "White", "None", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,] // Even though there's compressed mapping, I'm not going to add it.
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("EngyChng", new List<string> { "White", "None", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("Alpha", new List<string> { "None", "Pink", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("SneakRun", new List<string> { "None", "None", "Yellow", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("OilBody", new List<string> { "None", "None", "Yellow", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("Fish", new List<string> { "None", "Pink", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("Battery", new List<string> { "None", "None", "Yellow", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("Jungle", new List<string> { "White", "None", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("Collect", new List<string> { "None", "Pink", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 1, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("Airshoes", new List<string> { "White", "None", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 0, 1, 0},
                    {0, 1, 0, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 0, 0, 0},
                    {0, 1, 0, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("UnderSht", new List<string> { "White", "None", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("FstGauge", new List<string> { "None", "Pink", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 1, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 1, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 1, 0, 0}
                }
            });
            AddPart("Rush", new List<string> { "None", "None", "Yellow", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("Beat", new List<string> { "White", "None", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 0, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("Tango", new List<string> { "None", "Pink", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 1, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 1, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("WeapLv+1", new List<string> { "White", "Pink", "Yellow", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            }, false);
            AddPart("HP+100", new List<string> { "White", "Pink", "Yellow", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 1, 0},
                    {0, 1, 1, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            }, false);
            AddPart("HP+200", new List<string> { "White", "Pink", "Yellow", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            }, false);
            AddPart("HP+300", new List<string> { "White", "Pink", "Yellow", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            }, false);
            AddPart("HP+500", new List<string> { "White", "Pink", "Yellow", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {1, 1, 1, 1, 1},
                    {1, 0, 1, 1, 1},
                    {0, 0, 0, 0, 0}
                }
            }, false);
            AddPart("Reg+5", new List<string> { "White", "Pink", "Yellow", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            }, false);
            AddPart("Atk+1", new List<string> { "White", "Pink", "Yellow", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            }, false);
            AddPart("Speed+1", new List<string> { "White", "Pink", "Yellow", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            }, false);
            AddPart("Charge+1", new List<string> { "White", "Pink", "Yellow", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            }, false);
            AddPart("BugStop", new List<string> { "White", "None", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 1, 0, 0, 0},
                    {0, 1, 0, 0, 0},
                    {0, 1, 0, 0, 0},
                    {0, 1, 1, 1, 1},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 1, 0, 0, 0},
                    {0, 1, 0, 0, 0},
                    {0, 1, 0, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("Humor", new List<string> { "None", "Pink", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("BlckMind", new List<string> { "White", "None", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("BustrMAX", new List<string> { "None", "Pink", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 1, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("GigFldr1", new List<string> { "Purple", "None", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 1, 1, 1, 1},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("HubBatc", new List<string> { "Orange", "None", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 0, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            AddPart("DarkLcns", new List<string> { "Dark", "None", "None", "None" }, new Dictionary<bool, int[,]>()
            {
                [false] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 1, 1, 1, 0},
                    {0, 0, 0, 1, 0},
                    {0, 0, 0, 0, 0}
                },
                [true] = new int[,]
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 0, 1, 0},
                    {0, 0, 0, 0, 0}
                }
            });
            return ncpList;
        }
        public void AddPart(string name, List<string> colors, Dictionary<bool, int[,]> data, bool isProg = true)
        {
            ncpList.Add(new NCPListing()
            {
                ncpName = name,
                ncpColors = colors,
                ncpData = data,
                isProg = isProg // Set to true by default, only plus parts need to specify false
            });
        }
    }
    public class NCPListing
    {
        public string ncpName { get; set; }
        public List<string> ncpColors { get; set; }
        public Dictionary<bool, int[,]> ncpData { get; set; } = new Dictionary<bool, int[,]>();
        public int QuantityCol1 { get; set; } = 0;
        public int QuantityCol2 { get; set; } = 0;
        public int QuantityCol3 { get; set; } = 0;
        public int QuantityCol4 { get; set; } = 0;
        public bool isCompressed { get; set; } = false;
        public bool isProg { get; set; }
    }
}
