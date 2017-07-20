namespace Smite_Wardrobe_Self_Updating_Version.Forms
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
            this.leftGodPictureBox = new System.Windows.Forms.PictureBox();
            this.rightGodPictureBox = new System.Windows.Forms.PictureBox();
            this.godNameLabel = new System.Windows.Forms.Label();
            this.godPantheonLabel = new System.Windows.Forms.Label();
            this.godAttackTypeLabel = new System.Windows.Forms.Label();
            this.godPowerTypeLabel = new System.Windows.Forms.Label();
            this.godClassLabel = new System.Windows.Forms.Label();
            this.godFavorCostLabel = new System.Windows.Forms.Label();
            this.godGemsCostLabel = new System.Windows.Forms.Label();
            this.godReleaseDateLabel = new System.Windows.Forms.Label();
            this.viewSkinsButton = new System.Windows.Forms.Button();
            this.Button_Save = new System.Windows.Forms.Button();
            this.Button_Load = new System.Windows.Forms.Button();
            this.Button_ShowAllSkins = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.godSelectedPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftGodPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightGodPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // godSelectedPicBox
            // 
            this.godSelectedPicBox.Location = new System.Drawing.Point(125, 12);
            this.godSelectedPicBox.Name = "godSelectedPicBox";
            this.godSelectedPicBox.Size = new System.Drawing.Size(250, 333);
            this.godSelectedPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.godSelectedPicBox.TabIndex = 0;
            this.godSelectedPicBox.TabStop = false;
            // 
            // godSelectionLeftButton
            // 
            this.godSelectionLeftButton.Location = new System.Drawing.Point(125, 351);
            this.godSelectionLeftButton.Name = "godSelectionLeftButton";
            this.godSelectionLeftButton.Size = new System.Drawing.Size(75, 23);
            this.godSelectionLeftButton.TabIndex = 1;
            this.godSelectionLeftButton.Text = "<<";
            this.godSelectionLeftButton.UseVisualStyleBackColor = true;
            this.godSelectionLeftButton.Click += new System.EventHandler(this.godSelectionLeftButton_Click);
            // 
            // godSelectionRightButton
            // 
            this.godSelectionRightButton.Location = new System.Drawing.Point(299, 351);
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
            this.godSelectionComboBox.Location = new System.Drawing.Point(125, 380);
            this.godSelectionComboBox.Name = "godSelectionComboBox";
            this.godSelectionComboBox.Size = new System.Drawing.Size(250, 21);
            this.godSelectionComboBox.TabIndex = 3;
            this.godSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.godSelectionComboBox_SelectedIndexChanged);
            // 
            // leftGodPictureBox
            // 
            this.leftGodPictureBox.Location = new System.Drawing.Point(12, 26);
            this.leftGodPictureBox.Name = "leftGodPictureBox";
            this.leftGodPictureBox.Size = new System.Drawing.Size(220, 303);
            this.leftGodPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.leftGodPictureBox.TabIndex = 4;
            this.leftGodPictureBox.TabStop = false;
            // 
            // rightGodPictureBox
            // 
            this.rightGodPictureBox.Location = new System.Drawing.Point(272, 26);
            this.rightGodPictureBox.Name = "rightGodPictureBox";
            this.rightGodPictureBox.Size = new System.Drawing.Size(220, 303);
            this.rightGodPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rightGodPictureBox.TabIndex = 5;
            this.rightGodPictureBox.TabStop = false;
            // 
            // godNameLabel
            // 
            this.godNameLabel.AutoSize = true;
            this.godNameLabel.Location = new System.Drawing.Point(121, 404);
            this.godNameLabel.Name = "godNameLabel";
            this.godNameLabel.Size = new System.Drawing.Size(79, 13);
            this.godNameLabel.TabIndex = 6;
            this.godNameLabel.Text = "godNameLabel";
            // 
            // godPantheonLabel
            // 
            this.godPantheonLabel.AutoSize = true;
            this.godPantheonLabel.Location = new System.Drawing.Point(121, 417);
            this.godPantheonLabel.Name = "godPantheonLabel";
            this.godPantheonLabel.Size = new System.Drawing.Size(97, 13);
            this.godPantheonLabel.TabIndex = 7;
            this.godPantheonLabel.Text = "godPantheonLabel";
            // 
            // godAttackTypeLabel
            // 
            this.godAttackTypeLabel.AutoSize = true;
            this.godAttackTypeLabel.Location = new System.Drawing.Point(121, 430);
            this.godAttackTypeLabel.Name = "godAttackTypeLabel";
            this.godAttackTypeLabel.Size = new System.Drawing.Size(106, 13);
            this.godAttackTypeLabel.TabIndex = 8;
            this.godAttackTypeLabel.Text = "godAttackTypeLabel";
            // 
            // godPowerTypeLabel
            // 
            this.godPowerTypeLabel.AutoSize = true;
            this.godPowerTypeLabel.Location = new System.Drawing.Point(121, 443);
            this.godPowerTypeLabel.Name = "godPowerTypeLabel";
            this.godPowerTypeLabel.Size = new System.Drawing.Size(105, 13);
            this.godPowerTypeLabel.TabIndex = 9;
            this.godPowerTypeLabel.Text = "godPowerTypeLabel";
            // 
            // godClassLabel
            // 
            this.godClassLabel.AutoSize = true;
            this.godClassLabel.Location = new System.Drawing.Point(121, 456);
            this.godClassLabel.Name = "godClassLabel";
            this.godClassLabel.Size = new System.Drawing.Size(76, 13);
            this.godClassLabel.TabIndex = 10;
            this.godClassLabel.Text = "godClassLabel";
            // 
            // godFavorCostLabel
            // 
            this.godFavorCostLabel.AutoSize = true;
            this.godFavorCostLabel.Location = new System.Drawing.Point(121, 469);
            this.godFavorCostLabel.Name = "godFavorCostLabel";
            this.godFavorCostLabel.Size = new System.Drawing.Size(99, 13);
            this.godFavorCostLabel.TabIndex = 11;
            this.godFavorCostLabel.Text = "godFavorCostLabel";
            // 
            // godGemsCostLabel
            // 
            this.godGemsCostLabel.AutoSize = true;
            this.godGemsCostLabel.Location = new System.Drawing.Point(121, 482);
            this.godGemsCostLabel.Name = "godGemsCostLabel";
            this.godGemsCostLabel.Size = new System.Drawing.Size(99, 13);
            this.godGemsCostLabel.TabIndex = 12;
            this.godGemsCostLabel.Text = "godGemsCostLabel";
            // 
            // godReleaseDateLabel
            // 
            this.godReleaseDateLabel.AutoSize = true;
            this.godReleaseDateLabel.Location = new System.Drawing.Point(122, 495);
            this.godReleaseDateLabel.Name = "godReleaseDateLabel";
            this.godReleaseDateLabel.Size = new System.Drawing.Size(113, 13);
            this.godReleaseDateLabel.TabIndex = 13;
            this.godReleaseDateLabel.Text = "godReleaseDateLabel";
            // 
            // viewSkinsButton
            // 
            this.viewSkinsButton.Location = new System.Drawing.Point(212, 351);
            this.viewSkinsButton.Name = "viewSkinsButton";
            this.viewSkinsButton.Size = new System.Drawing.Size(75, 23);
            this.viewSkinsButton.TabIndex = 14;
            this.viewSkinsButton.Text = "View Skins";
            this.viewSkinsButton.UseVisualStyleBackColor = true;
            this.viewSkinsButton.Click += new System.EventHandler(this.viewSkinsButton_Click);
            // 
            // Button_Save
            // 
            this.Button_Save.Location = new System.Drawing.Point(12, 451);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(75, 23);
            this.Button_Save.TabIndex = 15;
            this.Button_Save.Text = "Save";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Button_Load
            // 
            this.Button_Load.Location = new System.Drawing.Point(12, 480);
            this.Button_Load.Name = "Button_Load";
            this.Button_Load.Size = new System.Drawing.Size(75, 23);
            this.Button_Load.TabIndex = 16;
            this.Button_Load.Text = "Load";
            this.Button_Load.UseVisualStyleBackColor = true;
            this.Button_Load.Click += new System.EventHandler(this.Button_Load_Click);
            // 
            // Button_ShowAllSkins
            // 
            this.Button_ShowAllSkins.Location = new System.Drawing.Point(408, 470);
            this.Button_ShowAllSkins.Name = "Button_ShowAllSkins";
            this.Button_ShowAllSkins.Size = new System.Drawing.Size(84, 36);
            this.Button_ShowAllSkins.TabIndex = 15;
            this.Button_ShowAllSkins.Text = "Show All Owned Skins";
            this.Button_ShowAllSkins.UseVisualStyleBackColor = true;
            this.Button_ShowAllSkins.Click += new System.EventHandler(this.Button_ShowAllSkins_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 518);
            this.Controls.Add(this.Button_Load);
            this.Controls.Add(this.Button_ShowAllSkins);
            this.Controls.Add(this.Button_Save);
            this.Controls.Add(this.viewSkinsButton);
            this.Controls.Add(this.godReleaseDateLabel);
            this.Controls.Add(this.godGemsCostLabel);
            this.Controls.Add(this.godFavorCostLabel);
            this.Controls.Add(this.godClassLabel);
            this.Controls.Add(this.godPowerTypeLabel);
            this.Controls.Add(this.godAttackTypeLabel);
            this.Controls.Add(this.godPantheonLabel);
            this.Controls.Add(this.godNameLabel);
            this.Controls.Add(this.godSelectionComboBox);
            this.Controls.Add(this.godSelectionRightButton);
            this.Controls.Add(this.godSelectionLeftButton);
            this.Controls.Add(this.godSelectedPicBox);
            this.Controls.Add(this.leftGodPictureBox);
            this.Controls.Add(this.rightGodPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.godSelectedPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftGodPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightGodPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox godSelectedPicBox;
        private System.Windows.Forms.Button godSelectionLeftButton;
        private System.Windows.Forms.Button godSelectionRightButton;
        private System.Windows.Forms.PictureBox leftGodPictureBox;
        private System.Windows.Forms.PictureBox rightGodPictureBox;
        private System.Windows.Forms.Label godNameLabel;
        private System.Windows.Forms.Label godPantheonLabel;
        private System.Windows.Forms.Label godAttackTypeLabel;
        private System.Windows.Forms.Label godPowerTypeLabel;
        private System.Windows.Forms.Label godClassLabel;
        private System.Windows.Forms.Label godFavorCostLabel;
        private System.Windows.Forms.Label godGemsCostLabel;
        private System.Windows.Forms.Label godReleaseDateLabel;
        private System.Windows.Forms.Button viewSkinsButton;
        public System.Windows.Forms.ComboBox godSelectionComboBox;
        private System.Windows.Forms.Button Button_Save;
        private System.Windows.Forms.Button Button_Load;
        private System.Windows.Forms.Button Button_ShowAllSkins;
    }
}

