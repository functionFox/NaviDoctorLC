# NaviDoctorLC
Mega Man Battle Network Legacy Collection save editor

![Github license](https://img.shields.io/github/license/functionFox/NaviDoctorLC?style=plastic)
![GitHub issues](https://img.shields.io/github/issues/functionFox/NaviDoctorLC?style=plastic&logo=github)
![Github Release](https://img.shields.io/github/v/release/functionFox/NaviDoctorLC?style=plastic&logo=github)
![GitHub release (latest by date)](https://img.shields.io/github/downloads/functionFox/NaviDoctorLC/latest/total?style=plastic&logo=github)

### Current Support
![BN1 Supported](https://img.shields.io/badge/Battle_Network_1-✓-green?style=plastic&logo=steam)
![BN2 Supported](https://img.shields.io/badge/Battle_Network_2-✓-green?style=plastic&logo=steam)
![BN3 Supported](https://img.shields.io/badge/Battle_Network_3-✕-red?style=plastic&logo=steam)
![BN4 Supported](https://img.shields.io/badge/Battle_Network_4-✕-red?style=plastic&logo=steam)
![BN5 Supported](https://img.shields.io/badge/Battle_Network_5-✕-red?style=plastic&logo=steam)
![BN6 Supported](https://img.shields.io/badge/Battle_Network_6-✕-red?style=plastic&logo=steam)

Features:

- Edit MegaMan.EXE's HP and stats
- Equip and add Armors to your inventory
- Edit chip quantities in your Pack
- New! A "Set" button for Pack viewer to increase the quantity of the chips in your pack to a specified amount
- Fully functional Folder Editor
- New! Enhanced Folder Editor for BN2+: edit up to three of your unlocked Folders (BN2+)
- New! A fully functional Style Editor: change your currently equipped style (BN2/BN3)
- Add/Remove entries to your chip Library
- New! Editing capabilities for RegMem, BugFrags, SubChips, and the entire P.A. Memo Library (BN2+)

Experimental features:

- Recognizes Switch version saves*
- Can transfer saves to other people by editing the Steam ID

Coming Soon:

- Support for Mega Man Battle Network 3: White and Mega Man Battle Network 3: Blue
- NaviCust Viewer: Edit your NaviCust directly (BN3+)
- NaviCust Parts Editor: Add parts to your inventory, and compress/decompress your parts at will (BN3+)
- Mega and Giga Chip Libraries (BN3+)
- Xtra Folder editor: Edit the contents of your Xtra folder, including its name! (Side note: we still need to check if that's possible, but it's a feature we want.) (BN3+)

Known Issues:

- It is possible to edit your HP to 1000, then obtain an HP Memory in game to increase your HP past the base limit. Doing so will disable your ability to PvP Netbattle. The editor already takes this into account, so if you find yourself in this situation, save your game, load your file in the editor, and simply save again. The editor automatically tries to make sure you are able to PvP Netbattle. Similar issues arise when setting RegMem to 50, and SubMem to 8 in BN2+. The same process will fix this issue.
- Inserting chips directly into the pack using the save editor will not update the Library in the game; you'll have to use the Library Viewer. Due to a quirk in how Legacy Collection handles checking for achievement completion, using the Library Viewer to complete the Library by itself is also not enough to get the BN1 achievement for having all chips. In order to get the achievement for having all chips, you'll need to have the Library fully checked off, and then obtain any chip in the game. For games with title screen stars or in-game icons for milestone achievements (such as the BN2 Red, Purple, and Blue stars), however, no additional steps are needed.

Thank you for your patience while these features are being worked on! As always, NaviDoctor will strive to keep players within legitimately obtainable limits to ensure your ability to be Netbattle ready!

Future features and additions:

- Support for the entire MMBNLC line of games!
- Probably more stuff, this project is still very early in development. If you have suggestions, feel free to let us know!

Special thanks to MegaRockEXE, Prof. 9, Weenie, luckytyphlosion, GreigaMaster, GhostlyMire, and the rest of the TREZ community for your support!

**NOTICE: NaviDoctor LC does not enable the downloading or transfer of Switch version saves to PC nor is it a function I intend to pursue. Since the Switch version uses a different file naming scheme, you will have to load the file using the "All Files" option and manually navigate to the file's location. NaviDoctor LC will then automatically detect and load the file for any game it currently supports, as long as it is the Legacy Collection version. NaviDoctor LC cannot properly detect or load GBA version save files. NaviDoctor LC has not been tested with the PS4 version of the Legacy Collection.*
