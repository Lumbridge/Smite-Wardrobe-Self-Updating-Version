using System;
using System.Windows.Forms;

using Smite_Wardrobe_Self_Updating_Version.Classes;
using static Smite_Wardrobe_Self_Updating_Version.Classes.Common;
using static Smite_Wardrobe_Self_Updating_Version.Classes.ParseMethods;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Smite_Wardrobe_Self_Updating_Version
{
    public partial class Loading_Form : Form
    {
        public Loading_Form()
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
                g.Skins = GetGodSkinList(g.Name);

                GodsParsed++;

                ProgressBar_LoadingSkins.Value = GodsParsed;
                Label_Parsing.Text = "Getting skins for: " + g.Name;
            });

            return GodList;
        }
    }
}
