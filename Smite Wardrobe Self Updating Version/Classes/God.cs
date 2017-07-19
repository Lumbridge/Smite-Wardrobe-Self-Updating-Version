using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;

namespace Smite_Wardrobe_Self_Updating_Version.Classes
{
    class God
    {
        public string Name { get; set; }
        public string Pantheon { get; set; }
        public string AttackType { get; set; }
        public string PowerType { get; set; }
        public string Class { get; set; }
        public string FavourCost { get; set; }
        public string GemCost { get; set; }
        public string ReleaseDate { get; set; }
        public List<Skin> Skins { get; set; }

        public static Image GetSkinImageColour(string SkinLink)
        {
            var request = WebRequest.Create(SkinLink);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                return Bitmap.FromStream(stream);
            }
        }

        /// <summary>
        /// Returns the index of a god in the godlist - searched by name
        /// </summary>
        /// <param name="GodList"></param>
        /// <param name="SearchName"></param>
        /// <returns></returns>
        public static int GetGodIndexByName(List<God> GodList, string SearchName)
        {
            for(int i = 0; i < GodList.Count; i++)
            {
                if (GodList[i].Name == SearchName)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Returns the index of a skin in the skinlist - searched by name
        /// </summary>
        /// <param name="GodSkinList"></param>
        /// <param name="SearchName"></param>
        /// <returns></returns>
        public static int GetSkinIndexByName(List<Skin> GodSkinList, string SearchName)
        {
            for(int i = 0; i < GodSkinList.Count; i++)
            {
                if (GodSkinList[i].Name == SearchName)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Writes information about the god to the console
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Console.WriteLine("{0,15}{1,9}{2,7}{3,9}{4,9}{5,5}{6,5}{7,11}",
                Name,
                Pantheon,
                AttackType,
                PowerType,
                Class,
                FavourCost,
                GemCost,
                ReleaseDate);

            return string.Empty;
        }
    }
}
