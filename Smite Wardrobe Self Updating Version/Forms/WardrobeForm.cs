using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using static Smite_Wardrobe_Self_Updating_Version.Classes.God;
using static Smite_Wardrobe_Self_Updating_Version.Classes.Common;
using System.Threading.Tasks;

namespace Smite_Wardrobe_Self_Updating_Version.Forms
{
    public partial class WardrobeForm : Form
    {
        private List<PictureBox> PictureBoxes = new List<PictureBox>();

        public WardrobeForm(MainForm mf)
        {
            InitializeComponent();
        }

        private void WardrobeForm_Load(object sender, EventArgs e)
        {
            // work out how many rows we need depending on the number of skins
            int rows = GodList[SelectedGodIndex].Skins.Count / 5 + 1;

            // set the size of the window
            ClientSize = new Size(166 * 5, rows * 206);

            // loop through however many skins the selected god has
            for (int i = 0; i < GodList[SelectedGodIndex].Skins.Count; i++)
            {
                // add a new picture box for each skin the god has
                PictureBoxes.Add(new PictureBox() { Size = CardImageSize, SizeMode = PictureBoxSizeMode.StretchImage });

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
            Parallel.ForEach(PictureBoxes, p =>
            {
                p.Click += PictureBox_Click;
            });
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
