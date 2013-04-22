using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace spnmario
{
    /* This is a pretty utility sort of class.  It reads CSVs into 2d arrays.*/
    public class CSVRead
    {
        //reads a CSV into a String[,]
        public static String[,] readCSV(string s)
        {
    	    String[] lines = File.ReadAllLines(s);
            String[,] vals = new String[lines.Length, lines[0].Split(',').Length];
            for (int i = 0; i < vals.GetLength(0); i++)
            {
                String[] thisLine = lines[i].Split(',');
                for (int j = 0; j < vals.GetLength(1); j++)
                {
                    vals[i, j] = thisLine[j];
                }
            }
            
            return vals;
        }
        //reads a CSV into a bool[,]
        public static bool[,] getLevel(string s)
        {
            String[,] raw = readCSV(s);
            bool[,] bools = new bool[raw.GetLength(0), raw.GetLength(1)];
            for (int i = 0; i < bools.GetLength(0); i++)
            {
                for (int j = 0; j < bools.GetLength(1); j++)
                {
                    bools[i, j] = (raw[i, j] == "true");
                }
            }
            return bools;
        }

    }
}
