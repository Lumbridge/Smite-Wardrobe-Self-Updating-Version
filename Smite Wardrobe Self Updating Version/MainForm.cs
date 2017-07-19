using System;
using System.Windows.Forms;

using Smite_Wardrobe_Self_Updating_Version.Classes;
using static Smite_Wardrobe_Self_Updating_Version.Classes.Common;

namespace Smite_Wardrobe_Self_Updating_Version
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Create the loading form instance
            Loading_Form l = new Loading_Form();
            l.ShowDialog();

            // check that all gods have been parsed by the parser
            if (GodsParsed < GodList.Count)
            {
                MessageBox.Show("Could not parse all skins, exitting.");
                Application.Exit();
            }

            // add all gods to god selection combo box
            foreach (var g in GodList)
                godSelectionComboBox.Items.Add(g.Name);

            // set a selected index
            godSelectionComboBox.SelectedIndex = 0;

            // update the god information labels
            UpdateLabels(GodList[0]);
        }

        private void viewSkinsButton_Click(object sender, EventArgs e)
        {
            WardrobeForm wf = new WardrobeForm(this);
            wf.ShowDialog();
        }

        private void godSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedGodIndex = godSelectionComboBox.SelectedIndex;

            if (SelectedGodIndex == 0)
                SelectedLeft = GodList.Count - 1;
            else
                SelectedLeft = SelectedGodIndex - 1;

            if (SelectedGodIndex == GodList.Count - 1)
                SelectedRight = 0;
            else
                SelectedRight = SelectedGodIndex + 1;

            leftGodPictureBox.Load(GodList[SelectedLeft].Skins[0].ImageLink);
            godSelectedPicBox.Load(GodList[SelectedGodIndex].Skins[0].ImageLink);
            rightGodPictureBox.Load(GodList[SelectedRight].Skins[0].ImageLink);

            UpdateLabels(GodList[godSelectionComboBox.SelectedIndex]);
        }

        private void godSelectionLeftButton_Click(object sender, EventArgs e)
        {
            SelectedGodIndex--;
            if (SelectedGodIndex < 0)
                SelectedGodIndex = GodList.Count - 1;

            godSelectionComboBox.SelectedIndex = SelectedGodIndex;

            UpdateLabels(GodList[godSelectionComboBox.SelectedIndex]);
        }

        private void godSelectionRightButton_Click(object sender, EventArgs e)
        {
            SelectedGodIndex++;
            if (SelectedGodIndex > GodList.Count - 1)
                SelectedGodIndex = 0;

            godSelectionComboBox.SelectedIndex = SelectedGodIndex;

            UpdateLabels(GodList[godSelectionComboBox.SelectedIndex]);
        }

        private void UpdateLabels(God g)
        {
            godNameLabel.Text = "Name: " + g.Name;
            godPantheonLabel.Text = "Pantheon: " + g.Pantheon;
            godAttackTypeLabel.Text = "Attack Type: " + g.AttackType;
            godPowerTypeLabel.Text = "Power Type: " + g.PowerType;
            godClassLabel.Text = "Class: " + g.Class;
            godFavorCostLabel.Text = "Favor Cost: " + g.FavourCost;
            godGemsCostLabel.Text = "Gems Cost: " + g.GemCost;
            godReleaseDateLabel.Text = "Release Date: " + g.ReleaseDate;
        }
    }
}
