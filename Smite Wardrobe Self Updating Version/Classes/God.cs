using System;
using System.Collections.Generic;

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
        public List<string> Skins { get; set; }
        public List<string> SkinLinks { get; set; }

        public int GetGodIndex(List<God> GodList, string SearchName)
        {
            for(int i = 0; i < GodList.Count - 1; i++)
            {
                if (GodList[i].Name == SearchName)
                    return i;
            }

            return -1;
        }

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
