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
        public Vector2 lowerRight;
        public Vector2 upperRight;
        public Vector2 upperLeft;
        public Vector2 lowerLeft;
        public int airTime;//time in air
        //constructor
        public Dude(Rectangle r, Texture2D asset)
        {
            CharacterAssetSheet = asset;
            rect = r;
            foot = new Vector2(r.X + (r.Width / 2), r.Y + r.Height);
            lowerRight = new Vector2(r.X + r.Width, r.Y + r.Height -5);
            upperRight = new Vector2(r.X + r.Width, r.Y);
            upperLeft = new Vector2(r.X, r.Y);
            lowerLeft = new Vector2(r.X, r.Y + r.Height -5);
        }

        //update loop
        public void Update(Level l, GameTime gameTime)
        {
            //Detect existing collisions

            airTimeManagement(l, gameTime);

            //Gravity: makes gravity happen
            if (!(onGround))
            {
                rect.Y += (int)(.5* Math.Abs(airTime-4));
            }
            
            Movement(l); //runs listeners and handles x/y positioning.
            
        }

        //draw
        public void Draw(SpriteBatch theSB)
        {
            theSB.Draw(CharacterAssetSheet, rect, Color.White);
        }

        /*Handles movement involving listeners*/
        public void Movement(Level l)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && !(Interaction.isColliding(l,lowerLeft).isSolid || Interaction.isColliding(l, upperLeft).isSolid))
            {
                rect.X-=5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && !(Interaction.isColliding(l, lowerRight).isSolid || Interaction.isColliding(l, upperRight).isSolid))
            {
                rect.X+=5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            { 
                rect.Y -= 15; 
            }

            //refresh collision variables
            moveSensors();

        }
        public void airTimeManagement(Level l, GameTime gameTime)
        {
            if (onGround)
            {
                airTime = 0;
            }
            else if (Interaction.isColliding(l, lowerLeft).isSolid || Interaction.isColliding(l, lowerRight).isSolid)
            {
                if (Interaction.isColliding(l, lowerLeft).isSolid)
                {
                    rect.Y = Interaction.isColliding(l, lowerLeft).rect.Y - 70;
                }
                else
                {
                    rect.Y = Interaction.isColliding(l, lowerRight).rect.Y - 70;
                }
                foot.Y = rect.Y + rect.Height;
                
            }

            onGround = Interaction.isColliding(l, lowerLeft).isSolid || Interaction.isColliding(l, lowerRight).isSolid;

            airTime++;
        }

        public void moveSensors()
        {
            foot.X = rect.X + (rect.Width / 2);
            foot.Y = rect.Y + rect.Height;
            lowerRight.X = rect.X + rect.Width;
            lowerRight.Y = rect.Y + rect.Height -5;
            upperRight.X = rect.X + rect.Width;
            upperRight.Y = rect.Y;
            upperLeft.X = rect.X;
            upperLeft.Y = rect.Y;
            lowerLeft.X = rect.X;
            lowerLeft.Y = rect.Y + rect.Height -5;
        }
    }
}
