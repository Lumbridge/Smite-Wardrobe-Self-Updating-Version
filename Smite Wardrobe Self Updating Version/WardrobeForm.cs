using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Smite_Wardrobe_Self_Updating_Version.Classes;
using static Smite_Wardrobe_Self_Updating_Version.Classes.God;
using static Smite_Wardrobe_Self_Updating_Version.Classes.Common;

namespace Smite_Wardrobe_Self_Updating_Version
{
    public partial class WardrobeForm : Form
    {
        private MainForm _MainFormHandle = new MainForm();
        List<PictureBox> PictureBoxes = new List<PictureBox>();

        public WardrobeForm(MainForm mf)
        {
            InitializeComponent();

            _MainFormHandle = mf;
        }

        private void WardrobeForm_Load(object sender, EventArgs e)
        {
            // work out how many rows we need depending on the number of skins
            int rows = GodList[SelectedGodIndex].Skins.Count / 5 + 1;

            // set the size of the window
            Size = new Size(170 * 5, rows * 225);

            // loop through however many skins the selected god has
            for (int i = 0; i < GodList[SelectedGodIndex].Skins.Count; i++)
            {
                // add a new picture box for each skin the god has
                PictureBoxes.Add(new PictureBox() { Size = new Size(160, 200), SizeMode = PictureBoxSizeMode.StretchImage });

                // add the picture box to the flow layout so it's laid out automatically
                WardrobeFlowLayout.Controls.Add(PictureBoxes[i]);

                // if the skin is marked as aquired then it will be in colour upon loading otherwise
                // it will be loaded as greyscale
                if(GodList[SelectedGodIndex].Skins[i].Acquired)
                    PictureBoxes[i].Image = GetSkinImageColour(GodList[SelectedGodIndex].Skins[i].ImageLink);
                else
                    PictureBoxes[i].Image = ConvertToGreyscale(GetSkinImageColour(GodList[SelectedGodIndex].Skins[i].ImageLink));
            }

            // register a click event for each picture box
            foreach (var p in PictureBoxes)
            {
                p.Click += PictureBox_Click;
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            // get the index of the clicked picture box
            int index = PictureBoxes.FindIndex(a => a == sender);

            // toggles the skin image between colour & greyscale depending on if they are acquired/owned or not
            if (!GodList[SelectedGodIndex].Skins[index].Acquired)
            {
                PictureBoxes[index].Load(GodList[SelectedGodIndex].Skins[index].ImageLink);
                GodList[SelectedGodIndex].Skins[index].Acquired = true;
            }
            else
            {
                PictureBoxes[index].Image = ConvertToGreyscale(PictureBoxes[index].Image);
                GodList[SelectedGodIndex].Skins[index].Acquired = false;
            }
        }
    }
}
