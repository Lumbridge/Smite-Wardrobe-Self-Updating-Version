using System.Net;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using HtmlAgilityPack;

using static Smite_Wardrobe_Self_Updating_Version.Classes.Common;

namespace Smite_Wardrobe_Self_Updating_Version.Classes
{
    class ParseMethods
    {
        /// <summary>
        /// Downloads the current god list from the smite wiki and adds it to a list of lists of strings
        /// </summary>
        /// <returns></returns>
        public static List<List<string>> GetSmiteWikiGodTable()
        {
            List<List<string>> Table = new List<List<string>>();

            WebClient webClient = new WebClient();
            string page = webClient.DownloadString("http://smite.gamepedia.com/List_of_gods");

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(page);

            doc.OptionFixNestedTags = true;

            Table = doc.DocumentNode.SelectSingleNode("//table")
                .Descendants("tr")
                .Skip(0)
                .Where(tr => tr.Elements("td").Count() > 1)
                .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                .ToList();

            return Table;
        }

        /// <summary>
        /// Maps the list of list of strings downloaded by the GetSmiteWikiGodTable function into a list of God objects
        /// </summary>
        /// <param name="Table"></param>
        /// <returns></returns>
        public static List<God> SmiteWikiGodTableToList(List<List<string>> Table)
        {
            List<God> GodList = new List<God>();
            List<string> contents = new List<string>();

            // adding all table contents to a list
            foreach (List<string> Row in Table)
            {
                foreach (string Field in Row)
                {
                    contents.Add(Field);
                }
            }

            for (int i = 0; i < contents.Count; i += 9)
            {
                GodList.Add(new God()
                {
                    Name = contents[i + 1],
                    Pantheon = contents[i + 2],
                    AttackType = contents[i + 3],
                    PowerType = contents[i + 4],
                    Class = contents[i + 5],
                    FavourCost = contents[i + 6],
                    GemCost = contents[i + 7],
                    ReleaseDate = contents[i + 8]
                });
            }

            return GodList;
        }

        /// <summary>
        /// Retrieves a list of strings containing all skins for that specific god
        /// </summary>
        /// <param name="GodName"></param>
        /// <returns></returns>
        public static List<Skin> GetGodSkinList(string GodName)
        {
            List<string> WordsToRemove = new List<string>()
            {
                "Starter",
                "Core",
                "Damage",
                "Defensive",
                "Relic",
                "Consumable"
            };

            // create temporary list to store found skins
            List<Skin> Skins = new List<Skin>();

            // edit the god name string to work properly in a link format
            if (GodName.Contains(" "))
                GodName = GodName.Replace(" ", "_");
            if (GodName.Contains("'"))
                GodName = GodName.Replace("'", "%27");

            // create new webclient and htmldocument to save the page content
            WebClient webClient = new WebClient();
            string page = webClient.DownloadString("http://smite.gamepedia.com/" + GodName);
            HtmlDocument doc = new HtmlDocument();

            // load the page data
            doc.LoadHtml(page);

            // parse through html nodes to find all skin names
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@id='global-wrapper']"))
            {
                foreach (HtmlNode node2 in node.SelectNodes(".//div[@id='bodyContent']"))
                {
                    foreach (HtmlNode node3 in node2.SelectNodes(".//div[@class='tabber']"))
                    {
                        foreach (HtmlNode node4 in node3.SelectNodes(".//tr[@class='prettytable']"))
                        {
                            foreach (HtmlNode node5 in node4.SelectNodes(".//th[@colspan]"))
                            {
                                string innertext = node5.InnerText;

                                // replace any encoding errors in the god name
                                if (innertext.Contains("&#039;"))
                                    innertext = node5.InnerText.Replace("&#039;", "'");
                                if (innertext.Contains("&amp"))
                                    innertext = node5.InnerText.Replace("&amp;", "&");

                                // check if we've located any of our banned words and if not then add the name to the skin list
                                if (!WordsToRemove.Contains(node5.InnerText))
                                    Skins.Add(new Skin() { Name = innertext });
                            }
                        }
                    }
                }
            }

            // this counter matches the skin link to the skin name
            // and is incremented each time a new link is located
            int counter = 0;

            // parse through html nodes until we find the skin image links
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//center"))
            {
                foreach (HtmlNode node2 in node.SelectNodes(".//div[@class='tabbertab']"))
                {
                    foreach (HtmlNode node3 in node2.SelectNodes(".//a[@href]"))
                    {
                        if (node3.InnerHtml.Contains("width=\"388\""))
                        {
                            string innertext = node3.InnerHtml;

                            // check that the inner text of the html node isn't empty
                            // and if it isn't then we get the substring between two static substrings
                            // which gives us the image link
                            if (innertext.Length > 0)
                                innertext = GetSubstringByString("src=\"", "\" width", innertext);

                            // add the image link to the skin object in the skin list
                            Skins[counter].ImageLink = innertext;
                            // increment the counter so we don't override the skin link we just added
                            counter++;
                        }
                    }
                }
            }

            return Skins;
        }
    }
}
