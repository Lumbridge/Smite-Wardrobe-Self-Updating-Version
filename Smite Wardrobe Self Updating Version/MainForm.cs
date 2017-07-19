using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;

using Smite_Wardrobe_Self_Updating_Version.Classes;
using static Smite_Wardrobe_Self_Updating_Version.Classes.Common;
using static Smite_Wardrobe_Self_Updating_Version.Classes.ParseMethods;

namespace Smite_Wardrobe_Self_Updating_Version
{
    public partial class MainForm : Form
    {
        private void updateLabels(God g)
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

        private void viewSkinsButton_Click(object sender, EventArgs e)
        {
            WardrobeForm wf = new WardrobeForm(this);
            wf.ShowDialog();
        }

        private void godSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedCenter = godSelectionComboBox.SelectedIndex;

            if (SelectedCenter == 0)
                SelectedLeft = GodList.Count - 1;
            else
                SelectedLeft = SelectedCenter - 1;

            if (SelectedCenter == GodList.Count - 1)
                SelectedRight = 0;
            else
                SelectedRight = SelectedCenter + 1;

            leftGodPictureBox.Load(GodList[SelectedLeft].SkinLinks[0]);
            godSelectedPicBox.Load(GodList[godSelectionComboBox.SelectedIndex].SkinLinks[0]);
            rightGodPictureBox.Load(GodList[SelectedRight].SkinLinks[0]);

            updateLabels(GodList[godSelectionComboBox.SelectedIndex]);
        }

        private void godSelectionLeftButton_Click(object sender, EventArgs e)
        {
            SelectedCenter--;
            if (SelectedCenter < 0)
                SelectedCenter = GodList.Count - 1;

            godSelectionComboBox.SelectedIndex = SelectedCenter;

            updateLabels(GodList[godSelectionComboBox.SelectedIndex]);
        }

        private void godSelectionRightButton_Click(object sender, EventArgs e)
        {
            SelectedCenter++;
            if (SelectedCenter > GodList.Count - 1)
                SelectedCenter = 0;

            godSelectionComboBox.SelectedIndex = SelectedCenter;

            updateLabels(GodList[godSelectionComboBox.SelectedIndex]);
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                SmiteWikiGodTable = GetSmiteWikiGodTable();
                GodList = SmiteWikiGodTableToList(SmiteWikiGodTable);
                GodList = ParseAllGodSkinNamesAndLinks(GodList);
                
                // add all gods to god selection combo box
                foreach (var g in GodList)
                {
                    godSelectionComboBox.Items.Add(g.Name);
                }

                godSelectionComboBox.SelectedIndex = 0;

                updateLabels(GodList[0]);

                Console.WriteLine("There are currently " + GodList.Count + " gods in the database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, could not connect to online database. Are you connected to the internet?\n\nIf you would like to use the offline version download it from @Lumbridge Github (Offline version requires MS Access installed).\n\n" + ex);
                Application.Exit();
            }
        }
    }
}
