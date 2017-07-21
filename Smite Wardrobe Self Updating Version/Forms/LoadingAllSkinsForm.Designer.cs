namespace Smite_Wardrobe_Self_Updating_Version.Forms
{
    partial class LoadingAllSkinsForm
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
            this.ProgressBar_LoadingSkins = new System.Windows.Forms.ProgressBar();
            this.Label_Parsing = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ProgressBar_LoadingSkins
            // 
            this.ProgressBar_LoadingSkins.Location = new System.Drawing.Point(12, 12);
            this.ProgressBar_LoadingSkins.MarqueeAnimationSpeed = 1;
            this.ProgressBar_LoadingSkins.Name = "ProgressBar_LoadingSkins";
            this.ProgressBar_LoadingSkins.Size = new System.Drawing.Size(191, 23);
            this.ProgressBar_LoadingSkins.TabIndex = 0;
            // 
            // Label_Parsing
            // 
            this.Label_Parsing.AutoSize = true;
            this.Label_Parsing.Location = new System.Drawing.Point(9, 42);
            this.Label_Parsing.Name = "Label_Parsing";
            this.Label_Parsing.Size = new System.Drawing.Size(51, 13);
            this.Label_Parsing.TabIndex = 1;
            this.Label_Parsing.Text = "Loading: ";
            // 
            // LoadingAllSkinsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 64);
            this.Controls.Add(this.Label_Parsing);
            this.Controls.Add(this.ProgressBar_LoadingSkins);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoadingAllSkinsForm";
            this.Text = "Loading All Owned Skins...";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBar_LoadingSkins;
        private System.Windows.Forms.Label Label_Parsing;
    }
}