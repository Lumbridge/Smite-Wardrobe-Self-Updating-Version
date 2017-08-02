using System;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Smite_Wardrobe_Self_Updating_Version.Classes;
using static Smite_Wardrobe_Self_Updating_Version.Classes.Common;
using static Smite_Wardrobe_Self_Updating_Version.Classes.ParseMethods;

using System.Net;
using HtmlAgilityPack;

namespace Smite_Wardrobe_Self_Updating_Version.Forms
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();

            // center the form
            CenterToScreen();

            // get the god table from the smite wiki
            SmiteWikiGodTable = GetSmiteWikiGodTable();
            
            // parse the wiki table into a list of god objects
            GodList = SmiteWikiGodTableToList(SmiteWikiGodTable);

            // update the progress bar with how many gods are in the list
            ProgressBar_LoadingSkins.Maximum = GodList.Count;
            
            // start parsing all skin names and links
            Task.Run(() => LoadSequence());
        }

        private async Task LoadSequence()
        {
            await Task.Delay(0);

            // get all skin names and links for each god
            GodList = ParseAllGodSkinNamesAndLinks(GodList);

            // close this form when we are done so the main form can be shown
            Close();
        }

        private List<God> ParseAllGodSkinNamesAndLinks(List<God> GodList)
        {
            // set thje gods parsed to 0 so this function can be called again without causing problems
            GodsParsed = 0;

            // parse all god skin names and links
            Parallel.ForEach(GodList, g =>
            {
                // update the label with the next god we are parsing
                Label_Parsing.Text = "Loading God (" + GodsParsed + "/" + TotalGods + "): " + g.Name;

                // update the god's skinlist with all their skin names and links
                g.Skins = GetGodSkinList(g.Name);

                // increment the number of gods we have parsed
                Interlocked.Increment(ref GodsParsed);

                // update the progress bar
                ProgressBar_LoadingSkins.Value = GodsParsed;
            });
            
            // return the completed godlist
            return GodList;
        }
    }
}
