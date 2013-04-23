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
    /*Tile's the class where our nitty-gritty set management happens.  
     * Each block in a level is a tile, and here's our rules for handling that.
     * Though we made need more classes to handle more sophisticated rules than
     * 'yes you can be here' and 'no you can't be here'*/
    public class Tile
    {
        public Texture2D dirt;
        public Rectangle rect;
        public enum TType
        {
            air,
            ground,
            misha,
        }
        protected TType type;
        public bool isSolid //accesses drawme
        {
            get
            {
                return drawme;
            }
        }
        protected bool drawme; //controls whether it's drawn/solid

        //constructor
        public Tile(Rectangle r, Texture2D asset, bool solid)
        {
            dirt = asset;
            rect = r;
            drawme = solid;
            if (solid)
            {
                type = TType.ground;
            }
            else 
            {
                type = TType.air;
            }
        }

        //advanced constructor
        public Tile(Rectangle r, Texture2D asset, Int16 i)
        {
            dirt = asset;
            rect = r;
            switch (i)
            {
                default:
                    type = TType.air;
                    drawme = false;
                    break;

                case 1:
                    type = TType.ground;
                    drawme = true;
                    break;

                case 2:
                    type = TType.misha;
                    drawme = true;
                    break;
            }
        }

        //empty constructor
        public Tile()
        {
            rect = new Rectangle(0, 0, 0, 0);
            drawme = false;
        }

        //Update calls all our update-cycle logic.
        public void Update()
        {

        }
        //Draws if you can't be here.
        public void Draw(SpriteBatch theSB)
        {
            switch (type){
                default:
                    break;
                case TType.ground:
                    theSB.Draw(dirt, rect, new Rectangle(0,0,80,80), Color.White);
                    break;
                case TType.misha:
                    theSB.Draw(dirt, rect, new Rectangle(80,0,80,80), Color.White);
                    break;
            }
        }
    }
}
