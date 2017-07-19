using System;
using System.Collections.Generic;

namespace Smite_Wardrobe_Self_Updating_Version.Classes
{
    class Common
    {
        public static int
            SelectedLeft = -1,
            SelectedCenter = 0,
            SelectedRight = 1;

        public static List<God> GodList = new List<God>();
        public static List<List<string>> SmiteWikiGodTable = new List<List<string>>();

        /// <summary>
        /// Returns a substring between two sub-parts of the string
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string GetSubstringByString(string a, string b, string c)
        {
            return c.Substring((c.IndexOf(a) + a.Length), (c.IndexOf(b) - c.IndexOf(a) - a.Length));
        }

        /// <summary>
        /// Easier than typing Console.WriteLine...
        /// </summary>
        /// <param name="t"></param>
        public static void write(string t)
        {
            Console.WriteLine(t);
        }
    }
}
