using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace spnmario
{
    /*Level is basically a wrapper class for our array. It 
     * holds the foreach loops and the for-loop constructor.
     * Eventually, it will also hook in somehow to the level-select
     * logic.  Not sure how yet, though.*/
    public class Level
    {
        protected Tile[,] tL;
        public Tile[,] theLevel
        {
            get
            {
                return tL;
            }
        }
        protected int length;
        protected int height;
        
        //Constructor
        public Level(Texture2D dirt, bool[,] vals){
            height = vals.GetLength(0);
            length = vals.GetLength(1);
            tL = new Tile[height, length];
            for (int i = 0; i<height; i++){
                for (int j = 0; j<length; j++){
                    tL[i,j]= new Tile(new Rectangle(80*j, 80*i, 80, 80), dirt, vals[i,j]);
                }
            }
        }

        //advanced constructor
        public Level(Texture2D dirt, Int16[,] vals)
        {
            height = vals.GetLength(0);
            length = vals.GetLength(1);
            tL = new Tile[height, length];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    tL[i, j] = new Tile(new Rectangle(80 * j, 80 * i, 80, 80), dirt, vals[i, j]);
                }
            }
        }


        //Update Loop
        public void Update()
        {
            foreach (Tile t in tL)
            {
                t.Update();
            }
        }

        //Draw Loop
        public void Draw(SpriteBatch theSB)
        {
            foreach (Tile t in tL)
            {
                t.Draw(theSB);
            }
        }
    }
}
