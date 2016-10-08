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
        List<List<string>> virtualDatabase = new List<List<string>>();

        int g_name = 0, g_pantheon = 1, g_attackType = 2,
            g_powerType = 3, g_class = 4, g_favorCost = 5,
            g_gemsCost = 6, g_releaseDate = 7;

        int godSelected = 0;

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
            //if(godSelectedPicBox.Image != null)
            //godSelectedPicBox.Image.Dispose();

            godSelected = godSelectionComboBox.SelectedIndex;

            godSelectedPicBox.Load(getGodImageLink(godNames[godSelected]).Trim());
            godSelected = godSelectionComboBox.SelectedIndex;
        }

        private void godSelectionLeftButton_Click(object sender, EventArgs e)
        {
            godSelected--;
            if (godSelected < 0)
                godSelected = godNames.Count-1;

            godSelectionComboBox.SelectedIndex = godSelected;
        }

        private void godSelectionRightButton_Click(object sender, EventArgs e)
        {
            godSelected++;
            if (godSelected > godNames.Count-1)
                godSelected = 0;

            godSelectionComboBox.SelectedIndex = godSelected;

            Console.WriteLine("God selected: " + godNames[godSelected]);
            Console.WriteLine("God selected index: " + godNames.IndexOf(godNames[godSelected]));
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
            
            godInfo.Add(virtualDatabase[g_name][p]);
            godInfo.Add(virtualDatabase[g_pantheon][p]);
            godInfo.Add(virtualDatabase[g_attackType][p]);
            godInfo.Add(virtualDatabase[g_powerType][p]);
            godInfo.Add(virtualDatabase[g_class][p]);
            godInfo.Add(virtualDatabase[g_favorCost][p]);
            godInfo.Add(virtualDatabase[g_gemsCost][p]);
            godInfo.Add(virtualDatabase[g_releaseDate][p]);

            return godInfo;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            addPageDataToLists();

            virtualDatabase.Add(godNames);
            virtualDatabase.Add(godPantheon);
            virtualDatabase.Add(godAttackType);
            virtualDatabase.Add(godPowerType);
            virtualDatabase.Add(godClass);
            virtualDatabase.Add(godFavorCost);
            virtualDatabase.Add(godGemsCost);
            virtualDatabase.Add(godReleaseDate);

            // add all gods to god selection combo box
            foreach (string godname in godNames)
            {
                godSelectionComboBox.Items.Add(godname);
            }

            godSelectionComboBox.SelectedIndex = godSelected;



            //Console.Write(getGodImageLink("Ra"));

            //foreach (string item in getGodInfo("Ra"))
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine(getGodInfo("Susano")[g_gemsCost]);

            Console.WriteLine("There are currently " + godNames.Count + " gods in the database.");
        }
    }
}
