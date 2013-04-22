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
     * as.  It also handles some mechanics of collision logic, but 
     * some get passed off to InteractionsManager and CollisionWeb.*/
    public class Dude
    {
        protected Texture2D CharacterAssetSheet;
        public CollisionWeb web //reads W
        {
            get
            {
                return W;
            }
        }

        protected CollisionWeb W;//contains Draw rectangle and collision points
        //This enum's for ater use--allows only one asset sheet overall.
        public enum PlayingAs
        {
            Sam,
            Dean,
            Cas,
            Bobby,
        }
        //variables for collision logic
        protected bool onGround;
        protected int airTime;//time in air
        
        //constructor
        public Dude(Rectangle r, Texture2D asset)
        {
            CharacterAssetSheet = asset;
            W = new CollisionWeb(r);
            
        }

        //update loop
        public void Update(Level l, GameTime gameTime)
        {
            



            //Gravity: makes gravity happen
            if (!(onGround))
            {
                W.area.Y += (int)(.3* Math.Abs(airTime));
            }
            
            
            Movement(l); //runs listeners and handles x/y positioning.
            W.pointsUpdate();
            airTimeManagement(l, gameTime);
            
        }

        //draw
        public void Draw(SpriteBatch theSB)
        {
            theSB.Draw(CharacterAssetSheet, W.area, Color.White);
        }

        /*Handles movement involving listeners*/
        public void Movement(Level l)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && !(Interaction.isColliding(l,W.points[0]) || Interaction.isColliding(l, W.points[5])))
            {
                if (W.area.X < 450 && l.theLevel[0, 0].rect.X < 0)
                {
                    foreach (Tile t in l.theLevel)
                    {
                        t.rect.X += 5;
                    }
                }
                else
                {
                    W.area.X -= 5;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && !(Interaction.isColliding(l, W.points[1]) || Interaction.isColliding(l, W.points[2])))
            {

                if (W.area.X > 600 && l.theLevel[l.theLevel.GetLength(0)-1, l.theLevel.GetLength(1)-1].rect.X > 1200)
                {
                    foreach (Tile t in l.theLevel)
                    {
                        t.rect.X -= 5;
                    }
                }
                else
                {
                    W.area.X += 5;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            { 
                if (!(Interaction.isColliding(l,W.points[0])||Interaction.isColliding(l,W.points[1])))
                {
                    W.area.Y -= 15; 
                }
            }
        }

        //handles ground collisions, airtime, and landingfix
        public void airTimeManagement(Level l, GameTime gameTime)
        {
            
            
            if (onGround)
            {
                airTime = 0;
            }
            else if (Interaction.isColliding(l, W.points[4]) || Interaction.isColliding(l, W.points[3]))
            {
                
                    Console.Out.WriteLine("Fixin Shit");
                    W.area.Y = Interaction.inTile(l, W.points[3]).rect.Y - W.area.Height;
                
            }

            onGround = Interaction.isColliding(l, W.points[3]) || Interaction.isColliding(l, W.points[4]);

            airTime++;
        }
    }
}
