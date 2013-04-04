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
    /*Dude's our character sprite.  It'll eventually get a bunch of
     * fun logic, handling animation, as well as who you're playing 
     * as.  It will also probably handle our collision/movement logic.*/
    public class Dude
    {
        public Texture2D CharacterAssetSheet;
        public Rectangle rect;
        //This enum's for ater use--allows only one asset sheet overall.
        public enum PlayingAs
        {
            Sam,
            Dean,
            Cas,
            Bobby,
        }
        //variables for collision logic
        public Vector2 foot;
        public bool onGround; //true if not falling
        //constructor
        public Dude(Rectangle r, Texture2D asset)
        {
            CharacterAssetSheet = asset;
            rect = r;
            foot = new Vector2(r.X + (r.Width / 2), r.Y + r.Height);
        }

        //update loop
        public void Update()
        {
            //Detect existing collisions


            //Gravity: makes gravity happen
            if (!(onGround))
            {
                rect.Y += 5;
            }
            
            Movement(); //runs listeners and handles x/y positioning.
            
        }

        //draw
        public void Draw(SpriteBatch theSB)
        {
            theSB.Draw(CharacterAssetSheet, rect, Color.White);
        }

        /*Handles movement involving listeners*/
        public void Movement()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                rect.X-=3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                rect.X+=3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            { 
                rect.Y -= 8; 
            }

            //refresh collision variables
            foot.X = rect.X + (rect.Width / 2);
            foot.Y = rect.Y + rect.Height;

        }
        
    }
}
