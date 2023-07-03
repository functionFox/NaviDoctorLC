using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NaviDoctor.extensions;
using NaviDoctor.models;

namespace NaviDoctor
{
    public partial class MainForm : Form
    {
        private SaveDataObject saveData;
        private List<Style> _styles;
        private SaveParse _openFile;

        public MainForm()
        {
            InitializeComponent();
        }
        private class LibraryWindow
        {
            private Form form;
            private FlowLayoutPanel flowLayoutPanel;
            private Button checkAllButton;
            private Button confirmButton;

            public LibraryWindow()
            {
                form = new Form();
                flowLayoutPanel = new FlowLayoutPanel();

                form.Text = "Library Viewer";

                form.Width = 860;
                form.Height = 500;
                form.FormBorderStyle = FormBorderStyle.FixedSingle; // Disable resizing
                form.MaximizeBox = false; // Disable maximize button
                form.Icon = Properties.Resources.icon;

                flowLayoutPanel.Dock = DockStyle.Top;
                flowLayoutPanel.Height = (int)(form.Height * 0.8);
                flowLayoutPanel.AutoScroll = true;

                form.Controls.Add(flowLayoutPanel);
            }

            public void GenerateCheckAllButton()
            {
                checkAllButton = new Button();
                checkAllButton.Text = "Check All";
                checkAllButton.Anchor = AnchorStyles.None;
                checkAllButton.Top = flowLayoutPanel.Bottom + 10;
                checkAllButton.Left = ((form.Width - checkAllButton.Width) / 2) - 50;
                checkAllButton.Click += CheckAllButton_Click;

                form.Controls.Add(checkAllButton);
            }
            private void CheckAllButton_Click(object sender, EventArgs e)
            {
                foreach (Control control in flowLayoutPanel.Controls)
                {
                    if (control is CheckBox checkBox)
                    {
                        checkBox.Checked = true;
                    }
                }
            }
            public void GenerateConfirmButton(SaveDataObject saveData, bool paLib = false)
            {
                confirmButton = new Button();
                confirmButton.Text = "Confirm";
                confirmButton.Anchor = AnchorStyles.None;
                confirmButton.Top = flowLayoutPanel.Bottom + 10;
                confirmButton.Left = ((form.Width - confirmButton.Width) / 2) + 50;
                confirmButton.Click += (sender, e) => ConfirmButton_Click(sender, e, saveData, paLib);

                form.Controls.Add(confirmButton);
            }
            private void ConfirmButton_Click(object sender, EventArgs e, SaveDataObject saveData, bool paLib = false)
            {
                UpdateLibraryData(saveData, paLib);
                form.Close();
            }
            private void UpdateLibraryData(SaveDataObject saveData, bool paLib = false)
            {
                List<BattleChipData> chipNameMap;
                List<byte> libraryData;
                int libraryIndex;
                int paIndexStart;
                switch (saveData.GameName)
                {
                    case GameTitle.Title.MegaManBattleNetwork:
                        chipNameMap = BattleChipData.BN1ChipNameMap;
                        libraryData = saveData.LibraryData;
                        paIndexStart = 0; // BN1 doesn't have a PA library. Just set this to 0.
                        break;
                    case GameTitle.Title.MegaManBattleNetwork2:
                        chipNameMap = BattleChipData.BN2ChipNameMap;
                        paIndexStart = 0x110;
                        if (paLib)
                        {
                            libraryData = saveData.PALibraryData;
                        }
                        else
                        {
                            libraryData = saveData.LibraryData;
                        }
                        break;
                    case GameTitle.Title.MegaManBattleNetwork3Blue:
                    case GameTitle.Title.MegaManBattleNetwork3White:
                        chipNameMap = BattleChipData.BN3ChipNameMap;
                        paIndexStart = 0x140;
                        if (paLib)
                        {
                            libraryData = saveData.PALibraryData;
                        }
                        else
                        {
                            libraryData = saveData.LibraryData;
                        }
                        break;
                    default:
                        return;
                }
                foreach (Control control in flowLayoutPanel.Controls)
                {
                    if (control is CheckBox checkBox)
                    {
                        string chipName = checkBox.Text;
                        int chipIndex = BattleChipData.GetChipIDByName(chipNameMap, chipName);

                        if (chipIndex != -1)
                        {
                            if (!paLib)
                            {
                                libraryIndex = chipIndex / 8;
                            }
                            else
                            {
                                libraryIndex = (chipIndex - paIndexStart) / 8;
                            }
                            int bitIndex = 7 - (chipIndex % 8);

                            if (checkBox.Checked)
                                libraryData[libraryIndex] |= (byte)(1 << bitIndex);
                            else
                                libraryData[libraryIndex] &= (byte)~(1 << bitIndex);
                        }
                    }
                }
            }
            public void AddChip(string chipName, bool isChecked)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = chipName;
                checkBox.Checked = isChecked;
                flowLayoutPanel.Controls.Add(checkBox);
            }
            public void ShowDialog()
            {
                form.ShowDialog();
            }
        }
        private void GenerateLibraryWindow(SaveDataObject saveData, bool paLib = false)
        {
            LibraryWindow libraryWindow = new LibraryWindow();

            int standardStartID = 1;
            int standardStopID;
            bool isChecked;
            int libraryIndex;
            int bitIndex;
            List<BattleChipData> chipNameMap;

            switch (saveData.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    standardStopID = 199;
                    chipNameMap = BattleChipData.BN1ChipNameMap;
                    break;
                case GameTitle.Title.MegaManBattleNetwork2:
                    standardStopID = 0x10F;
                    chipNameMap = BattleChipData.BN2ChipNameMap;
                    if (paLib)
                    {
                        standardStartID = 0x110;
                        standardStopID = 0x12F;
                    }
                    break;
                case GameTitle.Title.MegaManBattleNetwork3Blue:
                case GameTitle.Title.MegaManBattleNetwork3White:
                    standardStopID = 0x138;
                    chipNameMap = BattleChipData.BN3ChipNameMap;
                    if (paLib)
                    {
                        standardStartID = 0x140;
                        standardStopID = 0x15F;
                    }
                    break;
                default:
                    return;
            }

            for (int i = standardStartID; i <= standardStopID; i++)
            {
                string chipName = BattleChipData.GetChipNameByID(chipNameMap, i).Name;

                if (chipName.Length < 3)
                    continue;
                if (!paLib)
                {
                    libraryIndex = (i) / 8;
                    bitIndex = 7 - ((i) % 8);
                    isChecked = (saveData.LibraryData[libraryIndex] & (1 << bitIndex)) != 0;
                } else
                {
                    libraryIndex = (i - standardStartID) / 8;
                    bitIndex = 7 - (i % 8);
                    isChecked = (saveData.PALibraryData[libraryIndex] & (1 << bitIndex)) != 0;
                }

                libraryWindow.AddChip(chipName, isChecked);
            }

            libraryWindow.GenerateCheckAllButton();
            libraryWindow.GenerateConfirmButton(saveData, paLib);
            libraryWindow.ShowDialog();
        }
        private string GetAlphabeticalCode(int chipCode)
        {
            if (chipCode == 26)
            {
                return "*";
            }

            char chipCodeLetter = (char)(chipCode + 0x41);
            return chipCodeLetter.ToString();
        }
        private void PopulateDataGridView(BattleChipData battleChipData, SaveDataObject saveData)
        {
            List<BattleChipData> entries = battleChipData.GenerateChipEntries(saveData);
            List<byte> packChips;

            switch (saveData.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    packChips = saveData.BattleChips.Concat(saveData.NaviChips).ToList();
                    break;
                case GameTitle.Title.MegaManBattleNetwork2:
                    packChips = saveData.BattleChips.Concat(saveData.NaviChips).Concat(saveData.SecretChips).ToList();
                    break;
                case GameTitle.Title.MegaManBattleNetwork3Blue:
                case GameTitle.Title.MegaManBattleNetwork3White:
                    packChips = saveData.BattleChips.Concat(saveData.NaviChips).ToList();
                    break;
                default:
                    return;
            }

            for (int i = 0; i < packChips.Count; i++)
            {
                entries[i].Quantity = packChips[i];
                if (entries[i].Code == "None") entries[i].Quantity = 0; // Automatically set illegal chips to 0.
            }

            DataView dataView = new DataView();
            dataView.Table = new DataTable("Pack");
            dataView.Table.Columns.Add("ID", typeof(int));
            dataView.Table.Columns.Add("Name", typeof(string));
            dataView.Table.Columns.Add("Code", typeof(string));
            dataView.Table.Columns.Add("Quantity", typeof(int));

            if(saveData.GameName != GameTitle.Title.MegaManBattleNetwork)
            {
                dataView.Table.Columns.Add("MB", typeof(int)); 
                foreach (var entry in entries)
                {
                    dataView.Table.Rows.Add(entry.ID, entry.Name, entry.Code, entry.Quantity, entry.Size);
                }
            }
            else
            {
                foreach (var entry in entries)
                {
                    dataView.Table.Rows.Add(entry.ID, entry.Name, entry.Code, entry.Quantity);
                }
            }

           

            dataView.RowFilter = "Code <> 'None'";

            dgvPack.DataSource = dataView;

            dgvPack.Columns["ID"].Visible = false;
            dgvPack.Columns["Name"].ReadOnly = true;
            dgvPack.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvPack.Columns["Code"].ReadOnly = true;
            dgvPack.Columns["Quantity"].ReadOnly = false;
            if (saveData.GameName != GameTitle.Title.MegaManBattleNetwork)
            {
                dgvPack.Columns["MB"].ReadOnly = true;
            }

            dgvPack.AutoResizeColumns();
        }
        private void LoadFolderData(SaveDataObject saveData)
        {
            switch(saveData.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    {
                        PopulateFolderDataGridView(dgvFolder1, saveData.FolderData);
                        break;
                    }
                case GameTitle.Title.MegaManBattleNetwork2:
                    {
                        for (var i = 1; i <= saveData.Folders; i++)
                        {
                            switch (i)
                            {
                                case 1:
                                    {
                                        PopulateFolderDataGridView(dgvFolder1, saveData.FolderData);
                                        break;
                                    }
                                case 2:
                                    {
                                        PopulateFolderDataGridView(dgvFolder2, saveData.Folder2Data);
                                        break;
                                    }
                                case 3:
                                    {
                                        PopulateFolderDataGridView(dgvFolder3, saveData.Folder3Data);
                                        break;
                                    }
                                default:
                                    break;
                            }
                        }
                        break;
                    }
                case GameTitle.Title.MegaManBattleNetwork3White:
                case GameTitle.Title.MegaManBattleNetwork3Blue:
                    {
                        for (var i = 1; i <= saveData.Folders; i++) // Just a copy/paste of BN2 for now.
                        {
                            switch (i)
                            {
                                case 1:
                                    {
                                        PopulateFolderDataGridView(dgvFolder1, saveData.FolderData);
                                        break;
                                    }
                                case 2:
                                    {
                                        PopulateFolderDataGridView(dgvFolder2, saveData.Folder2Data); // This is Xtra Folder
                                        break;
                                    }
                                case 3:
                                    {
                                        PopulateFolderDataGridView(dgvFolder3, saveData.Folder3Data);
                                        break;
                                    }
                                default:
                                    break;
                            }
                        }
                        break;
                    }
            }
        }
        
        private void PopulateFolderDataGridView(DataGridView dgvFolder, List<Tuple<int, int>> folderSaveData)
        {
            DataTable folderDataTable = new DataTable();
            folderDataTable.Columns.Add("ID", typeof(int));
            folderDataTable.Columns.Add("Name", typeof(string));
            folderDataTable.Columns.Add("Code", typeof(string));
            if(saveData.GameName != GameTitle.Title.MegaManBattleNetwork)
            {
                folderDataTable.Columns.Add("MB", typeof(int));
            }

            List<BattleChipData> chipNameMap;
            switch (saveData.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    chipNameMap = BattleChipData.BN1ChipNameMap;
                    break;
                case GameTitle.Title.MegaManBattleNetwork2:
                    chipNameMap = BattleChipData.BN2ChipNameMap;
                    break;
                case GameTitle.Title.MegaManBattleNetwork3White:
                case GameTitle.Title.MegaManBattleNetwork3Blue:
                    chipNameMap = BattleChipData.BN3ChipNameMap;
                    break;
                default:
                    return;
            }

            foreach (var folderData in folderSaveData)
            {
                int chipID = folderData.Item1;
                int chipCode = folderData.Item2;

                string chipName = BattleChipData.GetChipNameByID(chipNameMap, chipID).Name;
                string chipCodeLetter = GetAlphabeticalCode(chipCode);
                if (saveData.GameName != GameTitle.Title.MegaManBattleNetwork)
                {
                    int size = BattleChipData.GetChipNameByID(chipNameMap, chipID).Size;

                    folderDataTable.Rows.Add(chipID, chipName, chipCodeLetter, size);
                }
                else
                {
                    folderDataTable.Rows.Add(chipID, chipName, chipCodeLetter);
                }
            }
            // Preserve the current selection and scroll position
            int selectedRowIndex = -1;
            int firstDisplayedScrollingRowIndex = -1;

            if (dgvFolder.SelectedRows.Count > 0)
                selectedRowIndex = dgvFolder.SelectedRows[0].Index;

            if (dgvFolder.FirstDisplayedScrollingRowIndex >= 0)
                firstDisplayedScrollingRowIndex = dgvFolder.FirstDisplayedScrollingRowIndex;

            dgvFolder.DataSource = null;
            dgvFolder.Rows.Clear();

            dgvFolder.DataSource = folderDataTable;
            dgvFolder.Columns["ID"].Visible = false;

            // Restore the previous selection and scroll position
            if (selectedRowIndex >= 0 && selectedRowIndex < dgvFolder.Rows.Count)
                dgvFolder.Rows[selectedRowIndex].Selected = true;

            if (firstDisplayedScrollingRowIndex >= 0 && firstDisplayedScrollingRowIndex < dgvFolder.Rows.Count)
                dgvFolder.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;

            dgvFolder.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void btnRemoveChip_Click(object sender, EventArgs e)
        {
            switch (saveData.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    {
                        RemoveChip(dgvFolder1, saveData.FolderData);
                        break;
                    }
                case GameTitle.Title.MegaManBattleNetwork2:
                    {
                        switch (tabsFolders.SelectedIndex)
                        {
                            case 0:
                                {
                                    RemoveChip(dgvFolder1, saveData.FolderData);
                                    break;
                                }
                            case 1:
                                {
                                    RemoveChip(dgvFolder2, saveData.Folder2Data);
                                    break;
                                }
                            case 2:
                                {
                                    RemoveChip(dgvFolder3, saveData.Folder3Data);
                                    break;
                                }
                            default:
                                break;
                        }
                        break;
                    }
                case GameTitle.Title.MegaManBattleNetwork3Blue:
                case GameTitle.Title.MegaManBattleNetwork3White:
                    {
                        switch (tabsFolders.SelectedIndex)
                        {
                            case 0:
                                {
                                    RemoveChip(dgvFolder1, saveData.FolderData);
                                    break;
                                }
                            case 1:
                                {
                                    // RemoveChip(dgvFolder2, saveData.Folder2Data); Can't edit Xtra Folder
                                    break;
                                }
                            case 2:
                                {
                                    RemoveChip(dgvFolder3, saveData.Folder3Data);
                                    break;
                                }
                            default:
                                break;
                        }
                        break;
                    }
            }
           
        }

        private void RemoveChip(DataGridView dgvFolder, List<Tuple<int, int>> folderData)
        {
            // Check if there is a selected row in the Folder DataGridView
            if (dgvFolder.SelectedRows.Count > 0)
            {
                // Get the selected chip ID
                int chipID = (int)dgvFolder.SelectedRows[0].Cells["ID"].Value;
                string chipCode = (string)dgvFolder.SelectedRows[0].Cells["Code"].Value;
                int chipInt = 26; // Assuming * code unless told otherwise.
                if (chipCode != "*") chipInt = chipCode[0] - 'A';

                // Find the first occurrence of the chip in the FolderData list
                var chipToRemove = folderData.FirstOrDefault(data => data.Item1 == chipID && data.Item2 == chipInt);

                // Remove the chip if found
                if (chipToRemove != null)
                {
                    folderData.Remove(chipToRemove);
                }
                else
                {
                    MessageBox.Show("The selected chip was not found in the Folder.");
                }

                // Refresh the Folder DataGridView
                LoadFolderData(saveData);
            }
            else
            {
                MessageBox.Show("Please select a chip in the Folder view.");
            }

            UpdateFolderCount();
        }

        // check the quantity of a chip ID and code in the Folder
        private int GetChipQuantityInFolder(int chipID, string chipCode)
        { 
            if (chipCode != "*") return saveData.FolderData.Count(data => data.Item1 == chipID && data.Item2 == (byte)(chipCode[0] - 'A'));
            return saveData.FolderData.Count(data => data.Item1 == chipID && data.Item2 == 26);
        }
        private void btnAddChip_Click(object sender, EventArgs e)
        {
            List<Tuple<int, int>> folderData;
            int battleIDHigh = 0;
            int naviIDLow = 0;
            int naviIDHigh = 0;
            int secretIDLow = 0;
            int secretIDHigh = 0;
            int maxBattleChipCopies = 0;
            int maxNaviChips = 0;
            int maxTotalChipsInFolder = 30;
            bool isBattleChip = false;
            bool isNaviChip = false;
            bool isMegaChip = false;
            bool isGigaChip = false;
            int megaLimit = 0;
            int gigaLimit = 0;
            List<BattleChipData> chipNameMap;
            switch (tabsFolders.SelectedIndex) // Check which folder is currently selected
            {
                case 1:
                    folderData = saveData.Folder2Data;
                    break;
                case 2:
                    folderData = saveData.Folder3Data;
                    break;
                default:
                    folderData = saveData.FolderData;
                    break;
            }

            switch (saveData.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    battleIDHigh = 147;
                    naviIDLow = 148;
                    naviIDHigh = 239;
                    maxBattleChipCopies = 10;
                    maxNaviChips = 5;
                    chipNameMap = BattleChipData.BN1ChipNameMap;
                    break;
                case GameTitle.Title.MegaManBattleNetwork2: // Not actual BN2 values.
                    battleIDHigh = 193;
                    naviIDLow = 194;
                    naviIDHigh = 250;
                    secretIDLow = 251;
                    secretIDHigh = 271;
                    maxBattleChipCopies = 5;
                    maxNaviChips = 5;
                    chipNameMap = BattleChipData.BN2ChipNameMap;
                    break;
                case GameTitle.Title.MegaManBattleNetwork3White:
                case GameTitle.Title.MegaManBattleNetwork3Blue:
                    battleIDHigh = 0xC8;
                    naviIDLow = 0xC9;
                    naviIDHigh = 0x138;
                    maxBattleChipCopies = 4;
                    megaLimit = saveData.MegaLimit;
                    gigaLimit = saveData.GigaLimit;
                    maxNaviChips = 5;
                    chipNameMap = BattleChipData.BN3ChipNameMap;
                    break;
                default:
                    return;
            }

            // Check if there is a selected row in the Pack DataGridView
            if (dgvPack.SelectedRows.Count > 0)
            {
                // Get the selected chip ID and code from the Pack
                int chipID = (int)dgvPack.SelectedRows[0].Cells["ID"].Value;
                string chipCode = dgvPack.SelectedRows[0].Cells["Code"].Value.ToString();

                // Check if the Folder has reached the maximum number of copies for the selected chip ID
                int currentChipCopies = folderData.Count(data => data.Item1 == chipID);
                int currentNaviChips = 0;
                int currentGigaChips = 0;

                switch (saveData.GameName)
                {
                    case GameTitle.Title.MegaManBattleNetwork:
                        currentNaviChips = folderData.Count(data => data.Item1 >= naviIDLow && data.Item1 <= naviIDHigh);
                        isBattleChip = chipID >= 1 && chipID <= battleIDHigh;
                        isNaviChip = chipID >= naviIDLow && chipID <= naviIDHigh;
                        break;
                    case GameTitle.Title.MegaManBattleNetwork2:
                        currentNaviChips = folderData.Count(data => (data.Item1 >= naviIDLow && data.Item1 <= naviIDHigh) || (data.Item1 >= 261 && data.Item1 <= 265));
                        isBattleChip = (chipID >= 1 && chipID <= battleIDHigh) || (chipID >= secretIDLow && chipID <= 260) || (chipID >= 266 && chipID <= secretIDHigh); // Secret NetBattle reward chips
                        isNaviChip = (chipID >= naviIDLow && chipID <= naviIDHigh) || (chipID >= 261 && chipID <= 265); // Event Navis
                        break;
                    case GameTitle.Title.MegaManBattleNetwork3Blue:
                    case GameTitle.Title.MegaManBattleNetwork3White:
                        currentNaviChips = folderData.Count(data => data.Item1 >= naviIDLow && data.Item1 <= naviIDHigh && chipNameMap.FirstOrDefault(chip => chip.ID == data.Item1).Type == 1); // current count of mega chips
                        currentGigaChips = folderData.Count(data => data.Item1 >= naviIDLow && data.Item1 <= naviIDHigh && chipNameMap.FirstOrDefault(chip => chip.ID == data.Item1).Type > 1); // current count of giga chips
                        isBattleChip = chipNameMap.FirstOrDefault(data => data.ID == chipID).Type == 0;
                        isNaviChip = chipNameMap.FirstOrDefault(data => data.ID == chipID).Type != 0;
                        isMegaChip = chipNameMap.FirstOrDefault(data => data.ID == chipID).Type == 1;
                        isGigaChip = chipNameMap.FirstOrDefault(data => data.ID == chipID).Type >= 2;
                        break;
                    default:
                        return;
                }

                string chipName = BattleChipData.GetChipNameByID(chipNameMap, chipID).Name;

                if (isBattleChip && currentChipCopies >= maxBattleChipCopies)
                {
                    MessageBox.Show($"The limit for {chipName} cannot exceed {maxBattleChipCopies}.");
                }
                else if (isNaviChip && currentNaviChips >= maxNaviChips && saveData.GameName <= GameTitle.Title.MegaManBattleNetwork2)
                {
                    MessageBox.Show($"The limit for Navi Chips cannot exceed {maxNaviChips}.");
                }
                else if (isNaviChip && saveData.GameName >= GameTitle.Title.MegaManBattleNetwork3White)
                {
                    if (isMegaChip && currentChipCopies < 1 && currentNaviChips >= megaLimit)
                    {
                        MessageBox.Show($"The limit for Mega Chips cannot exceed {megaLimit}.");
                    }
                    else if (isMegaChip && currentChipCopies >= 1)
                    {
                        MessageBox.Show($"You may only have one copy of {chipName} in this folder.");
                    }
                    else if (isGigaChip && currentChipCopies < 1 && currentGigaChips >= gigaLimit)
                    {
                        MessageBox.Show($"The limit for Giga Chips cannot exceed {gigaLimit}.");
                    }
                    else if (isGigaChip && currentChipCopies >= 1)
                    {
                        MessageBox.Show($"You may only have one copy of {chipName} in this folder.");
                    }
                }
                else if (folderData.Count >= maxTotalChipsInFolder)
                {
                    MessageBox.Show($"The number of chips in the folder cannot exceed {maxTotalChipsInFolder}.");
                }
                else
                {
                    // Check the quantity of the chip ID and code in the Folder
                    int folderChipQuantity = GetChipQuantityInFolder(chipID, chipCode);

                    // Increment the quantity in the Pack if the quantity in the Folder is less than or equal to the quantity in the Pack
                    int packChipQuantity = (int)dgvPack.SelectedRows[0].Cells["Quantity"].Value;
                    if (folderChipQuantity >= packChipQuantity)
                    {
                        dgvPack.SelectedRows[0].Cells["Quantity"].Value = folderChipQuantity + 1;
                    }

                    // Add the chip to the FolderData list with the selected chip code
                    if (chipCode != "*") folderData.Add(new Tuple<int, int>(chipID, chipCode[0] - 'A'));
                    else folderData.Add(new Tuple<int, int>(chipID, 26));

                    // Refresh the Folder DataGridView
                    LoadFolderData(saveData);
                }
            }
            else
            {
                MessageBox.Show("Please select a chip in the Pack view.");
            }
            UpdateFolderCount();
        }

        private void PackageChips()
        {
            dgvPack.Sort(dgvPack.Columns[0], ListSortDirection.Ascending); // Sort by ID column in ascending order
            Dictionary<string, List<string>> chipCodeMap;

            switch (saveData.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    chipCodeMap = BattleChipData.BN1ChipCodeMap;
                    saveData.BattleChips = GeneratePackage(1, 147, 5, chipCodeMap);
                    saveData.NaviChips = GeneratePackage(148, 239, 1, chipCodeMap);
                    break;

                case GameTitle.Title.MegaManBattleNetwork2:
                    chipCodeMap = BattleChipData.BN2ChipCodeMap;
                    saveData.BattleChips = GeneratePackage(1, 193, 6, chipCodeMap);
                    saveData.NaviChips = GeneratePackage(194, 250, 2, chipCodeMap);
                    saveData.SecretChips = GeneratePackage(251, 271, 6, chipCodeMap);
                    break;
                case GameTitle.Title.MegaManBattleNetwork3White:
                case GameTitle.Title.MegaManBattleNetwork3Blue:
                    chipCodeMap = BattleChipData.BN3ChipCodeMap;
                    saveData.BattleChips = GeneratePackage(1, 0xC8, 6, chipCodeMap);
                    saveData.NaviChips = GeneratePackage(0xC9, 0x138, 2, chipCodeMap);
                    break;
            }
        }

        private List<byte> GeneratePackage(int startID, int stopID, int codeCount, Dictionary<string, List<string>> chipCodeMap)
        {
            List<byte> chipPackage = new List<byte>(Enumerable.Repeat((byte)0, (stopID - startID + 1) * codeCount));

            foreach (DataGridViewRow row in dgvPack.Rows)
            {
                if (row.Cells["ID"].Value != null && row.Cells["Quantity"].Value != null)
                {
                    int chipID = (int)row.Cells["ID"].Value;
                    int quantity = (int)row.Cells["Quantity"].Value;
                    
                    quantity = Math.Max(0, Math.Min(quantity, 99));

                    if (chipID >= startID && chipID <= stopID)
                    {
                        int codeSeries = chipCodeMap[row.Cells["Name"].Value.ToString()].IndexOf(row.Cells["Code"].Value.ToString());
                        int index = ((chipID - startID) * codeCount) + codeSeries;
                        chipPackage[index] = (byte)quantity;
                    }
                }
            }
            return chipPackage;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Open MMBN Save File...";
            openFile.InitialDirectory = @"C:\Program Files (x86)\Steam\userdata";
            openFile.Filter = "Legacy Collection Save File|*save_0.bin|MMBN1 Save File|exe1_save_0.bin|MMBN2 Save File|exe2j_save_0.bin|exe3?_save_0.bin|MMBN3 Save File|All Files|*.*";
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _openFile = new SaveParse(openFile.FileName);
                    LoadFile(_openFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex}");
                }
            }
        }

        private void LoadFile(SaveParse saveParse)
        {
            saveData = saveParse.ExtractSaveData();

            DisplayModulesBasedOnGame();
            BattleChipData battleChipData = new BattleChipData();
            PopulateDataGridView(battleChipData, saveData);

            LoadFolderData(saveData);

            maxHPStat.Value = saveData.HPUp * 20 + 100; // Calculate base HP based on how many HP ups were obtained.
            attackStat.Value = saveData.AttackPower + 1;
            rapidStat.Value = saveData.RapidPower + 1;
            chargeStat.Value = saveData.ChargePower + 1;
            zennyBox.Value = saveData.Zenny;
            steamID.Value = saveData.SteamID;

            switch (saveData.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    LoadStyles(saveData); // This is loaded by all Vol.1 games, but not Vol.2 games.
                    nudBugFrag.Value = 0; // It bothered me seeing my BugFrags and RegMem from BN2 when I loaded BN1 over it.
                    nudRegMem.Value = 0;  // So they're 0 now.
                    break;

                case GameTitle.Title.MegaManBattleNetwork2:
                    LoadStyles(saveData);
                    nudBugFrag.Value = saveData.BugFrags;
                    nudRegMem.Value = saveData.RegMem;
                    nudSubChipMax.Value = saveData.SubChipMax;
                    nudMiniEnrg.Value = saveData.SubMiniEnrg;
                    nudFullEnrg.Value = saveData.SubFullEnrg;
                    nudLocEnemy.Value = saveData.SubLocEnemy;
                    nudSneakRun.Value = saveData.SubSneakRun;
                    nudUnlocker.Value = saveData.SubUnlocker;
                    nudUntrap.Value = saveData.SubUntrap;
                    break;
                case GameTitle.Title.MegaManBattleNetwork3White:
                case GameTitle.Title.MegaManBattleNetwork3Blue:
                    // LoadStyles(saveData); // Uncomment when styles are implemented properly
                    nudBugFrag.Value = saveData.BugFrags;
                    nudRegMem.Value = saveData.RegMem;
                    nudSubChipMax.Value = saveData.SubChipMax;
                    nudMiniEnrg.Value = saveData.SubMiniEnrg;
                    nudFullEnrg.Value = saveData.SubFullEnrg;
                    nudLocEnemy.Value = saveData.SubLocEnemy;
                    nudSneakRun.Value = saveData.SubSneakRun;
                    nudUnlocker.Value = saveData.SubUnlocker;
                    nudUntrap.Value = saveData.SubUntrap;
                    break;
            }

            //Show the current game loaded
            lblGameVersion.Text = $"Loaded: {saveData.GameName.GetString()}";
            UpdateFolderCount();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if a save file has been loaded
            if (saveData == null)
            {
                MessageBox.Show("Please load a save file first.");
                return; // Exit the event handler
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Save MMBN Save File...";
            saveFile.InitialDirectory = $@"C:\Program Files (x86)\Steam\userdata\{saveData.SteamID}\1798010\remote\";

            switch (saveData.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    saveFile.FileName = "exe1_save_0.bin";
                    saveFile.Filter = "MMBN1 Save File|exe1_save_0.bin|All Files|*.*";
                    break;
                case GameTitle.Title.MegaManBattleNetwork2:
                    saveFile.FileName = "exe2j_save_0.bin";
                    saveFile.Filter = "MMBN2 Save File|exe2j_save_0.bin|All Files|*.*";
                    break;
                case GameTitle.Title.MegaManBattleNetwork3White:
                    saveFile.FileName = "exe3w_save_0.bin";
                    saveFile.Filter = "MMBN3W Save File|exe3w_save_0.bin|All Files|*.*";
                    break;
                case GameTitle.Title.MegaManBattleNetwork3Blue:
                    saveFile.FileName = "exe3b_save_0.bin";
                    saveFile.Filter = "MMBN3B Save File|exe3b_save_0.bin|All Files|*.*";
                    break;

            }
            saveFile.RestoreDirectory = true;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                { 
                    if (_openFile.saveFilePath == saveFile.FileName && File.Exists(saveFile.FileName))
                    {
                        _openFile.saveFilePath = saveFile.FileName + ".backup";
                        _openFile.SaveChanges();
                    }
                    _openFile.saveFilePath = saveFile.FileName;
                    SaveFile(_openFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving the file:\n{ex.Message}\n{ex.StackTrace}");
                }
            }
        }

        private void SaveFile(SaveParse saveParse)
        {
            saveData.MaxHP = (short)maxHPStat.Value;
            saveData.CurrHP = (short)maxHPStat.Value;
            saveData.AttackPower = (byte)(attackStat.Value - 1);
            saveData.RapidPower = (byte)(rapidStat.Value - 1);
            saveData.ChargePower = (byte)(chargeStat.Value - 1);
            saveData.Zenny = (int)zennyBox.Value;
            saveData.SteamID = (int)steamID.Value;
            PackageChips();
            
            switch (saveData.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    UpdateStyles(saveData);
                    break;

                case GameTitle.Title.MegaManBattleNetwork2:
                    UpdateStyles(saveData);
                    saveData.BugFrags = (byte)nudBugFrag.Value; 
                    saveData.RegMem = (byte)nudRegMem.Value;
                    saveData.SubChipMax = (byte)nudSubChipMax.Value;
                    saveData.SubMiniEnrg = (byte)nudMiniEnrg.Value;
                    saveData.SubFullEnrg = (byte)nudFullEnrg.Value;
                    saveData.SubLocEnemy = (byte)nudLocEnemy.Value;
                    saveData.SubSneakRun = (byte)nudSneakRun.Value;
                    saveData.SubUnlocker = (byte)nudUnlocker.Value;
                    saveData.SubUntrap = (byte)nudUntrap.Value;
                    break;
            }
            if (dgvFolder1.Rows.Count < 30 || (saveData.Folders >= 2 && dgvFolder2.Rows.Count < 30) || (saveData.Folders == 3 && dgvFolder3.Rows.Count < 30))
            {
                MessageBox.Show("An error occured while saving the file:\nFolder has less than 30 chips.");
                return;
            }
            saveParse.UpdateSaveData(saveData);
            saveParse.SaveChanges();
            MessageBox.Show("Save data successfully updated!");
        }

        private void LoadStyles(SaveDataObject saveData)
        {
            List<Style> _tempStyles;

            switch (saveData.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    {
                        _tempStyles = Style.BN1;

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
                        _tempStyles = Style.BN2;
                        var index = 0;

                        foreach(var style in saveData.StyleTypes)
                        {
                            var hex = Convert.ToString(style, 16).ToUpper();
                            switch (hex)
                            {
                                case "190": //Normal
                                    break;
                                case "196": //ElecGuts
                                    _tempStyles.FirstOrDefault(x => x.Name == Style.Value.ElecGuts).Add = true;
                                    switch(index)
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
                        
                        switch(equipHex)
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
                default:
                    break;
            }
                        
        }

        private void UpdateStyles(SaveDataObject saveData)
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
                            switch(style.Name)
                            {
                                case Style.Value.Normal:
                                    {
                                        if(style.Equip.GetValueOrDefault(false))
                                        {
                                            saveData.EqStyle = Convert.ToByte("00", 16);
                                        }
                                        break;
                                    }
                                case Style.Value.AquaGuts:
                                    {
                                        if (style.Equip.GetValueOrDefault(false))
                                        {
                                            switch(style.Version.GetValueOrDefault(1))
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
                                            switch(index)
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
                default: break;
            }
        }

        private void btnSetPackQuantity_Click(object sender, EventArgs e)
        {
            int packQuantity = (int)nudPackQuantity.Value;

            foreach(DataGridViewRow chip in dgvPack.Rows)
            {
                if ((int)chip.Cells[3].Value < packQuantity)
                {
                    chip.Cells[3].Value = packQuantity;
                }
            }
        }

        private void cbx_EditSteamID_CheckedChanged(object sender, EventArgs e)
        {
            steamID.Enabled = cbx_EditSteamID.Checked;
        }

        private void DisplayModulesBasedOnGame()
        {
            switch (saveData.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    if (tabsFolders.TabPages.Contains(tabPage_Folder2)) tabsFolders.TabPages.Remove(tabPage_Folder2);
                    if (tabsFolders.TabPages.Contains(tabPage_Folder3)) tabsFolders.TabPages.Remove(tabPage_Folder3);
                    btnSelectStyles.Enabled = true;
                    panelBugFragRegMem.Visible = false;
                    panelSubChips.Visible = false;
                    programAdvanceMemoToolStripMenuItem.Enabled = false;
                    break;
                case GameTitle.Title.MegaManBattleNetwork2:
                    programAdvanceMemoToolStripMenuItem.Enabled = true;
                    switch (saveData.Folders)
                    {
                        case 1:
                            if (tabsFolders.TabPages.Contains(tabPage_Folder2)) tabsFolders.TabPages.Remove(tabPage_Folder2);
                            if (tabsFolders.TabPages.Contains(tabPage_Folder3)) tabsFolders.TabPages.Remove(tabPage_Folder3);
                            break;
                        case 2:
                            if (!tabsFolders.TabPages.Contains(tabPage_Folder2)) tabsFolders.TabPages.Insert(1, tabPage_Folder2);
                            if (tabsFolders.TabPages.Contains(tabPage_Folder3)) tabsFolders.TabPages.Remove(tabPage_Folder3);
                            break;
                        case 3:
                            if (!tabsFolders.TabPages.Contains(tabPage_Folder2)) tabsFolders.TabPages.Insert(1, tabPage_Folder2);
                            if (!tabsFolders.TabPages.Contains(tabPage_Folder3)) tabsFolders.TabPages.Insert(2, tabPage_Folder3);
                            break;
                        default:
                            break;
                    }
                    btnSelectStyles.Enabled = true;
                    panelBugFragRegMem.Visible = true;
                    panelSubChips.Visible = true;
                    break;
                case GameTitle.Title.MegaManBattleNetwork3White:
                case GameTitle.Title.MegaManBattleNetwork3Blue:
                    break;
                case GameTitle.Title.MegaManBattleNetwork4RedSun:
                case GameTitle.Title.MegaManBattleNetwork4BlueMoon:
                    break;
                case GameTitle.Title.MegaManBattleNetwork5TeamProtoman:
                case GameTitle.Title.MegaManBattleNetwork5TeamColonel:
                    break;
                case GameTitle.Title.MegaManBattleNetwork6CybeastGregar:
                case GameTitle.Title.MegaManBattleNetwork6CybeastFalzar:
                    break;
            }
        }

        private void btnSelectStyles_Click(object sender, EventArgs e)
        {
            var styleLoader = new StyleLoader(_styles, saveData.GameName);
            if (styleLoader.ShowDialog() == DialogResult.OK)
            {
                _styles = styleLoader._styles;
            }
        }

        private void tabsFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFolderCount();
        }

        private void UpdateFolderCount()
        {
            switch (tabsFolders.SelectedIndex)
            {
                case 0:
                    lblFolderCount.Text = $"Folder1 Count: {dgvFolder1.RowCount}";
                    break;
                case 1:
                    lblFolderCount.Text = $"Folder2 Count: {dgvFolder2.RowCount}";
                    break;
                case 2:
                    lblFolderCount.Text = $"Folder3 Count: {dgvFolder3.RowCount}";
                    break;
                default:
                    lblFolderCount.Text = "";
                    break;
            }
        }

        private void nudMiniEnrg_ValueChanged(object sender, EventArgs e)
        {
            if(SubChipOverMax(nudMiniEnrg.Value))
            {
                nudMiniEnrg.Value--;
            }
        }

        private void nudFullEnrg_ValueChanged(object sender, EventArgs e)
        {
            if (SubChipOverMax(nudFullEnrg.Value))
            {
                nudFullEnrg.Value--;
            }
        }

        private void nudUntrap_ValueChanged(object sender, EventArgs e)
        {
            if (SubChipOverMax(nudUntrap.Value))
            {
                nudUntrap.Value--;
            }
        }

        private void nudSneakRun_ValueChanged(object sender, EventArgs e)
        {
            if (SubChipOverMax(nudSneakRun.Value))
            {
                nudSneakRun.Value--;
            }

        }

        private void nudLocEnemy_ValueChanged(object sender, EventArgs e)
        {
            if (SubChipOverMax(nudLocEnemy.Value))
            {
                nudLocEnemy.Value--;
            }

        }

        private void nudUnlocker_ValueChanged(object sender, EventArgs e)
        {
            if (SubChipOverMax(nudUnlocker.Value))
            {
                nudUnlocker.Value--;
            }

        }

        private bool SubChipOverMax(decimal value)
        {
            return value > nudSubChipMax.Value;
        }

        private void libraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if a save file has been loaded
            if (saveData == null)
            {
                MessageBox.Show("Please load a save file first.");
                return; // Exit the event handler
            }

            // Call the GenerateLibraryWindow method to display the library data
            GenerateLibraryWindow(saveData);
        }

        private void programAdvanceMemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if a save file has been loaded
            if (saveData == null)
            {
                MessageBox.Show("Please load a save file first.");
                return; // Exit the event handler
            }

            // Call the GenerateLibraryWindow method to display the library data
            GenerateLibraryWindow(saveData, true);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutPage = new AboutUs();
            aboutPage.ShowDialog();
        }
    }
}
