# NaviDoctorLC
Mega Man Battle Network Legacy Collection save editor

NOTICE: Currently only supports MMBN1 for the Battle Network Legacy Collection for Steam.

Features:

- Edit MegaMan.EXE's HP and stats
- Equip and add Armors to your inventory
- Edit chip quantities in your Pack
- A "Set" button for Pack viewer to increase the quantity of the chips in your pack to a specified amount
- Fully functional Folder Editor
- Add/Remove entries to your chip Library

Experimental features:

- Recognizes Switch version saves*
- Can transfer saves to other people by editing the Steam ID

Coming Soon:
- Support for Mega Man Battle Network 2
- Fully functional Style Editor: change your currently equipped style (BN2/BN3), and add up to three styles in your style inventory (BN2 only)
- Expanded Folder Viewer: edit up to three of your unlocked Folders (BN2+)
- Editing capabilities for RegMem, BugFrags, SubChips, and the entire P.A. Memo Library (BN2+)

Known Issues:

- Trying to save with less than 30 chips in your folder generates an Index Out of Range error. I'll be adding a more user-friendly warning box that explains this better.
- It is possible to edit your HP to 1000, then obtain an HP Memory in game to increase your HP past the base limit. Doing so will disable your ability to PvP Netbattle. The editor already takes this into account, so if you find yourself in this situation, save your game, load your file in the editor, and simply save again. The editor automatically tries to make sure you are able to PvP Netbattle.
- Inserting chips directly into the pack using the save editor will not update the Library in the game; you'll have to use the Library Viewer. Due to a quirk in how Legacy Collection handles checking for achievement completion, using the Library Viewer to complete the Library by itself is also not enough to get the BN1 achievement for having all chips. In order to get the achievement for having all chips, you'll need to have the Library fully checked off, and then obtain any chip in the game. For games with title screen stars or in-game icons for milestone achievements (such as the BN2 Red, Purple, and Blue stars), however, no additional steps are needed.

Thank you for your patience while these features are being worked on! As always, NaviDoctor will strive to keep players within legitimately obtainable limits to ensure your ability to be Netbattle ready!

Future features and additions:

- Support for the entire MMBNLC line of games!
- NaviCust Editor (BN3+)
- NaviCust Parts editor: obtain NaviCust parts you want, and compress/decompress your parts at will without having to find and input lengthy button codes
- Probably more, I literally just started this project about a week ago.

Special thanks to MegaRockEXE, Prof. 9, Weenie, luckytyphlosion, GreigaMaster, GhostlyMire, and the rest of the TREZ community for your support!

**NOTICE: NaviDoctor LC does not enable the downloading or transfer of Switch version saves to PC nor is it a function I intend to pursue. Since the Switch version uses a different file naming scheme, you will have to load the file using the "All Files" option and manually navigate to the file's location. NaviDoctor LC will then automatically detect and load the file for any game it currently supports, as long as it is the Legacy Collection version. NaviDoctor LC cannot properly detect or load GBA version save files. NaviDoctor LC has not been tested with the PS4 version of the Legacy Collection.*
