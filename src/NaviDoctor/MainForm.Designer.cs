
namespace NaviDoctor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.attackStat = new System.Windows.Forms.NumericUpDown();
            this.rapidStat = new System.Windows.Forms.NumericUpDown();
            this.chargeStat = new System.Windows.Forms.NumericUpDown();
            this.normalArmorRadio = new System.Windows.Forms.RadioButton();
            this.fireArmorRadio = new System.Windows.Forms.RadioButton();
            this.aquaArmorRadio = new System.Windows.Forms.RadioButton();
            this.woodArmorRadio = new System.Windows.Forms.RadioButton();
            this.haveFireArmor = new System.Windows.Forms.CheckBox();
            this.haveAquaArmor = new System.Windows.Forms.CheckBox();
            this.haveWoodArmor = new System.Windows.Forms.CheckBox();
            this.zennyBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvPack = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddChip = new System.Windows.Forms.Button();
            this.btnRemoveChip = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.maxHPStat = new System.Windows.Forms.NumericUpDown();
            this.steamID = new System.Windows.Forms.NumericUpDown();
            this.btnShowLibrary = new System.Windows.Forms.Button();
            this.btnSetPackQuantity = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabsFolders = new System.Windows.Forms.TabControl();
            this.tabPage_Folder1 = new System.Windows.Forms.TabPage();
            this.tabPage_Folder2 = new System.Windows.Forms.TabPage();
            this.tabPage_Folder3 = new System.Windows.Forms.TabPage();
            this.dgvFolder1 = new System.Windows.Forms.DataGridView();
            this.lblFolderCount = new System.Windows.Forms.Label();
            this.nudPackQuantity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.attackStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rapidStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chargeStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zennyBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxHPStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.steamID)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.tabsFolders.SuspendLayout();
            this.tabPage_Folder1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolder1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPackQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mega Man.EXE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Attack";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rapid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Charge";
            // 
            // attackStat
            // 
            this.attackStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attackStat.Location = new System.Drawing.Point(89, 106);
            this.attackStat.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.attackStat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.attackStat.Name = "attackStat";
            this.attackStat.Size = new System.Drawing.Size(54, 23);
            this.attackStat.TabIndex = 3;
            this.attackStat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rapidStat
            // 
            this.rapidStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rapidStat.Location = new System.Drawing.Point(89, 144);
            this.rapidStat.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.rapidStat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rapidStat.Name = "rapidStat";
            this.rapidStat.Size = new System.Drawing.Size(54, 23);
            this.rapidStat.TabIndex = 3;
            this.rapidStat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chargeStat
            // 
            this.chargeStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chargeStat.Location = new System.Drawing.Point(89, 180);
            this.chargeStat.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.chargeStat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.chargeStat.Name = "chargeStat";
            this.chargeStat.Size = new System.Drawing.Size(54, 23);
            this.chargeStat.TabIndex = 3;
            this.chargeStat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // normalArmorRadio
            // 
            this.normalArmorRadio.AutoSize = true;
            this.normalArmorRadio.Checked = true;
            this.normalArmorRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.normalArmorRadio.Location = new System.Drawing.Point(89, 219);
            this.normalArmorRadio.Name = "normalArmorRadio";
            this.normalArmorRadio.Size = new System.Drawing.Size(113, 21);
            this.normalArmorRadio.TabIndex = 4;
            this.normalArmorRadio.TabStop = true;
            this.normalArmorRadio.Text = "Normal Armor";
            this.normalArmorRadio.UseVisualStyleBackColor = true;
            // 
            // fireArmorRadio
            // 
            this.fireArmorRadio.AutoSize = true;
            this.fireArmorRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fireArmorRadio.Location = new System.Drawing.Point(89, 254);
            this.fireArmorRadio.Name = "fireArmorRadio";
            this.fireArmorRadio.Size = new System.Drawing.Size(98, 21);
            this.fireArmorRadio.TabIndex = 4;
            this.fireArmorRadio.Text = "Heat Armor";
            this.fireArmorRadio.UseVisualStyleBackColor = true;
            // 
            // aquaArmorRadio
            // 
            this.aquaArmorRadio.AutoSize = true;
            this.aquaArmorRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aquaArmorRadio.Location = new System.Drawing.Point(89, 289);
            this.aquaArmorRadio.Name = "aquaArmorRadio";
            this.aquaArmorRadio.Size = new System.Drawing.Size(101, 21);
            this.aquaArmorRadio.TabIndex = 4;
            this.aquaArmorRadio.Text = "Aqua Armor";
            this.aquaArmorRadio.UseVisualStyleBackColor = true;
            // 
            // woodArmorRadio
            // 
            this.woodArmorRadio.AutoSize = true;
            this.woodArmorRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.woodArmorRadio.Location = new System.Drawing.Point(89, 321);
            this.woodArmorRadio.Name = "woodArmorRadio";
            this.woodArmorRadio.Size = new System.Drawing.Size(105, 21);
            this.woodArmorRadio.TabIndex = 4;
            this.woodArmorRadio.Text = "Wood Armor";
            this.woodArmorRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.woodArmorRadio.UseVisualStyleBackColor = true;
            // 
            // haveFireArmor
            // 
            this.haveFireArmor.AutoSize = true;
            this.haveFireArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.haveFireArmor.Location = new System.Drawing.Point(58, 259);
            this.haveFireArmor.Name = "haveFireArmor";
            this.haveFireArmor.Size = new System.Drawing.Size(15, 14);
            this.haveFireArmor.TabIndex = 5;
            this.haveFireArmor.UseVisualStyleBackColor = true;
            // 
            // haveAquaArmor
            // 
            this.haveAquaArmor.AutoSize = true;
            this.haveAquaArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.haveAquaArmor.Location = new System.Drawing.Point(58, 294);
            this.haveAquaArmor.Name = "haveAquaArmor";
            this.haveAquaArmor.Size = new System.Drawing.Size(15, 14);
            this.haveAquaArmor.TabIndex = 5;
            this.haveAquaArmor.UseVisualStyleBackColor = true;
            // 
            // haveWoodArmor
            // 
            this.haveWoodArmor.AutoSize = true;
            this.haveWoodArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.haveWoodArmor.Location = new System.Drawing.Point(58, 326);
            this.haveWoodArmor.Name = "haveWoodArmor";
            this.haveWoodArmor.Size = new System.Drawing.Size(15, 14);
            this.haveWoodArmor.TabIndex = 5;
            this.haveWoodArmor.UseVisualStyleBackColor = true;
            // 
            // zennyBox
            // 
            this.zennyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zennyBox.Location = new System.Drawing.Point(105, 354);
            this.zennyBox.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.zennyBox.Name = "zennyBox";
            this.zennyBox.Size = new System.Drawing.Size(120, 23);
            this.zennyBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 356);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Zenny";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 392);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Steam ID";
            // 
            // dgvPack
            // 
            this.dgvPack.AllowUserToAddRows = false;
            this.dgvPack.AllowUserToDeleteRows = false;
            this.dgvPack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPack.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPack.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPack.Location = new System.Drawing.Point(662, 64);
            this.dgvPack.Name = "dgvPack";
            this.dgvPack.RowHeadersWidth = 62;
            this.dgvPack.RowTemplate.Height = 28;
            this.dgvPack.Size = new System.Drawing.Size(374, 406);
            this.dgvPack.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(658, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 24);
            this.label6.TabIndex = 9;
            this.label6.Text = "Pack";
            // 
            // btnAddChip
            // 
            this.btnAddChip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddChip.Location = new System.Drawing.Point(615, 264);
            this.btnAddChip.Name = "btnAddChip";
            this.btnAddChip.Size = new System.Drawing.Size(27, 54);
            this.btnAddChip.TabIndex = 11;
            this.btnAddChip.Text = "<";
            this.btnAddChip.UseVisualStyleBackColor = true;
            this.btnAddChip.Click += new System.EventHandler(this.btnAddChip_Click);
            // 
            // btnRemoveChip
            // 
            this.btnRemoveChip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveChip.Location = new System.Drawing.Point(615, 182);
            this.btnRemoveChip.Name = "btnRemoveChip";
            this.btnRemoveChip.Size = new System.Drawing.Size(27, 54);
            this.btnRemoveChip.TabIndex = 11;
            this.btnRemoveChip.Text = ">";
            this.btnRemoveChip.UseVisualStyleBackColor = true;
            this.btnRemoveChip.Click += new System.EventHandler(this.btnRemoveChip_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Max HP";
            // 
            // maxHPStat
            // 
            this.maxHPStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxHPStat.Location = new System.Drawing.Point(89, 70);
            this.maxHPStat.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.maxHPStat.Name = "maxHPStat";
            this.maxHPStat.Size = new System.Drawing.Size(100, 23);
            this.maxHPStat.TabIndex = 13;
            // 
            // steamID
            // 
            this.steamID.BackColor = System.Drawing.SystemColors.WindowText;
            this.steamID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.steamID.Location = new System.Drawing.Point(105, 390);
            this.steamID.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.steamID.Name = "steamID";
            this.steamID.Size = new System.Drawing.Size(120, 23);
            this.steamID.TabIndex = 14;
            this.steamID.Enter += new System.EventHandler(this.steamID_Enter);
            this.steamID.Leave += new System.EventHandler(this.steamID_Leave);
            // 
            // btnShowLibrary
            // 
            this.btnShowLibrary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowLibrary.Location = new System.Drawing.Point(662, 490);
            this.btnShowLibrary.Name = "btnShowLibrary";
            this.btnShowLibrary.Size = new System.Drawing.Size(81, 38);
            this.btnShowLibrary.TabIndex = 16;
            this.btnShowLibrary.Text = "Library";
            this.btnShowLibrary.UseVisualStyleBackColor = true;
            this.btnShowLibrary.Click += new System.EventHandler(this.btnShowLibrary_Click);
            // 
            // btnSetPackQuantity
            // 
            this.btnSetPackQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetPackQuantity.Location = new System.Drawing.Point(844, 490);
            this.btnSetPackQuantity.Name = "btnSetPackQuantity";
            this.btnSetPackQuantity.Size = new System.Drawing.Size(132, 38);
            this.btnSetPackQuantity.TabIndex = 17;
            this.btnSetPackQuantity.Text = "Set Pack Quantity";
            this.btnSetPackQuantity.UseVisualStyleBackColor = true;
            this.btnSetPackQuantity.Click += new System.EventHandler(this.btnSetPackQuantity_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1048, 24);
            this.menuStrip.TabIndex = 18;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // tabsFolders
            // 
            this.tabsFolders.Controls.Add(this.tabPage_Folder1);
            this.tabsFolders.Controls.Add(this.tabPage_Folder2);
            this.tabsFolders.Controls.Add(this.tabPage_Folder3);
            this.tabsFolders.Location = new System.Drawing.Point(279, 26);
            this.tabsFolders.Name = "tabsFolders";
            this.tabsFolders.SelectedIndex = 0;
            this.tabsFolders.Size = new System.Drawing.Size(314, 444);
            this.tabsFolders.TabIndex = 19;
            // 
            // tabPage_Folder1
            // 
            this.tabPage_Folder1.Controls.Add(this.dgvFolder1);
            this.tabPage_Folder1.Location = new System.Drawing.Point(4, 33);
            this.tabPage_Folder1.Name = "tabPage_Folder1";
            this.tabPage_Folder1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Folder1.Size = new System.Drawing.Size(306, 407);
            this.tabPage_Folder1.TabIndex = 0;
            this.tabPage_Folder1.Text = "Folder1";
            this.tabPage_Folder1.UseVisualStyleBackColor = true;
            // 
            // tabPage_Folder2
            // 
            this.tabPage_Folder2.Location = new System.Drawing.Point(4, 33);
            this.tabPage_Folder2.Name = "tabPage_Folder2";
            this.tabPage_Folder2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Folder2.Size = new System.Drawing.Size(306, 407);
            this.tabPage_Folder2.TabIndex = 1;
            this.tabPage_Folder2.Text = "Folder2";
            this.tabPage_Folder2.UseVisualStyleBackColor = true;
            // 
            // tabPage_Folder3
            // 
            this.tabPage_Folder3.Location = new System.Drawing.Point(4, 33);
            this.tabPage_Folder3.Name = "tabPage_Folder3";
            this.tabPage_Folder3.Size = new System.Drawing.Size(306, 407);
            this.tabPage_Folder3.TabIndex = 2;
            this.tabPage_Folder3.Text = "Folder3";
            this.tabPage_Folder3.UseVisualStyleBackColor = true;
            // 
            // dgvFolder1
            // 
            this.dgvFolder1.AllowUserToAddRows = false;
            this.dgvFolder1.AllowUserToDeleteRows = false;
            this.dgvFolder1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFolder1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFolder1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFolder1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFolder1.Location = new System.Drawing.Point(3, 3);
            this.dgvFolder1.Name = "dgvFolder1";
            this.dgvFolder1.ReadOnly = true;
            this.dgvFolder1.RowHeadersWidth = 62;
            this.dgvFolder1.RowTemplate.Height = 28;
            this.dgvFolder1.Size = new System.Drawing.Size(300, 401);
            this.dgvFolder1.TabIndex = 11;
            // 
            // lblFolderCount
            // 
            this.lblFolderCount.AutoSize = true;
            this.lblFolderCount.Location = new System.Drawing.Point(282, 473);
            this.lblFolderCount.Name = "lblFolderCount";
            this.lblFolderCount.Size = new System.Drawing.Size(140, 24);
            this.lblFolderCount.TabIndex = 20;
            this.lblFolderCount.Text = "Folder Count: 0";
            // 
            // nudPackQuantity
            // 
            this.nudPackQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPackQuantity.Location = new System.Drawing.Point(982, 499);
            this.nudPackQuantity.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudPackQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPackQuantity.Name = "nudPackQuantity";
            this.nudPackQuantity.Size = new System.Drawing.Size(54, 23);
            this.nudPackQuantity.TabIndex = 21;
            this.nudPackQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 540);
            this.Controls.Add(this.nudPackQuantity);
            this.Controls.Add(this.lblFolderCount);
            this.Controls.Add(this.tabsFolders);
            this.Controls.Add(this.btnSetPackQuantity);
            this.Controls.Add(this.btnShowLibrary);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.steamID);
            this.Controls.Add(this.maxHPStat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnRemoveChip);
            this.Controls.Add(this.btnAddChip);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvPack);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.zennyBox);
            this.Controls.Add(this.haveWoodArmor);
            this.Controls.Add(this.haveAquaArmor);
            this.Controls.Add(this.haveFireArmor);
            this.Controls.Add(this.woodArmorRadio);
            this.Controls.Add(this.aquaArmorRadio);
            this.Controls.Add(this.fireArmorRadio);
            this.Controls.Add(this.normalArmorRadio);
            this.Controls.Add(this.chargeStat);
            this.Controls.Add(this.rapidStat);
            this.Controls.Add(this.attackStat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "NaviDoctor LC";
            ((System.ComponentModel.ISupportInitialize)(this.attackStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rapidStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chargeStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zennyBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxHPStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.steamID)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabsFolders.ResumeLayout(false);
            this.tabPage_Folder1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolder1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPackQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown attackStat;
        private System.Windows.Forms.NumericUpDown rapidStat;
        private System.Windows.Forms.NumericUpDown chargeStat;
        private System.Windows.Forms.RadioButton normalArmorRadio;
        private System.Windows.Forms.RadioButton fireArmorRadio;
        private System.Windows.Forms.RadioButton aquaArmorRadio;
        private System.Windows.Forms.RadioButton woodArmorRadio;
        private System.Windows.Forms.CheckBox haveFireArmor;
        private System.Windows.Forms.CheckBox haveAquaArmor;
        private System.Windows.Forms.CheckBox haveWoodArmor;
        private System.Windows.Forms.NumericUpDown zennyBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvPack;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddChip;
        private System.Windows.Forms.Button btnRemoveChip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown maxHPStat;
        private System.Windows.Forms.NumericUpDown steamID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnShowLibrary;
        private System.Windows.Forms.Button btnSetPackQuantity;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TabControl tabsFolders;
        private System.Windows.Forms.TabPage tabPage_Folder1;
        private System.Windows.Forms.DataGridView dgvFolder1;
        private System.Windows.Forms.TabPage tabPage_Folder2;
        private System.Windows.Forms.TabPage tabPage_Folder3;
        private System.Windows.Forms.Label lblFolderCount;
        private System.Windows.Forms.NumericUpDown nudPackQuantity;
    }
}

