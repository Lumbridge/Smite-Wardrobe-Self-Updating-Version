using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Smite_Wardrobe_Self_Updating_Version.Classes.Common;

namespace Smite_Wardrobe_Self_Updating_Version.Forms
{
    public partial class AllSkinsForm : Form
    {
        private List<PictureBox> PictureBoxes = new List<PictureBox>();

        public AllSkinsForm()
        {
            InitializeComponent();
        }

        private void AllSkinsForm_Load(object sender, EventArgs e)
        {
            WardrobeFlowLayout.Controls.Clear();

            // work out how many rows we need depending on the number of skins
            int rows = GetTotalSkinCount(GodList) / 5 + 1;

            if (rows > 3)
                rows = 3;

            // set the size of the window
            ClientSize = new Size(170 * 5, rows * 206);
            
            for (int i = 0; i < AllAquiredSkinImages.Count; i++)
            {
                PictureBoxes.Add(new PictureBox() { Size = CardImageSize, SizeMode = PictureBoxSizeMode.StretchImage, Image = AllAquiredSkinImages[i] });
                WardrobeFlowLayout.Controls.Add(PictureBoxes[i]);
            }

            //register a click event for each picture box
            Parallel.ForEach(PictureBoxes, p =>
            {
                p.Click += PictureBox_Click;
            });
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            // get the index of the clicked picture box
            int index = PictureBoxes.FindIndex(a => a == sender);

            if (PictureBoxes[index].Size == CardImageSize)
                PictureBoxes[index].Scale(2.5f);
            else
                PictureBoxes[index].Size = CardImageSize;
        }
    }
}