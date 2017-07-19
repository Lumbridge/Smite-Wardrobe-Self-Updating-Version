using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static Smite_Wardrobe_Self_Updating_Version.Classes.Common;

namespace Smite_Wardrobe_Self_Updating_Version
{
    public partial class WardrobeForm : Form
    {
        private MainForm _MainFormHandle = new MainForm();
        List<PictureBox> picBoxes = new List<PictureBox>();

        public WardrobeForm(MainForm mf)
        {
            InitializeComponent();

            _MainFormHandle = mf;
        }

        private void WardrobeForm_Load(object sender, EventArgs e)
        {
            int rows = GodList[SelectedCenter].Skins.Count / 5 + 1;

            write(rows.ToString());

            Size = new Size(170 * 5, rows * 225);

            for (int i = 0; i < GodList[SelectedCenter].Skins.Count; i++)
            {
                picBoxes.Add(new PictureBox() { Size = new Size(160, 200), SizeMode = PictureBoxSizeMode.StretchImage });
                flowLayoutPanel1.Controls.Add(picBoxes[i]);
                picBoxes[i].Load(GodList[SelectedCenter].SkinLinks[i]);
            }

            //MinimumSize = new Size(Width, Height);
            //MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            //AutoSize = true;
            //AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
