using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using static Smite_Wardrobe_Self_Updating_Version.Classes.God;
using static Smite_Wardrobe_Self_Updating_Version.Classes.Common;

namespace Smite_Wardrobe_Self_Updating_Version.Forms
{
    public partial class LoadingAllSkinsForm : Form
    {
        public LoadingAllSkinsForm()
        {
            InitializeComponent();

            CenterToScreen();

            Task.Run(() => LoadSequence());
        }

        private async Task LoadSequence()
        {
            await Task.Delay(0);

            AllAquiredSkinImages = GetAllAquiredSkinImages(AllAquiredSkinImages);

            Close();
        }

        private List<Image> GetAllAquiredSkinImages(List<Image> temp)
        {
            ImagesLoaded = 0;

            ProgressBar_LoadingSkins.Maximum = GetTotalSkinCount(GodList);

            Parallel.ForEach(GodList, g =>
            {
                Parallel.ForEach(g.Skins, s =>
                {
                    if (s.Acquired)
                    {
                        Label_Parsing.Text = "Loading " + "(" + temp.Count + "/" + GetTotalSkinCount(GodList) + "): " + s.Name;

                        temp.Add(GetSkinImageColour(s.ImageLink));

                        Interlocked.Increment(ref ImagesLoaded);

                        ProgressBar_LoadingSkins.Value = ImagesLoaded;

                        if (ImagesLoaded == GetTotalSkinCount(GodList))
                            Close();
                    }
                });
            });

            Label_Parsing.Text = "Done.";

            return temp;
        }
    }
}
