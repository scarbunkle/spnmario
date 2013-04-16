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
        public Texture2D CharacterAssetSheet;
        public CollisionWeb web;//contains Draw rectangle and collision points
        //This enum's for ater use--allows only one asset sheet overall.
        public enum PlayingAs
        {
            Sam,
            Dean,
            Cas,
            Bobby,
        }
        //variables for collision logic
        public bool onGround;
        public int airTime;//time in air
        //constructor
        public Dude(Rectangle r, Texture2D asset)
        {
            CharacterAssetSheet = asset;
            web = new CollisionWeb(r);
            
        }

        public Dude(Rectangle r)
        {
            web = new CollisionWeb(r);
        }


        //update loop
        public void Update(Level l, GameTime gameTime)
        {
            



            //Gravity: makes gravity happen
            if (!(onGround))
            {
                web.area.Y += (int)(.3* Math.Abs(airTime));
            }
            
            
            Movement(l); //runs listeners and handles x/y positioning.
            airTimeManagement(l, gameTime);
            
        }

        //draw
        public void Draw(SpriteBatch theSB)
        {
            theSB.Draw(CharacterAssetSheet, web.area, Color.White);
        }

        /*Handles movement involving listeners*/
        public void Movement(Level l)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && !(Interaction.isColliding(l,web.points[0]) || Interaction.isColliding(l, web.points[5])))
            {
                web.area.X-=5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && !(Interaction.isColliding(l, web.points[1]) || Interaction.isColliding(l, web.points[2])))
            {
                if (web.area.X < 1280 / 2)
                {
                    web.area.X += 5;
                }
                else
                {
                    foreach (Tile t in l.theLevel)
                    {
                        t.rect.X -= 5;
                    }
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            { 
                if (!(Interaction.isColliding(l,web.points[0])||Interaction.isColliding(l,web.points[1])))
                {
                    web.area.Y -= 15; 
                }
            }

            //refresh collision variables


        }
        public void airTimeManagement(Level l, GameTime gameTime)
        {
            
            web.pointsUpdate(web.area);
            if (onGround)
            {
                airTime = 0;
            }
            else if (Interaction.isColliding(l, web.points[4]) || Interaction.isColliding(l, web.points[3]))
            {
                
                    Console.Out.WriteLine("Fixin Shit");
                    web.area.Y = Interaction.inTile(l, web.points[3]).rect.Y - web.area.Height;
                
            }

            onGround = Interaction.isColliding(l, web.points[3]) || Interaction.isColliding(l, web.points[4]);

            airTime++;
        }

        public void doesthiswork()
        {
            web.area.Y = 35;
        }


    }
}
