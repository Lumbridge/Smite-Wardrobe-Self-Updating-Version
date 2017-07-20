namespace Smite_Wardrobe_Self_Updating_Version.Forms
{
    partial class AllSkinsForm
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
            this.WardrobeFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // WardrobeFlowLayout
            // 
            this.WardrobeFlowLayout.AutoScroll = true;
            this.WardrobeFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WardrobeFlowLayout.Location = new System.Drawing.Point(0, 0);
            this.WardrobeFlowLayout.Name = "WardrobeFlowLayout";
            this.WardrobeFlowLayout.Size = new System.Drawing.Size(499, 376);
            this.WardrobeFlowLayout.TabIndex = 19;
            // 
            // AllSkinsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(499, 376);
            this.Controls.Add(this.WardrobeFlowLayout);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AllSkinsForm";
            this.Text = "All Skins";
            this.Load += new System.EventHandler(this.AllSkinsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel WardrobeFlowLayout;
    }
}