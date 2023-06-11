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
                foreach (Control control in flowLayoutPanel.Controls)
                {
                    if (control is CheckBox checkBox)
                    {
                        string chipName = checkBox.Text;
                        int chipIndex = BattleChipData.GetChipIDByName(BattleChipData.BN1ChipNameMap, chipName);

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

            for (int i = 1; i <= 199; i++)
            {
                string chipName = BattleChipData.GetChipNameByID(BattleChipData.BN1ChipNameMap, i).Name;

                if (chipName.Length < 3)
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
            char chipCodeLetter = (char)(chipCode + 0x41);
            return chipCodeLetter.ToString();
        }
        private void PopulateDataGridView(BattleChipData battleChipData, SaveDataObject saveData)
        {
            List<BattleChipData> entries = battleChipData.GenerateChipEntries();
            List<byte> packChips = saveData.BattleChips.Concat(saveData.NaviChips).ToList();

            for (int i = 0; i < entries.Count; i++)
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

            foreach (var folderData in saveData.FolderData)
            {
                int chipID = folderData.Item1;
                int chipCode = folderData.Item2;

                string chipName = BattleChipData.GetChipNameByID(BattleChipData.BN1ChipNameMap, chipID).Name;
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
                int chipInt = chipCode[0] - 'A';

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
            byte codeValue = (byte)(chipCode[0] - 'A');
            return saveData.FolderData.Count(data => data.Item1 == chipID && data.Item2 == codeValue);
        }
        private void btnAddChip_Click(object sender, EventArgs e)
        {
            // Check if there is a selected row in the Pack DataGridView
            if (dgvPack.SelectedRows.Count > 0)
            {
                // Get the selected chip ID and code from the Pack
                int chipID = (int)dgvPack.SelectedRows[0].Cells["ID"].Value;
                string chipCode = dgvPack.SelectedRows[0].Cells["Code"].Value.ToString();

                // Check if the Folder has reached the maximum number of copies for the selected chip ID
                int currentChipCopies = saveData.FolderData.Count(data => data.Item1 == chipID);
                int currentNaviChips = saveData.FolderData.Count(data => data.Item1 >= 148 && data.Item1 <= 239);

                bool isBattleChip = chipID >= 1 && chipID <= 147;
                bool isNaviChip = chipID >= 148 && chipID <= 239;

                int maxBattleChipCopies = 10;
                int maxNaviChips = 5;
                int maxTotalChipsInFolder = 30;

                if (isBattleChip && currentChipCopies >= maxBattleChipCopies)
                {
                    string chipName = BattleChipData.GetChipNameByID(BattleChipData.BN1ChipNameMap, chipID).Name;
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
                    saveData.FolderData.Add(new Tuple<int, int>(chipID, (chipCode[0] - 'A')));

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
            List<byte> newBattleChips = new List<byte>(Enumerable.Repeat((byte)0, 147 * 5));
            List<byte> newNaviChips = new List<byte>(Enumerable.Repeat((byte)0, 239));

            dgvPack.Sort(dgvPack.Columns[0], ListSortDirection.Ascending); // Sort by ID column in ascending order

            int codeSeries = 0;

            foreach (DataGridViewRow row in dgvPack.Rows)
            {
                if (row.Cells["ID"].Value != null && row.Cells["Quantity"].Value != null)
                {
                    int chipID = (int)row.Cells["ID"].Value;
                    int quantity = (int)row.Cells["Quantity"].Value;

                    quantity = Math.Max(0, Math.Min(quantity, 99));

                    if (chipID >= 1 && chipID <= 147)
                    {
                        int index = ((chipID - 1) * 5) + codeSeries;
                            newBattleChips[index] = (byte)quantity;
                        codeSeries = (codeSeries + 1) % 5;
                    }
                    else if (chipID >= 148 && chipID <= 239)
                    {
                        newNaviChips[chipID - 148] = (byte)quantity;
                    }
                }
            }

            saveData.BattleChips = newBattleChips;
            saveData.NaviChips = newNaviChips;
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
            openFile.Filter = "MMBN1 Save File|exe1_save_0.bin|All Files|*.*";
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SaveParse saveParse = new SaveParse(openFile.FileName);
                    saveData = saveParse.ExtractSaveData();
                    BattleChipData battleChipData = new BattleChipData();
                    List<BattleChipData> bChips = battleChipData.GenerateChipEntries();
                    PopulateDataGridView(battleChipData, saveData);
                    LoadFolderData(saveData);
                    maxHPStat.Value = saveData.MaxHP;
                    attackStat.Value = saveData.AttackPower + 1;
                    rapidStat.Value = saveData.RapidPower + 1;
                    chargeStat.Value = saveData.ChargePower + 1;
                    zennyBox.Value = saveData.Zenny;
                    steamID.Value = saveData.SteamID;
                    LoadStyles(saveData);
                    
                    //Show the current game loaded
                    lblGameVersion.Text = $"Loaded: {saveData.GameName.GetString()}";
                    DisplayModulesBasedOnGame();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex}");
                }
            }
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
            saveFile.FileName = "exe1_save_0.bin";
            saveFile.Filter = "MMBN1 Save File|exe1_save_0.bin|AllFiles|*.*";
            saveFile.RestoreDirectory = true;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SaveParse bn1SaveParse = new SaveParse(saveFile.FileName);

                    saveData.MaxHP = (short)maxHPStat.Value;
                    saveData.CurrHP = (short)maxHPStat.Value;
                    saveData.AttackPower = (byte)(attackStat.Value - 1);
                    saveData.RapidPower = (byte)(rapidStat.Value - 1);
                    saveData.ChargePower = (byte)(chargeStat.Value - 1);
                    saveData.Zenny = (int)zennyBox.Value;
                    saveData.SteamID = (int)steamID.Value;
                    UpdateStyles(saveData);
                    PackageChips();
                    bn1SaveParse.UpdateSaveData(saveData);
                    bn1SaveParse.SaveChanges();

                    MessageBox.Show("Save data successfully updated!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving the file: {ex.Message}");
                }
            }
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
                                        if (style.Equip.Value)
                                        {
                                            saveData.EqStyle = 0;
                                        }
                                        break;
                                    }
                                case Style.Value.Heat:
                                    {
                                        if (style.Equip.Value)
                                        {
                                            saveData.EqStyle = 2;
                                        }

                                        saveData.Style1 = style.Add.ToByte();
                                        break;
                                    }
                                case Style.Value.Aqua:
                                    {
                                        if (style.Equip.Value)
                                        {
                                            saveData.EqStyle = 3;
                                        }

                                        saveData.Style2 = style.Add.ToByte();
                                        break;
                                    }
                                case Style.Value.Wood:
                                    {
                                        if (style.Equip.Value)
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
                    tabsFolders.TabPages.Remove(tabPage_Folder2);
                    tabsFolders.TabPages.Remove(tabPage_Folder3);
                    btnSelectStyles.Enabled = true;
                    break;
                case GameTitle.Title.MegaManBattleNetwork2:
                    tabsFolders.TabPages.Insert(1,tabPage_Folder2);
                    tabsFolders.TabPages.Insert(2,tabPage_Folder3);
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
            var styleLoader = new StyleLoader(_styles);
            if (styleLoader.ShowDialog() == DialogResult.OK)
            {
                _styles = styleLoader._styles;
            }
        }
    }
}
