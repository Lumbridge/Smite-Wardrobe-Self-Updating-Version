namespace Smite_Wardrobe_Self_Updating_Version
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
            this.godSelectedPicBox = new System.Windows.Forms.PictureBox();
            this.godSelectionLeftButton = new System.Windows.Forms.Button();
            this.godSelectionRightButton = new System.Windows.Forms.Button();
            this.godSelectionComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.godSelectedPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // godSelectedPicBox
            // 
            this.godSelectedPicBox.Location = new System.Drawing.Point(12, 12);
            this.godSelectedPicBox.Name = "godSelectedPicBox";
            this.godSelectedPicBox.Size = new System.Drawing.Size(250, 333);
            this.godSelectedPicBox.TabIndex = 0;
            this.godSelectedPicBox.TabStop = false;
            // 
            // godSelectionLeftButton
            // 
            this.godSelectionLeftButton.Location = new System.Drawing.Point(12, 351);
            this.godSelectionLeftButton.Name = "godSelectionLeftButton";
            this.godSelectionLeftButton.Size = new System.Drawing.Size(75, 23);
            this.godSelectionLeftButton.TabIndex = 1;
            this.godSelectionLeftButton.Text = "<<";
            this.godSelectionLeftButton.UseVisualStyleBackColor = true;
            this.godSelectionLeftButton.Click += new System.EventHandler(this.godSelectionLeftButton_Click);
            // 
            // godSelectionRightButton
            // 
            this.godSelectionRightButton.Location = new System.Drawing.Point(187, 351);
            this.godSelectionRightButton.Name = "godSelectionRightButton";
            this.godSelectionRightButton.Size = new System.Drawing.Size(75, 23);
            this.godSelectionRightButton.TabIndex = 2;
            this.godSelectionRightButton.Text = ">>";
            this.godSelectionRightButton.UseVisualStyleBackColor = true;
            this.godSelectionRightButton.Click += new System.EventHandler(this.godSelectionRightButton_Click);
            // 
            // godSelectionComboBox
            // 
            this.godSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.godSelectionComboBox.FormattingEnabled = true;
            this.godSelectionComboBox.Location = new System.Drawing.Point(12, 380);
            this.godSelectionComboBox.Name = "godSelectionComboBox";
            this.godSelectionComboBox.Size = new System.Drawing.Size(250, 21);
            this.godSelectionComboBox.TabIndex = 3;
            this.godSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.godSelectionComboBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 482);
            this.Controls.Add(this.godSelectionComboBox);
            this.Controls.Add(this.godSelectionRightButton);
            this.Controls.Add(this.godSelectionLeftButton);
            this.Controls.Add(this.godSelectedPicBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.godSelectedPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox godSelectedPicBox;
        private System.Windows.Forms.Button godSelectionLeftButton;
        private System.Windows.Forms.Button godSelectionRightButton;
        private System.Windows.Forms.ComboBox godSelectionComboBox;
    }
}

