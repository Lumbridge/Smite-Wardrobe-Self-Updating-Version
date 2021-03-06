﻿using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace Smite_Wardrobe_Self_Updating_Version.Classes
{
    class Common
    {
        public static List<Image> AllAquiredSkinImages = new List<Image>();
        public static List<string> AllAquiredSkinNames = new List<string>();
        public static List<string> AllAquiredSkinImageLinks = new List<string>();

        public static int TotalSkins = 0, TotalGods = 0, GodsParsed = 0, ImagesLoaded = 0;

        public static Size CardImageSize = new Size(160, 200);

        public static int
            SelectedLeft = -1,
            SelectedGodIndex = 0,
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

        /// <summary>
        /// Returns the image passed in as greyscale
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Image ConvertToGreyscale(Image source)
        {
            Bitmap temp = new Bitmap(source);

            Graphics g = Graphics.FromImage(temp);

            ColorMatrix m = new ColorMatrix(
                new float[][]
                {
                    new float[] {.3f, .3f, .3f, 0, 0},
                    new float[] {.59f, .59f, .59f, 0, 0},
                    new float[] {.11f, .11f, .11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });

            ImageAttributes a = new ImageAttributes();

            a.SetColorMatrix(m);

            g.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height), 
                0, 0, source.Width, source.Height, GraphicsUnit.Pixel, a);

            g.Dispose();
            
            return temp;
        }

        /// <summary>
        /// Returns the number of skins marked as acquired in the god list
        /// </summary>
        /// <param name="godlist"></param>
        /// <returns></returns>
        public static int GetTotalSkinCount(List<God> godlist)
        {
            int totalskins = 0;

            Parallel.ForEach(godlist, g =>
            {
                Parallel.ForEach(g.Skins, s =>
                {
                    if (s.Acquired)
                    {
                        // Use interlocked increment to avoid race condition (totalskins++ is not atomic)
                        Interlocked.Increment(ref totalskins);
                    }
                });
            });

            return totalskins;
        }
    }
}
