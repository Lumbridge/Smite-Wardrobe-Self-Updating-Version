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

        List<string> godInfo = new List<string>(); //for info function

        List<List<string>> tableHeadings;
        List<List<string>> tableContents;

        List<string> contents = new List<string>();
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

        //HtmlWeb web = new HtmlWeb();
        public List<string> getGodSkins(string godName)
        {
            Variables.skinLinks.Clear();
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(("http://smite.gamepedia.com/" + godName));
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[contains(@id,'tabber-')]//div[@class='tabbertab']");
            int numberOfSkins = (nodes.Count - 2), nodeCounter = 2;
            
            for (int i = 0; i < numberOfSkins; i++)
            {
                //Console.WriteLine(Between(nodes[nodeCounter].InnerHtml, "src=\"", "?version"));
                Variables.skinLinks.Add(Between(nodes[nodeCounter].InnerHtml, "src=\"", "?version"));
                nodeCounter++;
            }

            return Variables.skinLinks;

            //int numberOfSkins = 0;
            //HtmlAgilityPack.HtmlDocument doc;
            //HtmlNodeCollection nodes;
            //HtmlWeb web = new HtmlWeb();

            ////Console.WriteLine("There are " + (nodes.Count-2) + " skins for Agni.");

            ////string nodeString = nodes[2].InnerHtml.ToString();
            ////Console.WriteLine(nodeString);

            //int column = 0, row = 1;
            //string skinLink;
            //int nodeCounter = 2;
            //List<string> skinLinks = new List<string>();
            //foreach (string god in Variables.godNames.ToList())
            //{


            //    nodeCounter = 2;

            //    doc = web.Load(("http://smite.gamepedia.com/" + god));
            //    nodes = doc.DocumentNode.SelectNodes("//div[contains(@id,'tabber-')]//div[@class='tabbertab']");

            //    numberOfSkins = (nodes.Count - 2);

            //    for(int i = 0; i < numberOfSkins; i++)
            //    {
            //        skinLink = Between(nodes[nodeCounter].InnerHtml, "src=\"", "?version");
            //        Console.WriteLine(skinLink);



            //        nodeCounter++;
            //        row++;
            //    }

            //    row = 1;
            //    column++;

            //    Console.WriteLine(god + " has " + numberOfSkins + " skins.");
            //    Console.WriteLine("[0][0] = " + skinInformation[0][0] + " [1][0] = " + skinInformation[1][0]);
            //}
        }

        private void updateLabels()
        {
            godNameLabel.Text = "Name: " + getGodInfo(Variables.godNames[Variables.godSelected])[g_name];
            godPantheonLabel.Text = "Pantheon: " + getGodInfo(Variables.godNames[Variables.godSelected])[g_pantheon];
            godAttackTypeLabel.Text = "Attack Type: " + getGodInfo(Variables.godNames[Variables.godSelected])[g_attackType];
            godPowerTypeLabel.Text = "Power Type: " + getGodInfo(Variables.godNames[Variables.godSelected])[g_powerType];
            godClassLabel.Text = "Class: " + getGodInfo(Variables.godNames[Variables.godSelected])[g_class];
            godFavorCostLabel.Text = "Favor Cost: " + getGodInfo(Variables.godNames[Variables.godSelected])[g_favorCost];
            godGemsCostLabel.Text = "Gems Cost: " + getGodInfo(Variables.godNames[Variables.godSelected])[g_gemsCost];
            godReleaseDateLabel.Text = "Release Date: " + getGodInfo(Variables.godNames[Variables.godSelected])[g_releaseDate];
        }

        private void viewSkinsButton_Click(object sender, EventArgs e)
        {
            WardrobeForm wf = new WardrobeForm();
            wf.ShowDialog();
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
            Variables.godSelected = godSelectionComboBox.SelectedIndex;
            
            if(Variables.godSelected == 0)
                Variables.godLeftIndex = Variables.godNames.Count - 1;
            else
                Variables.godLeftIndex = Variables.godSelected - 1;

            if(Variables.godSelected == Variables.godNames.Count - 1)
                Variables.godRightIndex = 0;
            else
                Variables.godRightIndex = Variables.godSelected + 1;

            leftGodPictureBox.Load(getGodImageLink(Variables.godNames[Variables.godLeftIndex]).Trim());
            godSelectedPicBox.Load(getGodImageLink(Variables.godNames[Variables.godSelected]).Trim());
            rightGodPictureBox.Load(getGodImageLink(Variables.godNames[Variables.godRightIndex]).Trim());

            updateLabels();
        }

        private void godSelectionLeftButton_Click(object sender, EventArgs e)
        {
            Variables.godSelected--;
            if (Variables.godSelected < 0)
                Variables.godSelected = Variables.godNames.Count-1;

            godSelectionComboBox.SelectedIndex = Variables.godSelected;

            updateLabels();
        }

        private void godSelectionRightButton_Click(object sender, EventArgs e)
        {
            Variables.godSelected++;
            if (Variables.godSelected > Variables.godNames.Count-1)
                Variables.godSelected = 0;

            godSelectionComboBox.SelectedIndex = Variables.godSelected;

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
                Variables.godNames.Add(contents[i]);
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

            int column = Variables.godNames.IndexOf(godName);
            
            godInfo.Add(godInformation[g_name][column]);
            godInfo.Add(godInformation[g_pantheon][column]);
            godInfo.Add(godInformation[g_attackType][column]);
            godInfo.Add(godInformation[g_powerType][column]);
            godInfo.Add(godInformation[g_class][column]);
            godInfo.Add(godInformation[g_favorCost][column]);
            godInfo.Add(godInformation[g_gemsCost][column]);
            godInfo.Add(godInformation[g_releaseDate][column]);

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

                godInformation.Add(Variables.godNames);
                godInformation.Add(godPantheon);
                godInformation.Add(godAttackType);
                godInformation.Add(godPowerType);
                godInformation.Add(godClass);
                godInformation.Add(godFavorCost);
                godInformation.Add(godGemsCost);
                godInformation.Add(godReleaseDate);

                skinInformation.Add(Variables.godNames);

                // add all gods to god selection combo box
                foreach (string godname in Variables.godNames)
                {
                    godSelectionComboBox.Items.Add(godname);
                }

                godSelectionComboBox.SelectedIndex = Variables.godSelected;

                updateLabels();

                Console.WriteLine("There are currently " + Variables.godNames.Count + " gods in the database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, could not connect to online database. Are you connected to the internet?\n\nIf you would like to use the offline version download it from @Lumbridge Github (Offline version requires MS Access installed).\n\n" + ex);
                Application.Exit();
            }
        }
    }
    public class Variables
    {
        public static int godSelected = 0, godLeftIndex, godRightIndex;
        public static List<string> godNames = new List<string>();
        public static List<string> skinLinks = new List<string>();
    }
}
