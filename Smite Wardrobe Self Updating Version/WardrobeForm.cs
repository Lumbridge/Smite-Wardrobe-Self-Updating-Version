using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smite_Wardrobe_Self_Updating_Version
{
    public partial class WardrobeForm : Form
    {
        List<PictureBox> picBoxes = new List<PictureBox>();

        public WardrobeForm()
        {
            InitializeComponent();
        }

        private void WardrobeForm_Load(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();

            picBoxes.Add(pictureBox1);
            picBoxes.Add(pictureBox2);
            picBoxes.Add(pictureBox3);
            picBoxes.Add(pictureBox4);
            picBoxes.Add(pictureBox5);
            picBoxes.Add(pictureBox6);
            picBoxes.Add(pictureBox7);
            picBoxes.Add(pictureBox8);
            picBoxes.Add(pictureBox9);
            picBoxes.Add(pictureBox10);
            picBoxes.Add(pictureBox11);
            picBoxes.Add(pictureBox12);
            picBoxes.Add(pictureBox13);
            picBoxes.Add(pictureBox14);
            picBoxes.Add(pictureBox15);
            picBoxes.Add(pictureBox16);
            picBoxes.Add(pictureBox17);
            picBoxes.Add(pictureBox18);

            this.Size = new Size(mf.getGodSkins(Variables.godNames[Variables.godSelected]).Count * 140, 225);

            for(int i = 0; i < mf.getGodSkins(Variables.godNames[Variables.godSelected]).Count; i++)
            {
                picBoxes[i].Load(Variables.skinLinks[i]);
            }
        }
    }
}
