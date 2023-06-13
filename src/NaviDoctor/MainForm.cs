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
            public void GenerateConfirmButton(SaveDataObject saveData)
            {
                confirmButton = new Button();
                confirmButton.Text = "Confirm";
                confirmButton.Anchor = AnchorStyles.None;
                confirmButton.Top = flowLayoutPanel.Bottom + 10;
                confirmButton.Left = ((form.Width - confirmButton.Width) / 2) + 50;
                confirmButton.Click += (sender, e) => ConfirmButton_Click(sender, e, saveData);

                form.Controls.Add(confirmButton);
            }
            private void ConfirmButton_Click(object sender, EventArgs e, SaveDataObject saveData)
            {
                UpdateLibraryData(saveData);
                form.Close();
            }
            private void UpdateLibraryData(SaveDataObject saveData)
            {
                List<BattleChipData> chipNameMap;
                switch (saveData.GameName)
                {
                    case GameTitle.Title.MegaManBattleNetwork:
                        chipNameMap = BattleChipData.BN1ChipNameMap;
                        break;
                    case GameTitle.Title.MegaManBattleNetwork2:
                        chipNameMap = BattleChipData.BN2ChipNameMap;
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
                            int libraryIndex = chipIndex / 8;
                            int bitIndex = 7 - (chipIndex % 8);

                            if (checkBox.Checked)
                                saveData.LibraryData[libraryIndex] |= (byte)(1 << bitIndex);
                            else
                                saveData.LibraryData[libraryIndex] &= (byte)~(1 << bitIndex);
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
        private void GenerateLibraryWindow(SaveDataObject saveData)
        {
            LibraryWindow libraryWindow = new LibraryWindow();

            int standardStopID;
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
                    break;
                default:
                    return;
            }

            for (int i = 1; i <= standardStopID; i++)
            {
                string chipName = BattleChipData.GetChipNameByID(chipNameMap, i).Name;

                if (chipName.Length < 4)
                    continue;

                int libraryIndex = (i) / 8;
                int bitIndex = 7 - ((i) % 8);
                bool isChecked = (saveData.LibraryData[libraryIndex] & (1 << bitIndex)) != 0;

                libraryWindow.AddChip(chipName, isChecked);
            }

            libraryWindow.GenerateCheckAllButton();
            libraryWindow.GenerateConfirmButton(saveData);
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
                default:
                    return;
            }

            for (int i = 0; i < packChips.Count; i++)
            {
                entries[i].Quantity = packChips[i];
            }

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Code", typeof(string));
            dataTable.Columns.Add("Quantity", typeof(int));

            foreach (var entry in entries)
            {
                dataTable.Rows.Add(entry.ID, entry.Name, entry.Code, entry.Quantity);
            }

            dataTable.DefaultView.RowFilter = "Code <> 'None'";

            dgvPack.DataSource = dataTable;

            dgvPack.Columns["ID"].Visible = false;
            dgvPack.Columns["Name"].ReadOnly = true;
            dgvPack.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvPack.Columns["Code"].ReadOnly = true;
            dgvPack.Columns["Quantity"].ReadOnly = false;

            dgvPack.AutoResizeColumns();
        }
        private void LoadFolderData(SaveDataObject saveData)
        {
            DataTable folderDataTable = new DataTable();
            folderDataTable.Columns.Add("ID", typeof(int));
            folderDataTable.Columns.Add("Name", typeof(string));
            folderDataTable.Columns.Add("Code", typeof(string));
            List<Tuple<int, int>> folderSaveData;
            List<BattleChipData> chipNameMap;

            switch (tabsFolders.SelectedIndex) // Check which folder is currently selected
            {
                case 1:
                    folderSaveData = saveData.Folder2Data;
                    break;
                case 2:
                    folderSaveData = saveData.Folder3Data;
                    break;
                default:
                    folderSaveData = saveData.FolderData;
                    break;
            }

            switch (saveData.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    chipNameMap = BattleChipData.BN1ChipNameMap;
                    break;
                case GameTitle.Title.MegaManBattleNetwork2:
                    chipNameMap = BattleChipData.BN2ChipNameMap;
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

                folderDataTable.Rows.Add(chipID, chipName, chipCodeLetter);
            }
            // Preserve the current selection and scroll position
            int selectedRowIndex = -1;
            int firstDisplayedScrollingRowIndex = -1;

            if (dgvFolder1.SelectedRows.Count > 0)
                selectedRowIndex = dgvFolder1.SelectedRows[0].Index;

            if (dgvFolder1.FirstDisplayedScrollingRowIndex >= 0)
                firstDisplayedScrollingRowIndex = dgvFolder1.FirstDisplayedScrollingRowIndex;

            dgvFolder1.DataSource = null;
            dgvFolder1.Rows.Clear();

            dgvFolder1.DataSource = folderDataTable;
            dgvFolder1.Columns["ID"].Visible = false;

            // Restore the previous selection and scroll position
            if (selectedRowIndex >= 0 && selectedRowIndex < dgvFolder1.Rows.Count)
                dgvFolder1.Rows[selectedRowIndex].Selected = true;

            if (firstDisplayedScrollingRowIndex >= 0 && firstDisplayedScrollingRowIndex < dgvFolder1.Rows.Count)
                dgvFolder1.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;

            dgvFolder1.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            lblFolderCount.Text = $"Folder Count: {dgvFolder1.RowCount}";
        }
        private void btnRemoveChip_Click(object sender, EventArgs e)
        {
            // Check if there is a selected row in the Folder DataGridView
            if (dgvFolder1.SelectedRows.Count > 0)
            {
                // Get the selected chip ID
                int chipID = (int)dgvFolder1.SelectedRows[0].Cells["ID"].Value;
                string chipCode = (string)dgvFolder1.SelectedRows[0].Cells["Code"].Value;
                int chipInt = 26; // Assuming * code unless told otherwise.
                if (chipCode != "*") chipInt = chipCode[0] - 'A';

                // Find the first occurrence of the chip in the FolderData list
                var chipToRemove = saveData.FolderData.FirstOrDefault(data => data.Item1 == chipID && data.Item2 == chipInt);

                // Remove the chip if found
                if (chipToRemove != null)
                {
                    saveData.FolderData.Remove(chipToRemove);
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
            int battleIDHigh;
            int naviIDLow;
            int naviIDHigh;
            int secretIDLow;
            int secretIDHigh;
            int maxBattleChipCopies;
            int maxNaviChips;
            int maxTotalChipsInFolder = 30;
            bool isBattleChip;
            bool isNaviChip;
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
                    secretIDLow = 0;
                    secretIDHigh = 0;
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
                int currentNaviChips;

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
                    default:
                        return;
                }

                if (isBattleChip && currentChipCopies >= maxBattleChipCopies)
                {
                    string chipName = BattleChipData.GetChipNameByID(chipNameMap, chipID).Name;
                    MessageBox.Show($"The limit for {chipName} cannot exceed {maxBattleChipCopies}.");
                }
                else if (isNaviChip && currentNaviChips >= maxNaviChips)
                {
                    MessageBox.Show($"The limit for Navi Chips cannot exceed {maxNaviChips}.");
                }
                else if (saveData.FolderData.Count >= maxTotalChipsInFolder)
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
                    if (chipCode != "*") saveData.FolderData.Add(new Tuple<int, int>(chipID, chipCode[0] - 'A'));
                    else saveData.FolderData.Add(new Tuple<int, int>(chipID, 26));

                    // Refresh the Folder DataGridView
                    LoadFolderData(saveData);
                }
            }
            else
            {
                MessageBox.Show("Please select a chip in the Pack view.");
            }
        }

        private void PackageChips()
        {
            dgvPack.Sort(dgvPack.Columns[0], ListSortDirection.Ascending); // Sort by ID column in ascending order

            switch (saveData.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    saveData.BattleChips = GeneratePackage(1, 147, 5);
                    saveData.NaviChips = GeneratePackage(148, 239, 1);
                    break;

                case GameTitle.Title.MegaManBattleNetwork2:
                    saveData.BattleChips = GeneratePackage(1, 193, 6);
                    saveData.NaviChips = GeneratePackage(194, 250, 2);
                    saveData.SecretChips = GeneratePackage(251, 271, 6);
                    break;
            }
        }

        private List<byte> GeneratePackage(int startID, int stopID, int codeCount)
        {
            List<byte> chipPackage = new List<byte>(Enumerable.Repeat((byte)0, (stopID - startID + 1) * codeCount));
            int codeSeries = 0;
            foreach (DataGridViewRow row in dgvPack.Rows)
            {
                if (row.Cells["ID"].Value != null && row.Cells["Quantity"].Value != null)
                {
                    int chipID = (int)row.Cells["ID"].Value;
                    int quantity = (int)row.Cells["Quantity"].Value;

                    quantity = Math.Max(0, Math.Min(quantity, 99));

                    if (chipID >= startID && chipID <= stopID)
                    {
                        int index = ((chipID - startID) * codeCount) + codeSeries;
                        chipPackage[index] = (byte)quantity;
                        codeSeries = (codeSeries + 1) % codeCount;
                    }
                }
            }
            return chipPackage;
        }

        private void btnShowLibrary_Click(object sender, EventArgs e)
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

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Open MMBN Save File...";
            openFile.InitialDirectory = @"C:\Program Files (x86)\Steam\userdata";
            openFile.Filter = "Legacy Collection Save File|*save_0.bin|MMBN1 Save File|exe1_save_0.bin|MMBN2 Save File|exe2j_save_0.bin|All Files|*.*";
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SaveParse saveParse = new SaveParse(openFile.FileName);
                    LoadFile(saveParse);
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

            BattleChipData battleChipData = new BattleChipData();
            PopulateDataGridView(battleChipData, saveData);

            LoadFolderData(saveData);

            maxHPStat.Value = saveData.MaxHP;
            attackStat.Value = saveData.AttackPower + 1;
            rapidStat.Value = saveData.RapidPower + 1;
            chargeStat.Value = saveData.ChargePower + 1;
            zennyBox.Value = saveData.Zenny;
            steamID.Value = saveData.SteamID;

            switch (saveData.GameName)
            {
                case GameTitle.Title.MegaManBattleNetwork:
                    LoadStyles(saveData); // This is loaded by all Vol.1 games, but not Vol.2 games.
                    break;

                case GameTitle.Title.MegaManBattleNetwork2:
                    LoadStyles(saveData);
                    nudBugFrag.Value = saveData.BugFrags;
                    nudRegMem.Value = saveData.RegMem;
                    /* subChipMax.Value = saveData.SubChipMax;
                    subMini.Value = saveData.SubMiniEnrg;
                    subFull.Value = saveData.SubFullEnrg;
                    subLoc.Value = saveData.SubLocEnemy;
                    subSneak.Value = saveData.SubSneakRun;
                    subUnlock.Value = saveData.SubUnlocker;
                    subUntrap.Value = saveData.SubUntrap; */
                    break;
            }


            //Show the current game loaded
            lblGameVersion.Text = $"Loaded: {saveData.GameName.GetString()}";
            DisplayModulesBasedOnGame();
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

            }
            saveFile.RestoreDirectory = true;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SaveParse saveParse = new SaveParse(saveFile.FileName);

                    SaveFile(saveParse);

                    MessageBox.Show("Save data successfully updated!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving the file: {ex.Message} {ex.StackTrace}");
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
                    /* saveData.BugFrags = (byte)bugFrags.Value; // Uncomment when these fields exist
                    saveData.RegMem = (byte)regMem.Value;
                    saveData.SubChipMax = (byte)subChipMax.Value;
                    saveData.SubMiniEnrg = (byte)subMini.Value;
                    saveData.SubFullEnrg = (byte)subFull.Value;
                    saveData.SubLocEnemy = (byte)subLoc.Value;
                    saveData.SubSneakRun = (byte)subSneak.Value;
                    saveData.SubUnlocker = (byte)subUnlock.Value;
                    saveData.SubUntrap = (byte)subUntrap.Value; */
                    break;
            }

            saveParse.UpdateSaveData(saveData);
            saveParse.SaveChanges();
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
                        //TODO: Add mapping for styles here
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
                    break;
                case GameTitle.Title.MegaManBattleNetwork2:
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
                            if (!tabsFolders.TabPages.Contains(tabPage_Folder3)) tabsFolders.TabPages.Insert(1, tabPage_Folder3);
                            break;
                        default:
                            break;
                    }
                    btnSelectStyles.Enabled = true;
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
    }
}
