
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnLoadFile = new System.Windows.Forms.Button();
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddChip = new System.Windows.Forms.Button();
            this.btnRemoveChip = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.maxHPStat = new System.Windows.Forms.NumericUpDown();
            this.steamID = new System.Windows.Forms.NumericUpDown();
            this.btnShowLibrary = new System.Windows.Forms.Button();
            this.btnSaveGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.attackStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rapidStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chargeStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zennyBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxHPStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.steamID)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadFile.Location = new System.Drawing.Point(12, 501);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(85, 27);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "Load";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mega Man.EXE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Attack";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rapid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Charge";
            // 
            // attackStat
            // 
            this.attackStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attackStat.Location = new System.Drawing.Point(89, 97);
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
            this.attackStat.Size = new System.Drawing.Size(54, 30);
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
            this.rapidStat.Location = new System.Drawing.Point(89, 135);
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
            this.rapidStat.Size = new System.Drawing.Size(54, 30);
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
            this.chargeStat.Location = new System.Drawing.Point(89, 171);
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
            this.chargeStat.Size = new System.Drawing.Size(54, 30);
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
            this.normalArmorRadio.Location = new System.Drawing.Point(89, 210);
            this.normalArmorRadio.Name = "normalArmorRadio";
            this.normalArmorRadio.Size = new System.Drawing.Size(157, 29);
            this.normalArmorRadio.TabIndex = 4;
            this.normalArmorRadio.TabStop = true;
            this.normalArmorRadio.Text = "Normal Armor";
            this.normalArmorRadio.UseVisualStyleBackColor = true;
            // 
            // fireArmorRadio
            // 
            this.fireArmorRadio.AutoSize = true;
            this.fireArmorRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fireArmorRadio.Location = new System.Drawing.Point(89, 245);
            this.fireArmorRadio.Name = "fireArmorRadio";
            this.fireArmorRadio.Size = new System.Drawing.Size(136, 29);
            this.fireArmorRadio.TabIndex = 4;
            this.fireArmorRadio.Text = "Heat Armor";
            this.fireArmorRadio.UseVisualStyleBackColor = true;
            // 
            // aquaArmorRadio
            // 
            this.aquaArmorRadio.AutoSize = true;
            this.aquaArmorRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aquaArmorRadio.Location = new System.Drawing.Point(89, 280);
            this.aquaArmorRadio.Name = "aquaArmorRadio";
            this.aquaArmorRadio.Size = new System.Drawing.Size(142, 29);
            this.aquaArmorRadio.TabIndex = 4;
            this.aquaArmorRadio.Text = "Aqua Armor";
            this.aquaArmorRadio.UseVisualStyleBackColor = true;
            // 
            // woodArmorRadio
            // 
            this.woodArmorRadio.AutoSize = true;
            this.woodArmorRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.woodArmorRadio.Location = new System.Drawing.Point(89, 312);
            this.woodArmorRadio.Name = "woodArmorRadio";
            this.woodArmorRadio.Size = new System.Drawing.Size(148, 29);
            this.woodArmorRadio.TabIndex = 4;
            this.woodArmorRadio.Text = "Wood Armor";
            this.woodArmorRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.woodArmorRadio.UseVisualStyleBackColor = true;
            // 
            // haveFireArmor
            // 
            this.haveFireArmor.AutoSize = true;
            this.haveFireArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.haveFireArmor.Location = new System.Drawing.Point(58, 250);
            this.haveFireArmor.Name = "haveFireArmor";
            this.haveFireArmor.Size = new System.Drawing.Size(22, 21);
            this.haveFireArmor.TabIndex = 5;
            this.haveFireArmor.UseVisualStyleBackColor = true;
            // 
            // haveAquaArmor
            // 
            this.haveAquaArmor.AutoSize = true;
            this.haveAquaArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.haveAquaArmor.Location = new System.Drawing.Point(58, 285);
            this.haveAquaArmor.Name = "haveAquaArmor";
            this.haveAquaArmor.Size = new System.Drawing.Size(22, 21);
            this.haveAquaArmor.TabIndex = 5;
            this.haveAquaArmor.UseVisualStyleBackColor = true;
            // 
            // haveWoodArmor
            // 
            this.haveWoodArmor.AutoSize = true;
            this.haveWoodArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.haveWoodArmor.Location = new System.Drawing.Point(58, 317);
            this.haveWoodArmor.Name = "haveWoodArmor";
            this.haveWoodArmor.Size = new System.Drawing.Size(22, 21);
            this.haveWoodArmor.TabIndex = 5;
            this.haveWoodArmor.UseVisualStyleBackColor = true;
            // 
            // zennyBox
            // 
            this.zennyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zennyBox.Location = new System.Drawing.Point(105, 345);
            this.zennyBox.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.zennyBox.Name = "zennyBox";
            this.zennyBox.Size = new System.Drawing.Size(120, 30);
            this.zennyBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Zenny";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 383);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 25);
            this.label9.TabIndex = 15;
            this.label9.Text = "Steam ID";
            this.toolTip1.SetToolTip(this.label9, resources.GetString("label9.ToolTip"));
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(662, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(374, 406);
            this.dataGridView1.TabIndex = 8;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.Location = new System.Drawing.Point(308, 53);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(283, 406);
            this.dataGridView2.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(656, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 33);
            this.label6.TabIndex = 9;
            this.label6.Text = "Pack";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(302, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 33);
            this.label7.TabIndex = 10;
            this.label7.Text = "Folder";
            // 
            // btnAddChip
            // 
            this.btnAddChip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddChip.Location = new System.Drawing.Point(615, 255);
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
            this.btnRemoveChip.Location = new System.Drawing.Point(615, 173);
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
            this.label8.Location = new System.Drawing.Point(12, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 25);
            this.label8.TabIndex = 12;
            this.label8.Text = "Max HP";
            // 
            // maxHPStat
            // 
            this.maxHPStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxHPStat.Location = new System.Drawing.Point(89, 61);
            this.maxHPStat.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.maxHPStat.Name = "maxHPStat";
            this.maxHPStat.Size = new System.Drawing.Size(100, 30);
            this.maxHPStat.TabIndex = 13;
            // 
            // steamID
            // 
            this.steamID.BackColor = System.Drawing.SystemColors.WindowText;
            this.steamID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.steamID.Location = new System.Drawing.Point(105, 381);
            this.steamID.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.steamID.Name = "steamID";
            this.steamID.Size = new System.Drawing.Size(120, 30);
            this.steamID.TabIndex = 14;
            this.steamID.Enter += new System.EventHandler(this.steamID_Enter);
            this.steamID.Leave += new System.EventHandler(this.steamID_Leave);
            // 
            // btnShowLibrary
            // 
            this.btnShowLibrary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowLibrary.Location = new System.Drawing.Point(794, 490);
            this.btnShowLibrary.Name = "btnShowLibrary";
            this.btnShowLibrary.Size = new System.Drawing.Size(126, 38);
            this.btnShowLibrary.TabIndex = 16;
            this.btnShowLibrary.Text = "Library";
            this.btnShowLibrary.UseVisualStyleBackColor = true;
            this.btnShowLibrary.Click += new System.EventHandler(this.btnShowLibrary_Click);
            // 
            // btnSaveGame
            // 
            this.btnSaveGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveGame.Location = new System.Drawing.Point(177, 501);
            this.btnSaveGame.Name = "btnSaveGame";
            this.btnSaveGame.Size = new System.Drawing.Size(85, 27);
            this.btnSaveGame.TabIndex = 0;
            this.btnSaveGame.Text = "Save";
            this.btnSaveGame.UseVisualStyleBackColor = true;
            this.btnSaveGame.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 540);
            this.Controls.Add(this.btnShowLibrary);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.steamID);
            this.Controls.Add(this.maxHPStat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnRemoveChip);
            this.Controls.Add(this.btnAddChip);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
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
            this.Controls.Add(this.btnSaveGame);
            this.Controls.Add(this.btnLoadFile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "NaviDoctor LC";
            ((System.ComponentModel.ISupportInitialize)(this.attackStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rapidStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chargeStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zennyBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxHPStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.steamID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadFile;
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
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddChip;
        private System.Windows.Forms.Button btnRemoveChip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown maxHPStat;
        private System.Windows.Forms.NumericUpDown steamID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnShowLibrary;
        private System.Windows.Forms.Button btnSaveGame;
    }
}

