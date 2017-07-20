using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

using static Smite_Wardrobe_Self_Updating_Version.Classes.God;
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
            Parallel.ForEach(GodList, g =>
            {
                Parallel.ForEach(g.Skins, s =>
                {
                    if (s.Acquired)
                    {
                        BeginInvoke((MethodInvoker)delegate ()
                        {
                            WardrobeFlowLayout.Controls.Add(new PictureBox() { Size = new Size(160, 200), SizeMode = PictureBoxSizeMode.StretchImage, Image = GetSkinImageColour(s.ImageLink) });
                        });
                        
                        TotalSkins++;
                    }
                });
            });

            // work out how many rows we need depending on the number of skins
            int rows = TotalSkins / 5 + 1;

            if (rows > 3)
                rows = 3;

            // set the size of the window
            ClientSize = new Size(170 * 5, rows * 206);
        }
    }
}
