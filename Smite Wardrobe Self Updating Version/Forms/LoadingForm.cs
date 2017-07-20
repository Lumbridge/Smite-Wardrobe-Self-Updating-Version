using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

using Smite_Wardrobe_Self_Updating_Version.Classes;
using static Smite_Wardrobe_Self_Updating_Version.Classes.Common;
using static Smite_Wardrobe_Self_Updating_Version.Classes.ParseMethods;

namespace Smite_Wardrobe_Self_Updating_Version.Forms
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();

            CenterToScreen();

            SmiteWikiGodTable = GetSmiteWikiGodTable();
            GodList = SmiteWikiGodTableToList(SmiteWikiGodTable);

            ProgressBar_LoadingSkins.Maximum = GodList.Count;
            
            Task.Run(() => LoadSequence());
        }

        private async Task LoadSequence()
        {
            await Task.Delay(0);

            GodList = ParseAllGodSkinNamesAndLinks(GodList);

            Close();
        }

        private List<God> ParseAllGodSkinNamesAndLinks(List<God> GodList)
        {
            // parse all god skin names and links
            Parallel.ForEach(GodList, g =>
            {
                Label_Parsing.Text = "Getting skins for: " + g.Name;

                g.Skins = GetGodSkinList(g.Name);

                GodsParsed++;

                ProgressBar_LoadingSkins.Value = GodsParsed;
            });
            
            return GodList;
        }
    }
}
