﻿namespace NaviDoctor.customControls
{
    partial class StyleSelect
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxAddStyle = new System.Windows.Forms.CheckBox();
            this.radEquipStyle = new System.Windows.Forms.RadioButton();
            this.nudVersion = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudVersion)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxAddStyle
            // 
            this.cbxAddStyle.AutoSize = true;
            this.cbxAddStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbxAddStyle.Location = new System.Drawing.Point(20, 5);
            this.cbxAddStyle.Name = "cbxAddStyle";
            this.cbxAddStyle.Size = new System.Drawing.Size(15, 14);
            this.cbxAddStyle.TabIndex = 0;
            this.cbxAddStyle.UseVisualStyleBackColor = true;
            // 
            // radEquipStyle
            // 
            this.radEquipStyle.AutoSize = true;
            this.radEquipStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radEquipStyle.Location = new System.Drawing.Point(76, 1);
            this.radEquipStyle.Name = "radEquipStyle";
            this.radEquipStyle.Size = new System.Drawing.Size(98, 21);
            this.radEquipStyle.TabIndex = 1;
            this.radEquipStyle.Text = "Style Name";
            this.radEquipStyle.UseVisualStyleBackColor = true;
            // 
            // nudVersion
            // 
            this.nudVersion.Location = new System.Drawing.Point(223, 3);
            this.nudVersion.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudVersion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudVersion.Name = "nudVersion";
            this.nudVersion.Size = new System.Drawing.Size(37, 20);
            this.nudVersion.TabIndex = 2;
            this.nudVersion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // StyleSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudVersion);
            this.Controls.Add(this.radEquipStyle);
            this.Controls.Add(this.cbxAddStyle);
            this.Name = "StyleSelect";
            this.Size = new System.Drawing.Size(260, 25);
            ((System.ComponentModel.ISupportInitialize)(this.nudVersion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxAddStyle;
        private System.Windows.Forms.RadioButton radEquipStyle;
        private System.Windows.Forms.NumericUpDown nudVersion;
    }
}
