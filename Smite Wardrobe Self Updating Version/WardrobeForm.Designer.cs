namespace Smite_Wardrobe_Self_Updating_Version
{
    partial class WardrobeForm
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
            // flowLayoutPanel1
            // 
            this.WardrobeFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WardrobeFlowLayout.Location = new System.Drawing.Point(0, 0);
            this.WardrobeFlowLayout.Name = "flowLayoutPanel1";
            this.WardrobeFlowLayout.Size = new System.Drawing.Size(499, 375);
            this.WardrobeFlowLayout.TabIndex = 18;
            // 
            // WardrobeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(499, 375);
            this.Controls.Add(this.WardrobeFlowLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "WardrobeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WardrobeForm";
            this.Load += new System.EventHandler(this.WardrobeForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel WardrobeFlowLayout;
    }
}