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

        //reads a CSV into a bool[,], deprecated
        public static bool[,] getBasicLevel(string s)
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

        //reads csv into an int16, also supports bool-based legacy levels.  
        public static Int16[,] getLevel(string s)
        {
            String[,] raw = readCSV(s);
            Int16[,] ints = new Int16[raw.GetLength(0), raw.GetLength(1)];
            for (int i = 0; i < ints.GetLength(0); i++)
            {
                for (int j = 0; j < ints.GetLength(1); j++)
                {
                    try
                    {
                        ints[i, j] = Convert.ToInt16(raw[i, j]);
                    }
                    catch
                    {
                        if (raw[i, j] == "true")
                        {
                            ints[i, j] = 1;
                        }
                        else
                        {
                            ints[i, j] = 0;
                        }
                    }
                }
            }
            return ints;
        }

    }
}
