namespace NaviDoctor.customControls
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
            // StyleSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radEquipStyle);
            this.Controls.Add(this.cbxAddStyle);
            this.Name = "StyleSelect";
            this.Size = new System.Drawing.Size(206, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxAddStyle;
        private System.Windows.Forms.RadioButton radEquipStyle;
    }
}
