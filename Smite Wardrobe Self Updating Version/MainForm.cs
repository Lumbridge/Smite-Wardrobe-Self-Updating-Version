using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;

namespace Smite_Wardrobe_Self_Updating_Version
{
    public partial class MainForm : Form
    {
        List<List<string>> godInformation = new List<List<string>>();
        List<List<string>> skinInformation = new List<List<string>>();

        int g_name = 0, g_pantheon = 1, g_attackType = 2,
            g_powerType = 3, g_class = 4, g_favorCost = 5,
            g_gemsCost = 6, g_releaseDate = 7;

        int godSelected = 0, godLeftIndex, godRightIndex;

        List<string> godInfo = new List<string>(); //for info function

        List<List<string>> tableHeadings;
        List<List<string>> tableContents;

        List<string> contents = new List<string>();
        List<string> godNames = new List<string>();
        List<string> godPantheon = new List<string>();
        List<string> godAttackType = new List<string>();
        List<string> godPowerType = new List<string>();
        List<string> godClass = new List<string>();
        List<string> godFavorCost = new List<string>();
        List<string> godGemsCost = new List<string>();
        List<string> godReleaseDate = new List<string>();
        List<string> sgGodCodes = new List<string>();

        public string Between(string STR, string FirstString, string LastString)
        {
            string FinalString;
            int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;
            int Pos2 = STR.IndexOf(LastString);
            FinalString = STR.Substring(Pos1, Pos2 - Pos1);
            return FinalString;
        }

        private void scrapeAllGodSkinsAndSplitInfo()
        {
            int column = 0;
            int row = 0;

            // load god specific page
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(("http://smite.gamepedia.com/" + "Agni"));

            //HtmlNode node = doc.DocumentNode.SelectSingleNode("//div[@id='tabber-cd9a3c7a9d4285929fff2cb18867343e']");
            var nodes = doc.DocumentNode.SelectNodes("//div[contains(@id,'tabber-')]");
            string nodeString = nodes[1].InnerHtml.ToString();
            Console.WriteLine(nodeString);
            //get skin img links
            string skinImageLink;
            int index;

            skinImageLink = Between(nodeString, "src=\"", "?version");
            Console.WriteLine(skinImageLink);

            index = nodeString.IndexOf(skinImageLink);
            nodeString = (index < 0)
                ? nodeString
                : nodeString.Remove(index, skinImageLink.Length);

            skinImageLink = Between(nodeString, "src=\"", "?version");
            Console.WriteLine(skinImageLink);

            index = nodeString.IndexOf(skinImageLink);
            nodeString = (index < 0)
                ? nodeString
                : nodeString.Remove(index, skinImageLink.Length);

            //get skin release date
            string releaseDate;
            
            //get skin type (standard, exclusive etc)
            string skinType;
            
            //get skin cost
            string skinCost;
            
            //get skin extra info
            string skinExtraInfo;

        }

            //foreach(string name in godNames)
            //{
            //    // load god specific page
            //    HtmlWeb web = new HtmlWeb();
            //    HtmlAgilityPack.HtmlDocument doc = web.Load(("http://smite.gamepedia.com/" + name));

            //    HtmlNode node = doc.DocumentNode.SelectSingleNode("//div[@class='tabber tabberlive']");
            //    string nodeString = node.InnerHtml.ToString();

            //    Console.WriteLine(nodeString);

            //    //if (nodeString.IndexOf("?version") > 0)
            //    //{
            //    //    nodeString = nodeString.Substring(0, nodeString.IndexOf("?version"));
            //    //}

            //    //nodeString = nodeString.Substring(nodeString.IndexOf("src=") + 5);
            //}
        //}

        private void updateLabels()
        {
            godNameLabel.Text = "Name: " + getGodInfo(godNames[godSelected])[g_name];
            godPantheonLabel.Text = "Pantheon: " + getGodInfo(godNames[godSelected])[g_pantheon];
            godAttackTypeLabel.Text = "Attack Type: " + getGodInfo(godNames[godSelected])[g_attackType];
            godPowerTypeLabel.Text = "Power Type: " + getGodInfo(godNames[godSelected])[g_powerType];
            godClassLabel.Text = "Class: " + getGodInfo(godNames[godSelected])[g_class];
            godFavorCostLabel.Text = "Favor Cost: " + getGodInfo(godNames[godSelected])[g_favorCost];
            godGemsCostLabel.Text = "Gems Cost: " + getGodInfo(godNames[godSelected])[g_gemsCost];
            godReleaseDateLabel.Text = "Release Date: " + getGodInfo(godNames[godSelected])[g_releaseDate];
        }

        private string getGodImageLink(string godName)
        {
            // load smiteguru god specific page
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(("http://smite.gamepedia.com/" + godName));

            HtmlNode node = doc.DocumentNode.SelectSingleNode("//table[@class='infobox infobox-test']");
            string nodeString = node.InnerHtml.ToString();

            if(nodeString.IndexOf("?version") > 0)
            {
                nodeString = nodeString.Substring(0, nodeString.IndexOf("?version"));
            }

            nodeString = nodeString.Substring(nodeString.IndexOf("src=") + 5);

            return nodeString;
        }

        private void godSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            godSelected = godSelectionComboBox.SelectedIndex;
            
            if(godSelected == 0)
                godLeftIndex = godNames.Count - 1;
            else
                godLeftIndex = godSelected - 1;

            if(godSelected == godNames.Count - 1)
                godRightIndex = 0;
            else
                godRightIndex = godSelected + 1;

            leftGodPictureBox.Load(getGodImageLink(godNames[godLeftIndex]).Trim());
            godSelectedPicBox.Load(getGodImageLink(godNames[godSelected]).Trim());
            rightGodPictureBox.Load(getGodImageLink(godNames[godRightIndex]).Trim());

            updateLabels();
        }

        private void godSelectionLeftButton_Click(object sender, EventArgs e)
        {
            godSelected--;
            if (godSelected < 0)
                godSelected = godNames.Count-1;

            godSelectionComboBox.SelectedIndex = godSelected;

            updateLabels();
        }

        private void godSelectionRightButton_Click(object sender, EventArgs e)
        {
            godSelected++;
            if (godSelected > godNames.Count-1)
                godSelected = 0;

            godSelectionComboBox.SelectedIndex = godSelected;

            updateLabels();
        }

        private void downloadWebpage()
        {
            WebClient webClient = new WebClient();
            string page = webClient.DownloadString("http://smite.gamepedia.com/List_of_gods");

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(page);

            doc.OptionFixNestedTags = true;

            tableHeadings = doc.DocumentNode.SelectSingleNode("//table")
                .Descendants("tr")
                .Skip(0)
                .Where(tr => tr.Elements("th").Count() > 1)
                .Select(tr => tr.Elements("th").Select(th => th.InnerText.Trim()).ToList())
                .ToList();

            tableContents = doc.DocumentNode.SelectSingleNode("//table")
                .Descendants("tr")
                .Skip(0)
                .Where(tr => tr.Elements("td").Count() > 1)
                .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                .ToList();
        }

        private void addPageDataToLists()
        {
            downloadWebpage();

            // adding all table contents to a list "contents"
            foreach (List<string> list in tableContents)
            {
                foreach (string items in list)
                {
                    contents.Add(items);
                }
            }
            // add god names to list 1n+9
            for (int i = 1; i < contents.Count; i += 9)
            {
                godNames.Add(contents[i]);
            }
            // add pantheons to list 2n+9
            for (int i = 2; i < contents.Count; i += 9)
            {
                godPantheon.Add(contents[i]);
            }
            // add attack type to list 3n+9
            for (int i = 3; i < contents.Count; i += 9)
            {
                godAttackType.Add(contents[i]);
            }
            // add power type to list 4n+9
            for (int i = 4; i < contents.Count; i += 9)
            {
                godPowerType.Add(contents[i]);
            }
            // add class to list 5n+9
            for (int i = 5; i < contents.Count; i += 9)
            {
                godClass.Add(contents[i]);
            }
            // add favor cost to list 6n+9
            for (int i = 6; i < contents.Count; i += 9)
            {
                godFavorCost.Add(contents[i]);
            }
            // add gems cost to list 7n+9
            for (int i = 7; i < contents.Count; i += 9)
            {
                godGemsCost.Add(contents[i]);
            }
            // add release date to list 8n+9
            for (int i = 8; i < contents.Count; i += 9)
            {
                godReleaseDate.Add(contents[i]);
            }
        }

        private List<string> getGodInfo(string godName)
        {
            godInfo.Clear();

            int p = godNames.IndexOf(godName);
            
            godInfo.Add(godInformation[g_name][p]);
            godInfo.Add(godInformation[g_pantheon][p]);
            godInfo.Add(godInformation[g_attackType][p]);
            godInfo.Add(godInformation[g_powerType][p]);
            godInfo.Add(godInformation[g_class][p]);
            godInfo.Add(godInformation[g_favorCost][p]);
            godInfo.Add(godInformation[g_gemsCost][p]);
            godInfo.Add(godInformation[g_releaseDate][p]);

            return godInfo;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                addPageDataToLists();

                godInformation.Add(godNames);
                godInformation.Add(godPantheon);
                godInformation.Add(godAttackType);
                godInformation.Add(godPowerType);
                godInformation.Add(godClass);
                godInformation.Add(godFavorCost);
                godInformation.Add(godGemsCost);
                godInformation.Add(godReleaseDate);

                skinInformation.Add(godNames);

                // add all gods to god selection combo box
                foreach (string godname in godNames)
                {
                    godSelectionComboBox.Items.Add(godname);
                }

                godSelectionComboBox.SelectedIndex = godSelected;

                updateLabels();

                Console.WriteLine("There are currently " + godNames.Count + " gods in the database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, could not connect to online database. Are you connected to the internet?\n\nIf you would like to use the offline version download it from @Lumbridge Github (Offline version requires MS Access installed).\n\n" + ex);
                Application.Exit();
            }

            try
            {
                scrapeAllGodSkinsAndSplitInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n\n" + ex);
            }
        }
    }
}
