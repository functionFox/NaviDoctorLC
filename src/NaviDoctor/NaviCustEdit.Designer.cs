
namespace NaviDoctor
{
    partial class NaviCustEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NaviCustEdit));
            this.imgCustGrid = new System.Windows.Forms.PictureBox();
            this.imgRunLine = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgCustGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRunLine)).BeginInit();
            this.SuspendLayout();
            // 
            // imgCustGrid
            // 
            this.imgCustGrid.Image = ((System.Drawing.Image)(resources.GetObject("imgCustGrid.Image")));
            this.imgCustGrid.Location = new System.Drawing.Point(23, 11);
            this.imgCustGrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.imgCustGrid.Name = "imgCustGrid";
            this.imgCustGrid.Size = new System.Drawing.Size(599, 375);
            this.imgCustGrid.TabIndex = 0;
            this.imgCustGrid.TabStop = false;
            // 
            // imgRunLine
            // 
            this.imgRunLine.BackColor = System.Drawing.Color.Transparent;
            this.imgRunLine.Image = ((System.Drawing.Image)(resources.GetObject("imgRunLine.Image")));
            this.imgRunLine.Location = new System.Drawing.Point(76, 149);
            this.imgRunLine.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.imgRunLine.Name = "imgRunLine";
            this.imgRunLine.Size = new System.Drawing.Size(450, 75);
            this.imgRunLine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRunLine.TabIndex = 1;
            this.imgRunLine.TabStop = false;
            // 
            // NaviCustEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 619);
            this.Controls.Add(this.imgRunLine);
            this.Controls.Add(this.imgCustGrid);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "NaviCustEdit";
            this.Text = "NaviCust Editor";
            ((System.ComponentModel.ISupportInitialize)(this.imgCustGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRunLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgCustGrid;
        private System.Windows.Forms.PictureBox imgRunLine;
    }
}