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
    public class CSVRead
    {
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

    }
}
